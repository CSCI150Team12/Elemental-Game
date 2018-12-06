using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Used to collect who picks it up, and stores it in the global vairable InvisibilityHolder
// This info is used in IvisibilitySpell.cs
public class InvisibilityHolderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            GlobalVariables.InvisibilityHolder = other.GetComponentInChildren<SkinnedMeshRenderer>();
        } 
    }
}

