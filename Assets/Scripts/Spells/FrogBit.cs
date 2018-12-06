using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBit : MonoBehaviour {

    private GameObject target;

    private void Start()
    {
        InvokeRepeating("Jump", 1f, 1.5f + Random.Range(0, .25f));
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            target = player.gameObject;
        }
    }

    void Jump()
    {
        if (target)
        {
            GetComponent<Rigidbody>().AddForce(((target.transform.position - transform.position).normalized + Vector3.up)*2);
        }
    }
}
