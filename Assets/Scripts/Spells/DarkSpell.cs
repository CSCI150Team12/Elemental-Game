using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DarkSpell : MonoBehaviour
{
    public float duration;                      // How long it will remain dark.
    private Light myLight;

    private void Start()
    {
        myLight = GameObject.Find("Directional Light").GetComponent<Light>();
        myLight.enabled = false;    // Turns the switch off for daylight
    }

    private void Update()
    {
        duration -= Time.deltaTime;             // Decrements time down to 0, from duration
        if (duration <= 0)
            myLight.enabled = true; // Turns it back to daylight
    }

}
