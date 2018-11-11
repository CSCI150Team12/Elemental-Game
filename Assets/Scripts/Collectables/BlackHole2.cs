using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole2 : MonoBehaviour {
    public GameObject pickupSpell;     // Creates the game object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            StartCoroutine(PickupBlackHole(other));  // StartCoroutine because of the timer
        }
    }

    IEnumerator PickupBlackHole(Collider player)
    {
        Instantiate(pickupSpell, transform.position, transform.rotation);

        PlayerController PC = player.GetComponent<PlayerController>();  // Obtain "PlayerController", properties



        PC.spellStr = "Black Hole Spell";      // Changed speed to 8

        GetComponent<MeshRenderer>().enabled = false;   //Makes the item disappear

        GetComponent<Collider>().enabled = false;                       //Makes the item disapper

        yield return new WaitForSeconds(0);     // Timer, (KEEP FOR A RETURN VALUE)

        Destroy(gameObject);    // Gets rid of the object
    }
}
