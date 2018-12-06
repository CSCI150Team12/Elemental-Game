using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellField : MonoBehaviour {

    public float gravityModifier = 0f;
    public string spellEffect;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body && !body.GetComponent<Rigidbody>().isKinematic && (transform.position - body.transform.position).magnitude > 0)
        {
            body.AddForce((transform.position - body.transform.position).normalized * gravityModifier / (transform.position - body.transform.position).magnitude);
        }
        ApplyEffect(other.gameObject);
    }

    public virtual void ApplyEffect(GameObject obj)
    {
        if (!obj.transform.Find(spellEffect + " Effect(Clone)") && obj.gameObject.layer != 9 && spellEffect != "")
        {
            Instantiate(Resources.Load("Prefabs/Spell Effects/" + spellEffect + " Effect"), obj.transform);
        }
    }

}
