using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellField : MonoBehaviour {

    public float gravityModifier = 0f;
    public string spellEffect;
    public bool affectStage = false;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body && (transform.position - body.transform.position).magnitude > 0)
        {
            if (!body.GetComponent<Rigidbody>().isKinematic)
            {
                body.AddForce((transform.position - body.transform.position).normalized * gravityModifier / (transform.position - body.transform.position).magnitude);
            }
            else if (body.GetComponent<Stage>() && affectStage)
            {
                body.mass = 1;
                body.isKinematic = false;
            }
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
