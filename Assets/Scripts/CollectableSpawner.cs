using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour {

    public GameObject item1, item2, item3;
    public float duration;

    public float spawnTime; // When the item will start spawning
    public float spawnDelay;    // How often it gets spawned
    public float RangeX;      // Where it will drop on the map
    public float RangeZ;      
    private Vector3 newPosition;
    private float spawnTimeMultiplier = 1f; 

	// Use this for initialization
	void Start () {

        int rndTime1 = Random.Range(5, 10);
        int rndTime2 = Random.Range(11, 15);
        int rndTime3 = Random.Range(30, 60);
        
        InvokeRepeating("SpawnItem1", spawnTime + rndTime1, (spawnDelay + rndTime1) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem2", spawnTime + rndTime2, (spawnDelay + rndTime2) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem3", spawnTime + rndTime3, (spawnDelay+rndTime3)* spawnTimeMultiplier);
    }
	
	public void SpawnItem1()
    {
        Instantiate(item1, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem1");
        }
    }

    public void SpawnItem2()    
    {
        Instantiate(item2, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem2");
        }
    }

    public void SpawnItem3()    
    {
        Instantiate(item3, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem3");
        }
    }

    
    private void Update()   
    {
        duration -= Time.deltaTime; // Decrements duration, when 0 no longer spawn items

        if (duration < 60 & duration > 30)
        {
            RangeX = 7f;
            RangeZ = 7f;
            spawnTimeMultiplier = 0.75f; 
        }
        else if (duration < 30)
        {
            RangeX = 4f;
            RangeZ = 4f;
            spawnTimeMultiplier = 0.5f;
        }

        newPosition = new Vector3(0f, 25f, 0f); // Resets the position to Default
        transform.position = newPosition;

        float rndLocX = Random.Range((-1*RangeX), RangeX);  // Gets the new location
        float rndLocZ = Random.Range((-1*RangeZ), RangeZ);

        newPosition = new Vector3(rndLocX,25f, rndLocZ);    // Changes the location of the spawner
        transform.position = newPosition;

    }

}
