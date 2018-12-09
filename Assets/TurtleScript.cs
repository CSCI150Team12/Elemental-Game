using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour {
    //Vector3 CurrentPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       // CurrentPos = transform.position;
      //  CurrentPos.y += (-5f * GlobalVariables.TurtleActive);
       // transform.position = CurrentPos;

        if(GlobalVariables.TurtleActive == false)
        {
            GlobalVariables.TurtleActive = true;
            Destroy(gameObject);
            
        }
	}
}
