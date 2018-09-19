using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpell : Spell {

    // Use this for initialization
    void Start () {
        Die(0.45f);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerStay(Collider other)
    {
        print(other);
        if (other.GetComponentInParent<Rigidbody>())
        {
            other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * 25);
        }
    }
}
