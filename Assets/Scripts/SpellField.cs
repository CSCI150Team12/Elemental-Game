using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellField : MonoBehaviour {

    private Vector3 size = Vector3.one*3;
    public float gravityFactor = 300f;
    public float sizeFactor = 0.06f;
    public bool hasFire = true;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.GetComponent<Rigidbody>();
        if (body && !body.GetComponent<Rigidbody>().isKinematic)
        {
            if ((transform.position - body.transform.position).magnitude < 4)
            {
                body.transform.position = transform.position - new Vector3(0,1,0);
                body.transform.parent = transform.parent;
                body.transform.localScale = Vector3.zero;
                if (!hasFire)
                {
                    Destroy(other);
                }
                else
                {
                    Destroy(other.GetComponentInChildren<Rigidbody>());
                    Destroy(other);
                }
                size += Vector3.one * sizeFactor;
            }
            else
            {
                body.AddForce((transform.position - body.transform.position).normalized * gravityFactor / (transform.position - body.transform.position).magnitude);
            }
        }
        ApplyEffect(other.gameObject);
    }

    public virtual void ApplyEffect(GameObject obj)
    {
        if (!obj.transform.Find("Fire Effect(Clone)") && obj.gameObject.layer != 9 && hasFire)
        {
            Instantiate(Resources.Load("Prefabs/Spell Effects/Fire Effect"), obj.transform);
        }
    }

    private void Update()
    {
        transform.parent.localScale = Vector3.MoveTowards(transform.parent.localScale, size, sizeFactor);
    }

}
