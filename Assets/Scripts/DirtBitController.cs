using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBitController : BitController {

    bool hasMelted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("MagmaBit") && !hasMelted)
        {
            Instantiate(Resources.Load("Prefabs/Blocks/Magma/MagmaBit"), transform.position, transform.rotation);
            Instantiate(Resources.Load("Prefabs/Blocks/Magma/MagmaBit"), collision.transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            hasMelted = true;
        }
    }
}
