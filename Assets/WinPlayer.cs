using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPlayer : MonoBehaviour
{
    public static bool noPlayerWon = true;
    public GameObject playerWinMenuUI;
    public TMP_Text winner;

    //
    void Awake()
    {
        winner.GetComponent<TMP_Text>();
    }

    // Display player win screen
    public void PlayerWon(int w)
    {
        winner.GetComponent<TMP_Text>().text = "PLAYER " + w + " WINS!";
        playerWinMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GetComponentInChildren<Button>().Select();
        noPlayerWon = false;
    }

    // Restart match
    public void Restart()
    {
        playerWinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        noPlayerWon = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load 'Menu' scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        playerWinMenuUI.SetActive(false);
    }
}
