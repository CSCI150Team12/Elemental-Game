using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : Spell
{

    private GameObject tile;

    public override void Initialize()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out hit, 100, 1 << 9) && !hit.transform.GetComponentInChildren<EarthSpell>())
        {
            transform.position = hit.transform.position;
            transform.rotation = hit.transform.rotation;
            tile = hit.transform.gameObject;
            transform.parent = hit.transform;
            GetComponentInChildren<MeshRenderer>().material = tile.GetComponent<MeshRenderer>().material;
            base.Initialize();
        }
        else
        {
            Die();
        }
    }

    public override void Update () {
        base.Update();
        if (started && transform.parent.GetComponent<Rigidbody>().isKinematic)
        {
            if (dying)
            {
                Slide(-5f, 0f, 2);
            }
            else
            {
                Slide(5f, 0f, 2);
            }
        }
        
	}

    void Slide(float speed, float min, float max)
    {
        if ((transform.position.y < max && speed > 0) || (transform.position.y > min && speed < 0 ))
        {
            tile.GetComponent<Stage>().followMarker.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            transform.Find("Body").localScale += new Vector3(0, 0, 2.5f * speed * Time.deltaTime);
            transform.Find("Body").position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (transform.position.y <= min && speed < 0)
        {
        }
    }

    public override void Die()
    {
        base.Die();
    }
}
