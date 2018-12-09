using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerDeath : MonoBehaviour {

    public Rigidbody p;
    public PlayerSpawner s;
    public TMP_Text livesUI;
    int playerLife = 3;

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
            livesUI.text = "Lives: 0";
            Debug.Log(playerLife);
        }
        else
        {
            p.velocity = Vector3.zero;
            s.SpawnPlayerCenter();
            playerLife--;
            livesUI.text = "Lives: " + (playerLife + 1);
        }
    }
}
