using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : Spell
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.forward, out hit, 100) || hit.collider.gameObject.layer != 9)
        {
            if (!other.transform.Find("Fire Effect(Clone)") && other.name != "Player" && other.gameObject.layer != 9)
            {
                Instantiate(Resources.Load("Prefabs/Spells/Fire Effect"), other.transform);
            }
        }
    }

    public override void Die(float delay)
    {
        GetComponent<ParticleSystem>().Stop();
        base.Die(0.25f);
    }
}
