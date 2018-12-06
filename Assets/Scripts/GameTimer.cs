using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour {

    public GameOverMenu gameOver;
    public float timeLeft = 5f;
    private TMP_Text timer;

    void Awake() {
        timer = GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.GetComponent<TMP_Text>().text = Mathf.Round(timeLeft).ToString();

        if (timeLeft < 0) {
            Time.timeScale = 0f;
            gameOver.GameOver();
        }
	}
}
