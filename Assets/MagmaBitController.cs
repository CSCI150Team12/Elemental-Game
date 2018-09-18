using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaBitController : BitController
{

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("WaterBit"))
        {
            Instantiate(Resources.Load("Prefabs/Blocks/Cloud/CloudBit"), transform.position, transform.rotation);
            if(Random.Range(0f, 100f) < 50)
            {
               Instantiate(Resources.Load("Prefabs/Blocks/Grass/DirtBit"), transform.position, transform.rotation);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Contains("GrassBit"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Surface Water")
        {
            Instantiate(Resources.Load("Prefabs/Blocks/Cloud/CloudBit"), transform.position, transform.rotation);
            if (Random.Range(0f, 100f) < 50)
            {
                Instantiate(Resources.Load("Prefabs/Blocks/Grass/DirtBit"), transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
