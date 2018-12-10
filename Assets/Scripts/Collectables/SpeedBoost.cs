using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

   public GameObject pickupEffect;     // Creates the game object, Need this for Speed Boost potion

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            StartCoroutine(Pickup(other));  // StartCoroutine because of the timer
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerController PC = player.GetComponent<PlayerController>();  // Obtain "PlayerController", properties

        PC.moveSpeed = 9f;      // Changed speed to 8

        GetComponent<MeshRenderer>().enabled = false;   //Makes the item disappear
        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;      //Makes the item disapper
        
        yield return new WaitForSeconds(5);     // Timer

        PC.moveSpeed = 5f;      // After Timer expires, then go back to original speed 4
        Destroy(gameObject);    // Gets rid of the object
    }
}
