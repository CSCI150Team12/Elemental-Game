using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

    public GameObject optionsMenuUI;

    // Go back to main menu
    public void goBack()
    {
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Show options menu
    public void showOptions()
    {
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
