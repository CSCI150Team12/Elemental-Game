using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFireballsSpell : Spell {

    public override void Initialize()
    {
        base.Initialize();
        StartCoroutine(FreezeBody());
    }

    public override void Update()
    {
        base.FixedUpdate();
        transform.localEulerAngles += new Vector3(0,20,0);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        transform.Find("Body 1").GetComponent<ParticleSystem>().Play();
        transform.Find("Body 2").GetComponent<ParticleSystem>().Play();
        SetVelocity(Vector3.zero);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        Die();
    }

    private IEnumerator FreezeBody()
    {
        yield return new WaitForSeconds(0.01f);
        transform.Find("Body 1").GetComponent<ParticleSystem>().Pause();
        transform.Find("Body 2").GetComponent<ParticleSystem>().Pause();
    }
}
