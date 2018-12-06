using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpell : Spell {

    private GameObject tile;
    private ArrayList objs = new ArrayList();
    private float holder;
   // public GameObject pickupEffect;     // Creates the game object (Do I need this?)
    private float duration = 10f;            // Duration of the spell (10 Seconds)

    public override void Initialize()   // Transforms the ground
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out hit, 100, 1 << 9))
        {
            transform.position = hit.transform.position;
            transform.rotation = hit.transform.rotation;
            tile = hit.transform.gameObject;
            transform.parent = tile.transform;
            base.Initialize();
        }
        else
        {
            Die();
        }
    }

    private void OnTriggerStay(Collider other)  // When player enters the tile
    {
        if (other.CompareTag("Player"))    // If the player touches the item, then activate!
        {
            StartCoroutine(StandOn(other));  // StartCoroutine because of the timer            
        }
    }

    IEnumerator StandOn(Collider player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerController PC = player.GetComponent<PlayerController>();  // Obtain "PlayerController", properties

        PC.TakeDamage(2f);
     
        yield return new WaitForSeconds(0);     // Timer

    }

    private void Update()   // Changes the tile back to normal
    {
        
        duration -= Time.deltaTime; // Decrements duration, when 0 remove spell
        
        if (duration <= 0)
        {
            Destroy(gameObject);    // Gets rid of the object  
            GetComponent<MeshRenderer>().enabled = false;   //Makes the item disappear

            GetComponent<Collider>().enabled = false;          //Makes the item disapper
           
        }
    }

}
