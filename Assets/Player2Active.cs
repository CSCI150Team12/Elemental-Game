using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Active : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.Player2Active == false)
        {
            GlobalVariables.Player2Active = true;

            Destroy(gameObject);

        }
    }
}
