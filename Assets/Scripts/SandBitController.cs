using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBitController : BitController
{

    int jointCount;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (gameObject.GetComponent<SpringJoint>())
        {
            //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,3,0);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player") && jointCount < 1)
        {
            gameObject.AddComponent<SpringJoint>();
            gameObject.GetComponent<SpringJoint>().connectedBody = collision.rigidbody;
            gameObject.GetComponent<SpringJoint>().enableCollision = false;
            gameObject.GetComponent<SpringJoint>().spring = 5;
            gameObject.GetComponent<Rigidbody>().mass = 0.01f;
            jointCount++;
            gameObject.GetComponent<Rigidbody>().angularDrag = 1;
            gameObject.GetComponent<Rigidbody>().drag = 1;
        }
        if (collision.gameObject.name.Contains("SandBit") && jointCount >= 1 && jointCount < 2)
        {
            gameObject.AddComponent<SpringJoint>();
            gameObject.GetComponents<SpringJoint>()[jointCount].connectedBody = collision.rigidbody;
            gameObject.GetComponents<SpringJoint>()[jointCount].enableCollision = false;
            gameObject.GetComponents<SpringJoint>()[jointCount].spring = 5;
            jointCount++;
            collision.gameObject.GetComponent<Rigidbody>().angularDrag = 1;
            collision.gameObject.GetComponent<Rigidbody>().drag = 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Surface Water"))
        {
            foreach(Component obj in gameObject.GetComponents<SpringJoint>())
            {
                Destroy(obj);
            }
        }
    }

}
