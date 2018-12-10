using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour {

    public float damagePerSecond = 0f;
    public float lifespan = 1f;
    public float deathspan = 1f;
    public Vector3 offset = Vector3.zero;
    public bool freezeObj = false;
    public bool shrinkDeath = false;
    public Vector3 shrinkDirection = new Vector3(1,1,1);
    private float startTime;

	protected virtual void Start () {
        startTime = Time.time;
        InvokeRepeating("DealDamage", 1f, 0.1f);
        ToggleFreeze(true);
        transform.localPosition += offset;
	}
	
	void FixedUpdate () {
        if (startTime + lifespan < Time.time)
        {
            Die();
            if (transform.localScale.magnitude > 0 && shrinkDeath)
            {
                transform.localScale -= shrinkDirection * (1 / (deathspan*60));
            }
        }
    }

    void ToggleFreeze(bool isFrozen)
    {
        if (freezeObj)
        {
            PlayerController player = gameObject.GetComponentInParent<PlayerController>();
            if (player)
            {
                player.SetFrozen(isFrozen);
            }
        }
    }

    void DealDamage()
    {
        PlayerController player = gameObject.GetComponentInParent<PlayerController>();
        if (player)
        {
            player.TakeDamage(damagePerSecond / 10);
        }
    }

    public virtual void Die()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem)
        {
            particleSystem.Stop();
        }
        ToggleFreeze(false);
        CancelInvoke();
        Destroy(gameObject, deathspan);
    }
}
