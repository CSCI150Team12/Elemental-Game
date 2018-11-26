using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Don't destroy 'ManagerObject' on load
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        // Load graphics settings
        if (PlayerPrefs.HasKey("GraphicsQuality"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));
        }
        else
        {
            QualitySettings.SetQualityLevel(3);
            PlayerPrefs.SetInt("GraphicsQuality", 3);
        }

        // Load volume settings
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            audioMixer.SetFloat("MusicFaderVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 0f);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            audioMixer.SetFloat("SFXFaderVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", 0f);
        }

        if (PlayerPrefs.HasKey("UIVolume"))
        {
            audioMixer.SetFloat("UIFaderVolume", PlayerPrefs.GetFloat("UIVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("UIVolume", 0f);
        }

        // Load main menu (next scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}