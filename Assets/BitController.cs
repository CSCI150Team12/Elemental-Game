using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    public virtual void Update () {
        player = GameObject.Find("Player");
        if (Input.GetKey(KeyCode.E))
        {
            if(player)
            GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 2);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (player)
            {
                Vector3 force = transform.position - player.transform.position;
                force = force.normalized / force.magnitude * 2;

                GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }
}
