using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpell : Spell {


    private GameObject tile;
    private GameObject target;

    public override void Initialize()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out hit, 100, 1 << 9))
        {
            transform.position = hit.transform.position;
            transform.rotation = hit.transform.rotation;
            target = transform.Find("Target").gameObject;
            target.transform.parent = transform.parent;
            tile = hit.transform.gameObject;
            tile.GetComponent<Collider>().enabled = false;
            tile.GetComponent<MeshRenderer>().enabled = false;
            transform.parent = tile.transform;
            base.Initialize();
        }
        else
        {
            Die();
        }
    }

    public override void SecondaryCast()
    {
        base.SecondaryCast();
        GetComponent<Rigidbody>().velocity += target.transform.parent.TransformDirection(new Vector3(0,0,20));
        GetComponent<Rigidbody>().drag = 0;
        target = null;
        dying = true;
        transform.parent = null;
    }

    public override void Update()
    {
        base.Update();
        if (target)
        {
            GetComponent<Rigidbody>().velocity += ((target.transform.position - transform.position).normalized * 1f);
        }
    }
}
