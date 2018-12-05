using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public GameTimer gameTimer;
    public GameObject gameOverMenuUI;

    void Awake() {
        gameTimer = GetComponent<GameTimer>();
    }

    public void GameOver() {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        gameOverMenuUI.SetActive(false);
    }
}
