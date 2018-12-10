using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseractSpell : MonoBehaviour {

    public float duration;
    private GameObject cameraMain;
    private GameObject cameraAerial;
    private void Start()
    {
        cameraMain = GameObject.Find("Camera Target").transform.Find("CameraMain").gameObject;
        cameraAerial = GameObject.Find("Camera Target").transform.Find("CameraAerial").gameObject;
        cameraAerial.GetComponent<AudioListener>().enabled = true;
        cameraAerial.SetActive(true);

        cameraMain.SetActive(false);
        cameraMain.GetComponent<AudioListener>().enabled = false;

    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            cameraAerial.GetComponent<AudioListener>().enabled = false;
            cameraAerial.SetActive(false);

            cameraMain.SetActive(true);
            cameraMain.GetComponent<AudioListener>().enabled = true;
        }
    }
}
