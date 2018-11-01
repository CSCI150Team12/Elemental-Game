using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour {

    public Rigidbody p;
    private int playerLife1 = 4;
    private int playerLife2 = 4;

    void FixedUpdate() {
        if (p.position.y < 0f) {
            Player1Life();
        }
        else if (p.position.y < 0f) {
            Player2Life();
        }
    }

    void Player1Life() {
        if (playerLife1 > 0) {
            FindObjectOfType<PlayerSpawner>().SpawnPlayer();
        }
        else {
            FindObjectOfType<GameOverMenu>().GameOver();
        }
    }

    void Player2Life() {
        if (playerLife2 > 0) {
            FindObjectOfType<PlayerSpawner>().SpawnPlayer();
        }
        else {
            FindObjectOfType<GameOverMenu>().GameOver();
        }
    }

}
