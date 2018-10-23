using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaBit : MonoBehaviour {

    public bool hasJoint = false;
    public Vector3 flattenAmount;

    private void FixedUpdate()
    {
        Flatten(flattenAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("MagmaBit") && !hasJoint)
        {
            gameObject.AddComponent<FixedJoint>();
            GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            GetComponent<FixedJoint>().enableCollision = false;
            GetComponent<Collider>().isTrigger = true;
            hasJoint = true;
            if (collision.gameObject.name.Contains("Player"))
            {
                flattenAmount = new Vector3(0.001f, 0.001f, 0.001f);
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            }
            else
            {
                flattenAmount = new Vector3(-0.002f, 0.001f, -0.002f);
            }
        }

    }

    private void Flatten(Vector3 scale)
    {
        if (transform.localScale.y >= 0.002f)
        {
            transform.localScale -= scale;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
