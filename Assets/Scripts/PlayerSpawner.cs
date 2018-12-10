using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject P;                // Player gameobject
    public Transform spawnPointP;       // Initial spawn point
    public Transform spawnPointCenter;  // Spawn after match starts

	// Use this for initialization
	void Start () {
        SpawnPlayer(); //Spawn player at the start of the game
	}

    public void SpawnPlayer() {
        P.transform.position = spawnPointP.transform.position; // Spawn player at position of spawnpoint
    }

    public void SpawnPlayerCenter() {
        P.transform.position = spawnPointCenter.transform.position; // Spawn player  at the center of the map upon death
        
    }

}
