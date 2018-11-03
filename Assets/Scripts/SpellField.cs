using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellField : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body && !body.GetComponent<Rigidbody>().isKinematic)
        {
            if ((transform.position - body.transform.position).magnitude < 1)
            {
                body.transform.position = transform.position - new Vector3(0,1,0);
                other.transform.parent = transform;
                Destroy(other.GetComponentInChildren<Rigidbody>());
                Destroy(other);
            }
            else
            {
                body.AddForce((transform.position - body.transform.position).normalized * 300 / (transform.position - body.transform.position).magnitude);
            }
        }
        ApplyEffect(other.gameObject);
    }

    public virtual void ApplyEffect(GameObject obj)
    {
        if (!obj.transform.Find("Fire Effect(Clone)") && obj.gameObject.layer != 9)
        {
            Instantiate(Resources.Load("Prefabs/Spell Effects/Fire Effect"), obj.transform);
        }
    }

}
