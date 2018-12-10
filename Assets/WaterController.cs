using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {

    List<GameObject> objs;

    void Start()
    {
        objs = new List<GameObject>();
    }

    void Update()
    {
        foreach (GameObject obj in objs)
        {
            if (obj)
            {
                float force = (transform.position.y - obj.transform.position.y) * 50f * obj.GetComponentInParent<Rigidbody>().mass;
                obj.gameObject.GetComponentInParent<Rigidbody>().position += ((obj.transform.position.normalized - new Vector3(0, obj.transform.position.normalized.y, 0)) + new Vector3(Random.Range(0,0.5f), 0, Random.Range(0, 0.5f)))*0.01f;
                obj.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, force, 0));
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>() && other.GetComponentInChildren<MeshRenderer>() && other.GetComponentInChildren<MeshRenderer>().materials[0].name.Contains("Dark Ice"))
        {
            objs.Add(other.gameObject);
            other.gameObject.GetComponentInParent<Rigidbody>().drag = 5;
            other.gameObject.GetComponentInParent<Rigidbody>().angularDrag = 5;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (objs.IndexOf(other.gameObject) != -1)
        {
            objs.Remove(other.gameObject);
            other.gameObject.GetComponentInParent<Rigidbody>().drag = 5;
            other.gameObject.GetComponentInParent<Rigidbody>().angularDrag = 5;
        }
    }
}

