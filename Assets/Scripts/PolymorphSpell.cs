using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphSpell : Spell {


    // NOTICE: Can only have 1 Polymorph Spell per game!!!! 
    // BUG: Second Polymorph isnt displayed because gameobject is destroyed.
    // NOTICE: duration=death delay +1 = lifespan +1

    public float duration;  // The duration the player will remain morphed
    private PlayerController PC;
    private PlayerController TurtlePC;
    private bool HIT;
    private SkinnedMeshRenderer Target;
    private CapsuleCollider Target1;
    private Rigidbody Target2;
    private SkinnedMeshRenderer TurtleTarget;
    public GameObject TransformationObject;
    private Transform TargetLocation;
    private float HealthHolder;

    public override void Initialize()
    {
        base.Initialize();
        started = false;
        StartCoroutine(FreezeBody());
    }

    protected override void OnTriggerEnter(Collider other)
    {

        
        if (started)
        {
            if (other.CompareTag("Player"))    // If the player touches the item, then activate!
            {
                


                PC = other.GetComponent<PlayerController>();  // Obtain "PlayerController", properties
                PC.moveSpeed = 1;
                HealthHolder = PC.damage;

                string holder = other.name; // Stores the name of the object it hit into holder
                HIT = true; // Becomes true, when spell hits a player.

                PC = other.GetComponent<PlayerController>();  // Obtain "PlayerController", properties

                Target = other.GetComponentInChildren<SkinnedMeshRenderer>();
                Target.enabled = false; // Makes player invisible

                Target2 = other.GetComponent<Rigidbody>();  // Removes gravity from invisible wizard
                Target2.useGravity = false;

                Target1 = other.GetComponent<CapsuleCollider>();    // Removes collider from wizard
                Target1.enabled = false;
                


                TurtlePC = TransformationObject.GetComponent<PlayerController>();   //Gets Turtles "PlayerController" properties
                TurtlePC.damage = HealthHolder;


                // Do this before turtle is spawned, otherwise wont give proper control
                if (holder == "Player2") // If target was Player2, then Player 2 becomes possessed
                    TurtlePC.playerNumber = 2;
                else if (holder == "Player1") // If target was Player1, then Player 1 becomes possessed
                    TurtlePC.playerNumber = 1;

                Instantiate(TransformationObject, transform.position, transform.rotation); // Get user location, spawns turtle
                TurtlePC.moveSpeed = 1;
                TurtlePC.damage = HealthHolder;// Moves wizards health to turtle

            }
            base.OnTriggerEnter(other); // Use for particle effect
            transform.Find("Body").GetComponent<ParticleSystem>().Play();
            SetVelocity(Vector3.zero);
            Die();
        }
    }

    private IEnumerator FreezeBody()
    {
        yield return new WaitForSeconds(0.01f);
        transform.Find("Body").GetComponent<ParticleSystem>().Pause();
        started = true;
    }

    private void Update()
    {
        duration -= Time.deltaTime;     // Decrement duration down to 0
        if (duration <= 0)
        {
           // PC.damage = HealthHolder;   // Moves turtles health back to wizard
            Target.enabled = true;      // Makes player visible
            Target2.useGravity = true;  // Gives gravity back to wizard
            Target1.enabled = true;     //Enables collision for wizard
            PC.moveSpeed = 5;           // Put movespeed back to normal
            GlobalVariables.TurtleActive = false;       // Destroys Turtle
 
        }   
        else
        {
           HealthHolder = TurtlePC.damage;
            //PC.damage = HealthHolder;
            PC.damage = HealthHolder;
            Debug.Log(HealthHolder);
        }
    } 
}