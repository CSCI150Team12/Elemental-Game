using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaBit : MonoBehaviour {

    public bool hasJoint = false;
    public Vector3 flattenAmount;
    public Spell spell;

    private void Start()
    {
        Destroy(this.gameObject, 7);
    }

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
            OnTouch(collision.gameObject);
            if (collision.gameObject.name.Contains("Player"))
            {
                flattenAmount = new Vector3(0.001f, 0.001f, 0.001f);
            }
            else
            {
                flattenAmount = new Vector3(-0.002f, 0.001f, -0.002f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTouch(other.gameObject);
    }

    private void OnTouch(GameObject obj)
    {
        if (obj.name.Contains("Player"))
        {
            obj.GetComponent<PlayerController>().TakeDamage(1);
            spell.ApplyEffect(obj);
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
