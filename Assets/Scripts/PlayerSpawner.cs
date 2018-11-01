using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject P;
    public Transform spawnPointP;

	// Use this for initialization
	void Start () {
        SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPlayer() {
        P.transform.position = spawnPointP.transform.position;
    }
}
