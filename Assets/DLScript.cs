using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLScript : MonoBehaviour {

     
    private Light myLight;
	void Start ()
    {
        myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        myLight.enabled = GlobalVariables.LightSwitch;
        myLight.intensity = GlobalVariables.LightIntensity;
    }
}
