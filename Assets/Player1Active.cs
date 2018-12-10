using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Active : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalVariables.Player1Active == false)
        {
            GlobalVariables.Player1Active = true;

            Destroy(gameObject);

        }
    }
}
