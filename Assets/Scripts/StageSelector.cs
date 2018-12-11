using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{

    public GameObject stageSelectorUI;
    public Dropdown stageSelect;

    // Load stage selected
    public void PlayGame()
    {
        StartCoroutine("DelayTime");
        Time.timeScale = 1;
        SceneManager.LoadScene(stageSelect.options[stageSelect.value].text + " Stage");
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

    // Hide stage selector
    public void HideStageSelector()
    {
        stageSelectorUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Show stage selector
    public void ShowStageSelector()
    {
        stageSelectorUI.SetActive(true);
        Time.timeScale = 0f;
        GetComponentInChildren<Button>().Select();
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}