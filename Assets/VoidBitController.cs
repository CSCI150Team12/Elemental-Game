using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBitController : BitController {

    GameObject player;
    GameObject ground;
    int voidThreshold = 8;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        foreach (Collider collider in player.GetComponentsInChildren<Collider>())
        {
            Physics.IgnoreCollision(collider, GetComponent<Collider>(), true);
        }
        ground = GameObject.Find("Ground");
        foreach (Collider collider in ground.GetComponentsInChildren<Collider>())
        {
            Physics.IgnoreCollision(collider, GetComponent<Collider>(), true);
        }
    }

    // Update is called once per frame
    //public override void Update()
    //{
     //   base.Update();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("VoidBit"))
            return;
        if (other.transform.parent.gameObject.name == "Player")
        {
            print(ground);
            other.GetComponentInParent<PlayerController>().voidCount++;
            if (other.GetComponentInParent<PlayerController>().voidCount >= voidThreshold)
            {
                foreach (Collider collider in player.GetComponentsInChildren<Collider>())
                {
                    foreach (Collider collider2 in ground.GetComponentsInChildren<Collider>())
                    {
                        Physics.IgnoreCollision(collider, collider2, true);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("VoidBit"))
            return;
        if (other.transform.parent.name == "Player")
        {
            other.GetComponentInParent<PlayerController>().voidCount--;
            if (other.GetComponentInParent<PlayerController>().voidCount < voidThreshold)
            {
                foreach (Collider collider in player.GetComponentsInChildren<Collider>())
                {
                    foreach (Collider collider2 in ground.GetComponentsInChildren<Collider>())
                    {
                        Physics.IgnoreCollision(collider, collider2, false);
                    }
                }
            }
        }
    }
}
