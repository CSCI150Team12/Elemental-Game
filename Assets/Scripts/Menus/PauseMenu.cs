using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool optionsNotActive = true;
    public GameObject pauseMenuUI;
    public AudioSource gameMusic;

    // Update is called once per frame
    void Update()
    {
        // Show or hide pause menu if 'esc' key is pressed
        if ((Input.GetKeyDown(KeyCode.Escape) 
        || Input.GetKeyDown(KeyCode.Joystick1Button7)) 
            && (optionsNotActive 
        && (GameOverMenu.notGameOver && WinPlayer.noPlayerWon)))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        StartCoroutine(UnfreezePlayers());
        gameMusic.UnPause();
    }

    private IEnumerator UnfreezePlayers()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject.Find("Player1").GetComponent<PlayerController>().SetFrozen(false);
        GameObject.Find("Player2").GetComponent<PlayerController>().SetFrozen(false);
    }

    // Pause game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GetComponentsInChildren<Button>()[1].Select();
        GetComponentInChildren<Button>().Select();
        GameObject.Find("Player1").GetComponent<PlayerController>().SetFrozen(true);
        GameObject.Find("Player2").GetComponent<PlayerController>().SetFrozen(true);
        gameMusic.Pause();
    }

    // Restart game
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load 'Menu' scene
    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");

    }

    // Hide pause menu
    public void HidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        optionsNotActive = false;
    }

    // Show pause menu
    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        optionsNotActive = true;
        GetComponentInChildren<Button>().Select();
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}