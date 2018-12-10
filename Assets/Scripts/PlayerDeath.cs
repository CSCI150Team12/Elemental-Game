using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour {

    public Rigidbody p;
    public PlayerSpawner s;
    // int playerLife = 3;
    public int playerLife;  // Made it public for Collectables

    void FixedUpdate() {
        if (p.position.y < -1f) {
            Debug.Log(playerLife);
            PlayerLife();
        }
    }
    
    void PlayerLife()
    {
        if (playerLife < 1)
        {
            FindObjectOfType<GameOverMenu>().GameOver();
            Debug.Log(playerLife);
        }
        else
        {
            p.velocity = Vector3.zero;
            s.SpawnPlayerCenter();
            playerLife--;
        }
    }
}
