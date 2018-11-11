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

    private void Start()
    {
        StartCoroutine(Lifespan());
    }

    private void FixedUpdate()
    {
        Flatten(flattenAmount);
        if (attractor)
        {
            GetComponent<Rigidbody>().velocity += ((attractor.transform.position - transform.position).normalized * attractorSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains(gameObject.name) && !hasJoint && isSticky)
        {
            gameObject.AddComponent<FixedJoint>();
            GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            GetComponent<FixedJoint>().enableCollision = false;
            GetComponent<Collider>().isTrigger = true;
            hasJoint = true;
            GetComponent<Rigidbody>().mass = 0;
            OnTouch(collision.gameObject);
            if (collision.gameObject.name.Contains("Player") || collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                flattenAmount = new Vector3(0.001f, 0.001f, 0.001f);
            }
            else
            {
                flattenAmount = new Vector3(-0.002f, 0.001f, -0.002f);
            }
            attractor = null;
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
