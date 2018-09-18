using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : BitController
{

    float lifespan = 10f;

    // Use this for initialization
    void Start () {
        lifespan += Time.time;
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        if(Time.time > lifespan)
        {
            Instantiate(Resources.Load("Prefabs/Blocks/Water/WaterBit"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
        GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 0);
    }
}
