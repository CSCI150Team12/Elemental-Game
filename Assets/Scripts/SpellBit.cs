using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBit : MonoBehaviour {
    public bool hasJoint = false;
    public Spell spell;
    public float damageAmount = 1f;
    public float slowFactor = 1.1f;
    public float duration = 10f;
    private Vector3 flattenAmount;
    private PlayerController player;
    public GameObject attractor;
    public float attractorSpeed = 1f;
    public bool isSticky = true;
    public bool flattenDeath = true;
    public bool touchDeath = false;
    public new Vector3 constantForce = Vector3.zero;

    private void Start()
    {
        if (slowFactor <= 0)
        {
            slowFactor = 1;
        }
        StartCoroutine(Lifespan());
    }

    private void FixedUpdate()
    {
        Flatten(flattenAmount);
        if (attractor)
        {
            GetComponent<Rigidbody>().velocity += ((attractor.transform.position - transform.position).normalized * attractorSpeed);
        }
        GetComponent<Rigidbody>().velocity += constantForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains(gameObject.name) && !hasJoint)
        {
            OnTouch(collision.gameObject);
            if (touchDeath)
            {
                Die();
            }
            if (isSticky)
            {
                gameObject.AddComponent<FixedJoint>();
                hasJoint = true;
                GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
                GetComponent<FixedJoint>().enableCollision = false;
                GetComponent<Collider>().isTrigger = true;
                GetComponent<Rigidbody>().mass = 0;
                if (flattenDeath)
                {
                    if (collision.gameObject.name.Contains("Player") || collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
                    {
                        flattenAmount = new Vector3(0.001f, 0.001f, 0.001f);
                    }
                    else
                    {
                        flattenAmount = new Vector3(-0.002f, 0.001f, -0.002f);
                    }
                }
                attractor = null;
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTouch(other.gameObject);
    }

    private void OnTouch(GameObject obj)
    {
        if (obj.GetComponent<PlayerController>())
        {
            player = obj.GetComponent<PlayerController>();
            player.TakeDamage(damageAmount);
            player.moveSpeed /= slowFactor;
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
            Die();
        }
    }

    private void Die()
    {
        if (player)
        {
            player.moveSpeed *= slowFactor;
        }
        Destroy(gameObject);
    }

    private IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(duration);
        Die();
    }
}
