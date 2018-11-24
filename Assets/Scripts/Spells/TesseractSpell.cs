using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseractSpell : MonoBehaviour {

    public float duration;
    private void Start()
    {
        GlobalVariables.MainCameraActive = false;
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
            GlobalVariables.MainCameraActive = true;
    }
}
