using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicksandSpell : Spell {

    private GameObject tile;
    private ArrayList objs = new ArrayList();

    public override void Initialize()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, 1, 0), out hit, 100, 1 << 9))
        {
            transform.position = hit.transform.position;
            transform.rotation = hit.transform.rotation;
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

    public override void Update()
    {
        base.Update();

        ArrayList removeObjs = new ArrayList();

        foreach (GameObject obj in objs)
        {
            if (obj)
            {
                if (transform.position.y < obj.transform.position.y + 1)
                {
                    obj.GetComponent<Rigidbody>().velocity = (transform.position - obj.transform.position).normalized * 0.05f;
                }
                else
                {
                    removeObjs.Add(obj);
                }
            }
        }
        foreach (GameObject obj in removeObjs)
        {
            objs.Remove(obj);
        }
    }




    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.GetComponent<Rigidbody>()) {
            objs.Add(other.gameObject);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.moveSpeed = 0.05f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objs.Contains(other.gameObject))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.moveSpeed = 5f;
            }
            objs.Remove(other.gameObject);
        }
    }
}
