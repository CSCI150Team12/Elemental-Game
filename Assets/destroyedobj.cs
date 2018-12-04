using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedobj : MonoBehaviour {

    public GameObject destroyed;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyed, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
