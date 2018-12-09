using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenuUI;

    // Load 'Game' scene
    public void PlayGame()
    {
        StartCoroutine("DelayTime");
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    // 
    IEnumerator DelayTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
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
        Application.Quit();
    }
}