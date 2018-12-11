using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static bool notGameOver = true;
    public GameTimer gameTimer;
    public GameObject gameOverMenuUI;

    //
    void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
    }

    // Display game over screen
    public void GameOver() {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GetComponentInChildren<Button>().Select();
        notGameOver = false;
    }

    // Restart match
    public void Restart()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        notGameOver = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load 'Menu' scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        gameOverMenuUI.SetActive(false);
    }
}
