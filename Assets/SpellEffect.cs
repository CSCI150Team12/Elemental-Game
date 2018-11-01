using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour {

    public float damagePerSecond = 0f;
    public float lifespan = 1f;
    public float deathspan = 1f;
    private float startTime;

	void Start () {
        startTime = Time.time;
        InvokeRepeating("DealDamage", 1f, 0.1f);
	}
	
	void Update () {
        if (startTime + lifespan < Time.time)
        {
            Die();
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

    public void Die()
    {
        GetComponent<ParticleSystem>().Stop();
        CancelInvoke();
        Destroy(gameObject, deathspan);
    }
}
