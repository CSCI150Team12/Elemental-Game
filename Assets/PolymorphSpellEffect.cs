using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphSpellEffect : SpellEffect
{

    public GameObject turtle;
    private PlayerController player;

    protected override void Start()
    {
        foreach (SkinnedMeshRenderer renderer in transform.parent.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            renderer.enabled = false;
        }
        foreach (MeshRenderer renderer in transform.parent.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = false;
        }
        turtle = Instantiate(turtle, null);
        Quaternion rotation = transform.parent.rotation;
        transform.parent.rotation = new Quaternion(0, 0, 0, 0);
        turtle.transform.localScale *= transform.parent.GetComponent<Collider>().bounds.size.magnitude / 2;
        turtle.transform.localPosition = new Vector3(0, 0.1f, 0);
        turtle.transform.position = transform.position;
        var emptyObject = new GameObject();
        emptyObject.transform.parent = transform;
        transform.parent.rotation = rotation;
        turtle.transform.parent = emptyObject.transform;


        player = transform.root.GetComponentInChildren<PlayerController>();
        if (player)
        {
            player.canCast = false;
        }
        else
        {
            transform.parent.GetComponent<Collider>().enabled = false;
        }
        base.Start();
    }

    public override void Die()
    {
        foreach (SkinnedMeshRenderer renderer in transform.parent.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            renderer.enabled = true;
        }
        foreach (MeshRenderer renderer in transform.parent.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = true;
        }
        if (player)
        {
            player.canCast = true;
        }
        else
        {
            transform.parent.GetComponent<Collider>().enabled = true;
        }
        Destroy(turtle);
        base.Die();
    }

}