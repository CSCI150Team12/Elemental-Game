using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Button management class for the main menu scene
public class MainMenu : MonoBehaviour {
    // Play game button function
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the game scene
        Time.timeScale = 1f;                                                  // Unpauses the game 
    }
    // Quit button function
    public void QuitGame() {

        Debug.Log("QUIT!");
        Application.Quit(); // Quits the application
    }
}
