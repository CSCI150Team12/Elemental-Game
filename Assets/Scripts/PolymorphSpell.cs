﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphSpell : Spell {


    // NOTICE: Can only have 1 Polymorph Spell per game!!!! 
    // NOTICE: duration=death delay +1 = lifespan +1

    /**************LIST OF KNOWN BUGS**************
    // BUG: Second Polymorph isnt displayed because gameobject is destroyed.
    // BUG: Transformed wizard does not die immediatly, nor respawn
    // BUG: Transforming back into wizard, the wizard spawns in the original place
    ****************************************/

    public float duration;  // The duration the player will remain morphed
    private PlayerController PC, PC2;
    private PlayerController TurtlePC;
    private bool HIT;
    private SkinnedMeshRenderer Target;
    private CapsuleCollider Target1;
    private Rigidbody Target2;
    private Transform Target3, Target4;
    private SkinnedMeshRenderer TurtleTarget;
    public GameObject TransformationObject;
    public GameObject TransformationObject2;
    public GameObject TransformationObject3;
    private Transform TargetLocation;
    private float HealthHolder = 0f;
    private Vector3 CurrentPos;
    private string holder;
    private PlayerDeath DeathOriginal, DeathCopy;
    public PlayerSpawner s1, s2;


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
            if (other.CompareTag("Player"))    // If the player is hit, then activate!
            {
               
                PC = other.GetComponent<PlayerController>();  // Obtain "PlayerController", properties
                DeathOriginal = other.GetComponent<PlayerDeath>();
                PC.moveSpeed = 1;

                holder = other.name; // Stores the name of the object it hit into holder
                HIT = true; // Becomes true, when spell hits a player.


                TurtlePC = TransformationObject.GetComponent<PlayerController>();   //Gets Turtles "PlayerController" properties
                TurtlePC.damage = PC.damage;
                TurtlePC.damageUI = PC.damageUI;

                // Do this before turtle is spawned, otherwise wont give proper control
                if (holder == "Player2") // If target was Player2, then Player 2 becomes possessed
                {
                    TurtlePC.playerNumber = 2;
                    GlobalVariables.Player2Active = false;
                }
                else if (holder == "Player1") // If target was Player1, then Player 1 becomes possessed
                {
                    TurtlePC.playerNumber = 1;
                    GlobalVariables.Player1Active = false;
                }

                Instantiate(TransformationObject, transform.position, transform.rotation); // Get user location, spawns turtle
                TurtlePC.moveSpeed = 1;
                TurtlePC.damage = HealthHolder;// Moves wizards health to turtle


                CurrentPos = other.transform.position;


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
       
        if (duration <= 0 && HIT == true)
        {
            
           
            PC.moveSpeed = 5;           // Put movespeed back to normal
            GlobalVariables.TurtleActive = false;       // Destroys Turtle

            
            if (holder == "Player2") // If target was Player2, then Player 2 becomes possessed
            {
                Instantiate(TransformationObject2, transform.position, transform.rotation); // Get user location, spawns turtle
                PC2 = TransformationObject2.GetComponent<PlayerController>();
                DeathCopy = TransformationObject2.GetComponent<PlayerDeath>();

                
            }
            else if (holder == "Player1") // If target was Player1, then Player 1 becomes possessed
            {
                Instantiate(TransformationObject3, transform.position, transform.rotation); // Get user location, spawns turtle
                PC2 = TransformationObject3.GetComponent<PlayerController>();
                DeathCopy = TransformationObject2.GetComponent<PlayerDeath>();

            }
            PC2.damage = TurtlePC.damage;                       // Moves Damage over
            PC2.damageUI = TurtlePC.damageUI;                   // Moves damage UI over
            PC2.spellQueueUI = PC.spellQueueUI;                 // Moves Sqell Queue UI over
            DeathCopy.playerLife = DeathOriginal.playerLife;    // Moves the lives over
            
            HIT = false;
        }   
        else
        {
            TurtlePC.damage = GlobalVariables.TurtleHealth;

            PC.damage = TurtlePC.damage;
            GlobalVariables.TurtleHealth = PC.damage;

        }
        
    } 
}