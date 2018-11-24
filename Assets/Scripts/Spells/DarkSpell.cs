using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DarkSpell : MonoBehaviour
{
    public float duration;
    private void Start()
    {
        GlobalVariables.LightSwitch = false;
    }

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
            GlobalVariables.LightSwitch = true;
    }

}
