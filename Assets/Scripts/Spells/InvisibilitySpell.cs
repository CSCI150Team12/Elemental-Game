using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses the global variable InvisibilityHolder, which is obtained from InvisibilityHolderScript.cs
public class InvisibilitySpell : MonoBehaviour {

    public float duration;  // The duration the player will remain invisible
    private void Start()
    {
        GlobalVariables.InvisibilityHolder.enabled = false; // Makes player invisible
    }

    private void Update()
    {    
        duration -= Time.deltaTime;                 // Decrement duration down to 0
        if (duration <= 0)
            GlobalVariables.InvisibilityHolder.enabled = true;  // Makes player visible
    }
}
