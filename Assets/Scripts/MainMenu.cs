using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenuUI;

    // Start game
    public void PlayGame()
    {
        // Load 'Game' scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    // Hide main menu
    public void HideMainMenu()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Show main menu
    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Quit game
    public void QuitGame()
    {

        Debug.Log("QUIT!");
        Application.Quit();
    }
}