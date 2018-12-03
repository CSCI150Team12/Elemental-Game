using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitEmitter : MonoBehaviour {

    public GameObject bit;
    public Vector3 bitVelocity;
    public float bitDrag = 5;
    public Vector3 expulsionVelocity = Vector3.zero;
    public bool useExpulsionGravity = true;
    public int bitAmount = 400;
    public float bitDuration = 10f;
    public float emissionRate = 1;
    public bool isSticky = true;
    public bool useGravity = true;
    public ArrayList spellBits = new ArrayList();

    public void Initialize()
    {
        StartCoroutine(EmitBits());
    }

    public void Expel()
    {
        if (transform.Find("Target"))
        {
            foreach (SpellBit spellBit in spellBits)
            {
                if (spellBit)
                {
                    spellBit.attractor = null;
                    spellBit.GetComponent<Rigidbody>().velocity += transform.TransformDirection(expulsionVelocity);
                    if (useExpulsionGravity)
                    {
                        spellBit.GetComponent<Rigidbody>().drag = 0;
                        spellBit.GetComponent<Rigidbody>().useGravity = true;
                    }
                }
            }
            GetComponent<Spell>().Die();
        }
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
                print(transform);
                if (transform.Find("Target"))
                {
                    spellBit.attractor = transform.Find("Target").gameObject;
                }
                spellBit.GetComponent<Rigidbody>().useGravity = useGravity;
                spellBit.duration = bitDuration;
                spellBit.isSticky = isSticky;
                if (!useGravity)
                {
                    spellBit.GetComponent<Rigidbody>().drag = bitDrag;
                }
                spellBits.Add(spellBit);
            }
            yield return new WaitForSeconds(Random.Range(0.0005f, 0.001f));
        }
    }
}
