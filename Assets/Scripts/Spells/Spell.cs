using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public bool isChild = true;
    public bool dying = false;
    public bool hasLifespan = false;
    public float lifespan = 0f;
    public Vector3 offset = Vector3.zero;
    public float triggerForce = 0f;
    public string triggerEffectName = "";
    public float deathDelay = 0f;
    private float lifeTime;

    
    public virtual void Start()
    {
        lifeTime = Time.time + lifespan;
    }

    public virtual void Update()
    {
        if (!dying && hasLifespan && lifeTime <= Time.time)
        {
            Die();
        }
    }

    public virtual void OnTriggerStay(Collider other)
    {
        if ((triggerForce != 0f || triggerEffectName != "" ) && other.GetComponentInParent<Rigidbody>())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100, 1 << 9))
            {
                return;
            }
            other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * triggerForce);
            if (triggerEffectName != "" && !other.transform.Find(triggerEffectName + " Effect(Clone)") && other.name != "Player" && other.gameObject.layer != 9)
            {
                Instantiate(Resources.Load("Prefabs/Spells/" + triggerEffectName + " Effect"), other.transform);
            }
        }
    }

    public virtual void Die()
    {
        if (GetComponent<ParticleSystem>())
        {
            GetComponent<ParticleSystem>().Stop();
        }
        Destroy(gameObject, deathDelay);
        dying = true;
    }

}
