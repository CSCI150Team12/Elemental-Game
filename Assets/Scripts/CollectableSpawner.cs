using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    public GameObject item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12;
    public float duration;

    public float spawnTime; // When the item will start spawning
    public float spawnDelay;    // How often it gets spawned
    public float RangeX;      // Where it will drop on the map
    public float RangeZ;
    private Vector3 newPosition;
    private float spawnTimeMultiplier = 1f; // Initial multiplier, gets faster as time goes on

    // Use this for initialization
    void Start()
    {

        int rndTime1 = Random.Range(0, 10);
        int rndTime2 = Random.Range(0, 15);
        int rndTime3 = Random.Range(10, 20);
        int rndTime4 = Random.Range(0, 60);
        int rndTime5 = Random.Range(0, 60);
        int rndTime6 = Random.Range(0, 60);
        int rndTime7 = Random.Range(0, 60);
        int rndTime8 = Random.Range(0, 60);
        int rndTime9 = Random.Range(0, 60);
        int rndTime10 = Random.Range(0, 60);
        int rndTime11 = Random.Range(0, 60);
        int rndTime12 = Random.Range(0, 60);

        InvokeRepeating("SpawnItem1", spawnTime + rndTime1, (spawnDelay + rndTime1) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem2", spawnTime + rndTime2, (spawnDelay + rndTime2) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem3", spawnTime + rndTime3, (spawnDelay + rndTime3) * spawnTimeMultiplier);

        InvokeRepeating("SpawnItem4", spawnTime + rndTime4, (spawnDelay + rndTime4) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem5", spawnTime + rndTime5, (spawnDelay + rndTime5) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem6", spawnTime + rndTime6, (spawnDelay + rndTime6) * spawnTimeMultiplier);

        InvokeRepeating("SpawnItem7", spawnTime + rndTime7, (spawnDelay + rndTime7) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem8", spawnTime + rndTime8, (spawnDelay + rndTime8) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem9", spawnTime + rndTime9, (spawnDelay + rndTime9) * spawnTimeMultiplier);

        InvokeRepeating("SpawnItem10", spawnTime + rndTime10, (spawnDelay + rndTime10) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem11", spawnTime + rndTime11, (spawnDelay + rndTime11) * spawnTimeMultiplier);
        InvokeRepeating("SpawnItem12", spawnTime + rndTime12, (spawnDelay + rndTime12) * spawnTimeMultiplier);
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

    public void SpawnItem4()
    {
        Instantiate(item4, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem4");
        }
    }

    public void SpawnItem5()
    {
        Instantiate(item5, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem5");
        }
    }

    public void SpawnItem6()
    {
        Instantiate(item6, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem6");
        }
    }


    public void SpawnItem7()
    {
        Instantiate(item7, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem7");
        }
    }

    public void SpawnItem8()
    {
        Instantiate(item8, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem8");
        }
    }

    public void SpawnItem9()
    {
        Instantiate(item9, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem9");
        }
    }


    public void SpawnItem10()
    {
        Instantiate(item10, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem10");
        }
    }

    public void SpawnItem11()
    {
        Instantiate(item11, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem11");
        }
    }

    public void SpawnItem12()
    {
        Instantiate(item12, transform.position, transform.rotation);
        if (duration <= 0)  // Once duration is over, stop spawning
        {
            CancelInvoke("SpawnItem12");
        }
    }


    private void Update()
    {
        duration -= Time.deltaTime; // Decrements duration, when 0 no longer spawn items

        if (duration < 100 & duration > 80)
        {
            RangeX = 8f;
            RangeZ = 8f;
            spawnTimeMultiplier = 0.75f;
        }
        else if (duration < 80 & duration > 60)
        {
            RangeX = 5f;
            RangeZ = 5f;
            spawnTimeMultiplier = 0.5f;
        }
        else if (duration < 60 & duration > 40)
        {
            RangeX = 4f;
            RangeZ = 4f;
            spawnTimeMultiplier = 0.25f;
        }
        else if (duration < 40 & duration > 20)
        {
            RangeX = 3f;
            RangeZ = 3f;
            spawnTimeMultiplier = 0.1f;
        }
        else if (duration < 20)
        {
            RangeX = 2f;
            RangeZ = 2f;
            spawnTimeMultiplier = 0.05f;
        }

        newPosition = new Vector3(0f, 25f, 0f); // Resets the position to Default
        transform.position = newPosition;

        float rndLocX = Random.Range((-1 * RangeX), RangeX);  // Gets the new location
        float rndLocZ = Random.Range((-1 * RangeZ), RangeZ);

        newPosition = new Vector3(rndLocX, 25f, rndLocZ);    // Changes the location of the spawner
        transform.position = newPosition;

    }

}