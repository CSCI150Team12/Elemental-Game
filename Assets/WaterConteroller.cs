using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConteroller : MonoBehaviour
{

    List<GameObject> objs;

	// Use this for initialization
	void Start () {
        objs = new List<GameObject>();
	}

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in objs)
        {
            if (obj)
            {
                float force = (transform.position.y + 0.5f - obj.transform.position.y) * 50f * obj.GetComponentInParent<Rigidbody>().mass;
                obj.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, force, 0));
            }
        }
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("WaterBit"))
        {
            Destroy(other.gameObject, 1f);
        }
        else if (other.GetComponentInParent<Rigidbody>())
        {
            objs.Add(other.gameObject);
            other.gameObject.GetComponentInParent<Rigidbody>().drag = 1;
            other.gameObject.GetComponentInParent<Rigidbody>().angularDrag = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (objs.IndexOf(other.gameObject) != -1)
        {
            objs.Remove(other.gameObject);
            other.gameObject.GetComponentInParent<Rigidbody>().drag = 0;
            other.gameObject.GetComponentInParent<Rigidbody>().angularDrag = 0;
        }
    }
}
