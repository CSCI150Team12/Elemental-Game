using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaSpell : Spell {

    public GameObject bit;
    public Vector3 bitVelocity;

    public override void Initialize()
    {
        base.Initialize();
        StartCoroutine(EmitBits());
    }

    private IEnumerator EmitBits()
    {
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject obj = Instantiate(bit, transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), Random.Range(0f, 0.5f)), transform.rotation);
                obj.GetComponent<Rigidbody>().velocity = transform.TransformPoint(bitVelocity) * Random.Range(0.9f, 1.1f);
            }
            yield return new WaitForSeconds(Random.Range(0.0005f, 0.001f));
        }
    }

}
