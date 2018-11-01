using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaCollapseScript : MonoBehaviour {

    private GameObject[] fobject2;
    private GameObject[] fobject;
    private GameObject[] qobject;
    private GameObject[] tobject;
    private GameObject[] sobject;
    private GameObject[] cobject;

    private float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        fobject2 = GameObject.FindGameObjectsWithTag("FinalObject2");
        fobject = GameObject.FindGameObjectsWithTag("FinalObject");
        qobject = GameObject.FindGameObjectsWithTag("QObject");
        tobject = GameObject.FindGameObjectsWithTag("TObject");
        sobject = GameObject.FindGameObjectsWithTag("SObject");
        cobject = GameObject.FindGameObjectsWithTag("CObject");
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;
        int seconds = (int)t;

        if (seconds == 120) {
            if (gameObject.tag == "CenterRing") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < cobject.Length; i++) {
                    cobject[i].GetComponent<Rigidbody>().isKinematic = false;
                    cobject[i].GetComponent<MeshCollider>().convex = false;

                }
            }
        }
        else if (seconds == 100) {
            if (gameObject.tag == "SecondaryRing") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < sobject.Length; i++) {
                    sobject[i].GetComponent<Rigidbody>().isKinematic = false;
                    sobject[i].GetComponent<MeshCollider>().convex = false;

                }
            }
        }
        else if (seconds == 80) {
            if (gameObject.tag == "TertiaryRing") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < tobject.Length; i++) {
                    tobject[i].GetComponent<Rigidbody>().isKinematic = false;
                    tobject[i].GetComponent<MeshCollider>().convex = false;

                }
            }
        }
        else if (seconds == 60) {
            if (gameObject.tag == "QuaternaryRing") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < qobject.Length; i++) {
                    qobject[i].GetComponent<Rigidbody>().isKinematic = false;
                    qobject[i].GetComponent<MeshCollider>().convex = false;

                }
            }
        }
        else if (seconds == 40) {
            if (gameObject.tag == "FinalRing") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < fobject.Length; i++) {
                    fobject[i].GetComponent<Rigidbody>().isKinematic = false;
                    fobject[i].GetComponent<MeshCollider>().convex = false;

                }
            }
        }
        else if (seconds == 20) {
            if (gameObject.tag == "FinalRing2") {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                for (int i = 0; i < fobject2.Length; i ++) {
                    fobject2[i].GetComponent<Rigidbody>().isKinematic = false;
                    fobject2[i].GetComponent<MeshCollider>().convex = false;
                }
            }
        }
    }
}
