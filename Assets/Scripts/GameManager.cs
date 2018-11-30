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
        // Load or create music volume setting
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            audioMixer.SetFloat("MusicFaderVolume", 
                                PlayerPrefs.GetFloat("MusicVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 0f);
        }

        // Load or create SFX volume setting
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            audioMixer.SetFloat("SFXFaderVolume", 
                                PlayerPrefs.GetFloat("SFXVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("SFXVolume", 0f);
        }

        // Load or create UI volume setting
        if (PlayerPrefs.HasKey("UIVolume"))
        {
            audioMixer.SetFloat("UIFaderVolume", 
                                PlayerPrefs.GetFloat("UIVolume"));
        }
        else
        {
            PlayerPrefs.SetFloat("UIVolume", 0f);
        }

        // Load or create graphics settings
        if (PlayerPrefs.HasKey("GraphicsQuality"))
        {
            QualitySettings.SetQualityLevel(
                PlayerPrefs.GetInt("GraphicsQuality"));
        }
        else
        {
            QualitySettings.SetQualityLevel(3);
            PlayerPrefs.SetInt("GraphicsQuality", 3);
        }

        // Load or create resolution setting
        Resolution[] resolutions = Screen.resolutions;
        if (PlayerPrefs.HasKey("ResolutionSetting"))
        {
            int i = PlayerPrefs.GetInt("ResolutionSetting");
            Screen.SetResolution(resolutions[i].width,
                             resolutions[i].height,
                             Screen.fullScreen);
        }
        else
        {
            int i = 0;
            while (resolutions[i].width != Screen.currentResolution.width || 
                   resolutions[i].height != Screen.currentResolution.height)
            {
                i++;
            }
            Screen.SetResolution(resolutions[i].width,
                             resolutions[i].height,
                             Screen.fullScreen);
            PlayerPrefs.SetInt("ResolutionSetting", i);
        }

        // Load or create fullscreen setting
        if (PlayerPrefs.HasKey("FullscreenSetting"))
        {
            Screen.fullScreen = (PlayerPrefs.GetInt("FullscreenSetting") == 1)
            ? true : false;
        }
        else
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("FullscreenSetting", 1);
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