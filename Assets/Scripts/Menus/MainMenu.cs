using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenuUI;

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
        GetComponentInChildren<Button>().Select();
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}