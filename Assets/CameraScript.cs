﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject cameraMain;
    public GameObject cameraAerial;

    AudioListener cameraMainAudioLis;
    AudioListener cameraAerialAudioLis;

    void Start()
    {
        cameraMainAudioLis = cameraMain.GetComponent<AudioListener>();
        cameraAerialAudioLis = cameraAerial.GetComponent<AudioListener>();
    }

    void Update()
    {

        if (GlobalVariables.MainCameraActive == true)
        {
            cameraAerialAudioLis.enabled = false;
            cameraAerial.SetActive(false);

            cameraMain.SetActive(true);
            cameraMainAudioLis.enabled = true;
        }
        else
        {
            cameraMainAudioLis.enabled = false;
            cameraMain.SetActive(false);

            cameraAerial.SetActive(true);
            cameraAerialAudioLis.enabled = true;
        }
    }
}