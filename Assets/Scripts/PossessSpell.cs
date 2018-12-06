using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessSpell : Spell
{
    // NOTICE: duration=death delay +1 = lifespan +1
    public float duration;  // The duration the player will remain possessed
    private PlayerController PC;
    private bool HIT;

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
                HIT = true;                         // Becomes true, when spell hit a player.
                PC = other.GetComponent<PlayerController>();  // Obtain "PlayerController", properties

                string holder = other.name; // Stores the name of the object it hit into holder

                if (holder == "Player2") // If target was Player2, then Player 2 becomes possessed
                    PC.playerNumber = 1;
                else if (holder == "Player1") // If target was Player1, then Player 1 becomes possessed
                    PC.playerNumber = 2;
            }
            base.OnTriggerEnter(other);
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
        if (HIT == true)
        {
            if (duration <= 0)
            {
                if (PC.playerNumber == 1)                 // Gives control back to the possessed user
                {
                    PC.playerNumber = 2;
                    HIT = false;                        // Changed to false, so that it doesnt change more than once.
                }
                else if (PC.playerNumber == 2)
                {
                    PC.playerNumber = 1;
                    HIT = false;                        // Changed to false, so that it doesnt change more than once.
                }
                    Debug.Log(PC.playerNumber);
            }
            else
            {
                duration -= Time.deltaTime;             // Decrements duration down to 0
            }
        }
    }
    
}
