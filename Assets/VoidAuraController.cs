using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidAuraController : MonoBehaviour
{

    GameObject player;
    GameObject ground;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("Player");
        ground = GameObject.Find("Walls");
        foreach (Collider collider in player.GetComponentsInChildren<Collider>())
        {
            foreach (Collider collider2 in ground.GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(collider, collider2, true);
            }
        }
    }
}
