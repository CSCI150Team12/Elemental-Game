using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject creditsUI;

    // Hide credits
    public void HideCredits()
    {
        creditsUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Show credits
    public void ShowCredits()
    {
        creditsUI.SetActive(true);
        Time.timeScale = 0f;
        GetComponentInChildren<Button>().Select();
    }
}