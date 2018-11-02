using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour {

    public Rigidbody p;
    public bool playerOnMap = true;
    private int playerLife1 = 3;
    //private int playerLife2 = 4;

    void FixedUpdate() {
        if (p.position.y < -2f) {
            playerOnMap = false;
            Player1Life();
        }
    }


    void Player1Life()
    {
        if (playerOnMap == false)
        {
            if (playerLife1 < 1)
            {
                FindObjectOfType<GameOverMenu>().GameOver();
            }
            else
            {
                FindObjectOfType<PlayerSpawner>().SpawnPlayer();
                playerOnMap = true;
                playerLife1--;
            }
        }
    }

}
