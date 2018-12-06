using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour {

    public GameObject panel;
    public GameInfo gameInfo;

    public void PlayGame(int players)
    {
        StartCoroutine("DelayTime");
        gameInfo.playerCount = players;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    IEnumerator DelayTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void Show()
    {
        panel.SetActive(true);
    }
}
