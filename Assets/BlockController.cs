using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public float bitSpacing = 0.1f;
    public string bit1Path = "Prefabs/Blocks/Grass/GrassBit";
    public string bit2Path = "Prefabs/Blocks/Grass/DirtBit";
    List<GameObject> bits;

    // Use this for initialization
    void Start () {
        bits = new List<GameObject>();
        GenerateBits();
    }
	
	// Update is called once per frame
	void Update () {
        float range = 10f;
        if (bits.Count > 0 && Input.GetKey(KeyCode.F))
        {
            foreach (GameObject bit in bits)
            {
                if (bit)
                {
                    //bit.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)));
                    bit.GetComponent<Rigidbody>().AddForce(bit.transform.position - transform.position + new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)));
                }
            }
        }
	}

    void GenerateBits ()
    {
        float startPos = 0.45f;
        for (int j = 0; j < 5; j += 1)
        {
            for (int i = 0; i < 5; i += 1)
            {
                bits.Add((GameObject)Instantiate(Resources.Load(bit1Path), transform.position + new Vector3(startPos - i * bitSpacing, startPos, startPos - j * bitSpacing), transform.rotation, transform));
            }
        }
        
        for (int k = 0; k < 5; k += 1)
        {
            for (int j = 0; j < 4; j += 1)
            {
                for (int i = 0; i < 5; i += 1)
                {
                    bits.Add((GameObject)Instantiate(Resources.Load(bit2Path), transform.position + new Vector3(startPos - i * bitSpacing, startPos - bitSpacing - j * bitSpacing, startPos - k * bitSpacing), transform.rotation, transform));
                }
            }
        }

        Destroy(transform.Find("Placeholder").gameObject);
        
    }
}
