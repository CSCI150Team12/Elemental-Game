using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class collectableClass : MonoBehaviour {
    //public GameObject pickupSpell;     // Creates the game object
    public string CollectedSpell;       // Inputted string from 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            StartCoroutine(PickupCollectable(other));  // StartCoroutine because of the timer
        }
    }

    IEnumerator PickupCollectable(Collider player)
    {
        //Instantiate(pickupSpell, transform.position, transform.rotation);
        //Instantiate(pickupSpell, transform.position, transform.rotation);

        PlayerController PC = player.GetComponent<PlayerController>();  // Obtain "PlayerController", properties



        PC.AddElement(CollectedSpell);      

        GetComponent<MeshRenderer>().enabled = false;    //Makes the item disappear

        GetComponent<Collider>().enabled = false;                       //Makes the item disapper

        yield return new WaitForSeconds(0);     // Timer, (KEEP FOR A RETURN VALUE)

        Destroy(gameObject);    // Gets rid of the object
    }
}
