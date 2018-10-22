using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell {

    public override void Initialize()
    {
        base.Initialize();
        StartCoroutine(FreezeBody());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        transform.Find("Body").GetComponent<ParticleSystem>().Play();
        SetVelocity(Vector3.zero);
        Die();
    }

    private IEnumerator FreezeBody()
    {
        yield return new WaitForSeconds(0.01f);
        transform.Find("Body").GetComponent<ParticleSystem>().Pause();
    }
}
