using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerDeath : MonoBehaviour {

    public Rigidbody p; 
    public PlayerSpawner s;
    int playerLife = 3;
    public string name;
    public TMP_Text lives;
    public GameObject other;

    void Awake() {
    }

    void FixedUpdate() {
        if (p.position.y < -3f) {
            PlayerLife();
        }
        lives.GetComponent<TMP_Text>().text = playerLife.ToString();
    }

    void PlayerLife()
    {
        if (playerLife == 1) {
            playerLife--;
            int winner = 0;
            if (p.name == "Player1") {
                winner = 2;
            } else if (p.name == "Player2") { 
                winner = 1;
            }
            FindObjectOfType<WinPlayer>().PlayerWon(winner);
        }
        else
        {
            p.velocity = Vector3.zero;                                  // stop player momentum from continuing after death 
            if(p.GetComponentInChildren<SpellEffect>()) {               // kill any damage overtime spell affect
                p.GetComponentInChildren<SpellEffect>().Die();
            }
            p.GetComponent<PlayerController>().damage = 0f;             // set player damage to 0
            p.GetComponent<PlayerController>().damageUI.value = 0f;     // set the player UI damage to 0
            s.SpawnPlayerCenter();                                      // respawn player at center of the arena
            playerLife--;                                               // decrement the player life

        }
    }
}
