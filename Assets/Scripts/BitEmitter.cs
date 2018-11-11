using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitEmitter : MonoBehaviour {

    public GameObject bit;
    public Vector3 bitVelocity;
    public int bitAmount = 400;
    public float bitDuration = 10f;
    public float emissionRate = 1;
    public bool isSticky = true;
    public bool useGravity = true;
    public Vector3 initialOffset = new Vector3(0, 0, 4);

    public void Initialize()
    {
        StartCoroutine(EmitBits());
    }

    private IEnumerator EmitBits()
    {
        for (int i = 0; i < bitAmount / emissionRate; i++)
        {
            for (int j = 0; j < emissionRate; j++)
            {
                GameObject obj = Instantiate(bit, transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), Random.Range(0f, 0.5f)), transform.rotation);
                obj.GetComponent<Rigidbody>().velocity = transform.TransformPoint(bitVelocity) * Random.Range(0.9f, 1.1f);
                SpellBit spellBit = obj.GetComponent<SpellBit>();
                spellBit.spell = GetComponent<Spell>();
                if (transform.Find("Target"))
                {
                    spellBit.attractor = transform.Find("Target").gameObject;
                }
                spellBit.GetComponent<Rigidbody>().useGravity = useGravity;
                spellBit.duration = bitDuration;
                spellBit.isSticky = isSticky;
                if (!useGravity)
                {
                    spellBit.GetComponent<Rigidbody>().drag = 5;
                }
            }
            yield return new WaitForSeconds(Random.Range(0.0005f, 0.001f));
        }
    }
}
