using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : Spell
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        print(other);
        if (other.GetComponentInParent<Rigidbody>())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                if(hit.collider.gameObject.layer != 9)
                {
                    other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * 15);
                }
            }
        }
    }

    public override void Die(float delay)
    {
        GetComponent<ParticleSystem>().Stop();
        base.Die(0.75f);
    }
}
