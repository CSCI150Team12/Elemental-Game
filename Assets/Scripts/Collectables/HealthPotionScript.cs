using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Removes 50 damage from Player

public class HealthPotionScript : MonoBehaviour
{

   // public GameObject pickupEffect;     // Creates the game object
    private float holder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            StartCoroutine(Pickup(other));  // StartCoroutine because of the timer
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerController PC = player.GetComponent<PlayerController>();  // Obtain "PlayerController", properties



        holder = PC.damage;      // Moves damage into placeholder

        if (holder <= 50)       // If the user has less than 50 damage
        {
            PC.damage = 0;      // Then damge = 0
            PC.TakeDamage(0);
        }
        else                    // Else remove 50 damage from current damage
        {
            PC.TakeDamage(-50f);   
        }

        GetComponent<MeshRenderer>().enabled = false;   //Makes the item disappear

        GetComponent<Collider>().enabled = false;          //Makes the item disapper

        yield return new WaitForSeconds(0);     // Timer

        Destroy(gameObject);    // Gets rid of the object
    }
}
