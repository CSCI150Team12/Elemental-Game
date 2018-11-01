using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : Spell
{
    private void OnTriggerEnter(Collider other)
    {
        Transform fireEffect = other.transform.Find("Fire Effect(Clone)");
        if (fireEffect)
        {
            fireEffect.GetComponent<ParticleSystem>().Stop();
            Destroy(fireEffect.gameObject, 2);
        }
    }
}
