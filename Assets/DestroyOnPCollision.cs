using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPCollision : MonoBehaviour {
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Spells") {
            Destroy(other);
        }
    }
}
