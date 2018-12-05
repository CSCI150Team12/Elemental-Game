using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinPlayer : MonoBehaviour {
    public GameObject playerWinMenuUI;
    public TMP_Text winner;

    void Awake() {
        winner.GetComponent<TMP_Text>();
    }


    public void PlayerWon(int w)
    {
        winner.GetComponent<TMP_Text>().text = "PLAYER " + w + " WINS";
        playerWinMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        playerWinMenuUI.SetActive(false);
    }
}
