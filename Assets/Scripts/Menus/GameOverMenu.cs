using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameTimer gameTimer;
    public GameObject gameOverMenuUI;

    //
    void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
    }

    //Show 'game over' screen
    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Start new game
    public void Restart()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
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