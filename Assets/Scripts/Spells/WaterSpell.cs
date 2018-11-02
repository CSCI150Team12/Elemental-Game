using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : Spell
{
    protected override void OnParticleCollision(GameObject other)
    {
        base.OnParticleCollision(other);
        Transform fireEffect = other.transform.Find("Fire Effect(Clone)");
        if (fireEffect)
        {
            fireEffect.GetComponent<ParticleSystem>().Stop();
            Destroy(fireEffect.gameObject, 2);
        }
    }
}
