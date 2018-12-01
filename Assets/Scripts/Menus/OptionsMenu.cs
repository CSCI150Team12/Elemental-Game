using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject optionsMenuUI;
    public Dropdown graphicsDropdown;
    public Dropdown resolutionDropdown;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider uiSlider;
    public Resolution[] resolutions;
    public Toggle fullscreenToggle;
    public float musicVar;
    public float sfxVar;
    public float uiVar;
    public int graphicsVar;
    public int resolutionVar;
    public bool fullscreenVar;

    // Hide options menu
    public void HideOptions()
    {
        // Save settings
        PlayerPrefs.SetFloat("MusicVolume", musicVar);
        PlayerPrefs.SetFloat("SFXVolume", sfxVar);
        PlayerPrefs.SetFloat("UIVolume", uiVar);
        PlayerPrefs.SetInt("GraphicsQuality", graphicsVar);
        PlayerPrefs.SetInt("ResolutionSetting", resolutionVar);
        if (fullscreenVar)
        {
            PlayerPrefs.SetInt("FullscreenSetting", 1);

        }
        else
        {
            PlayerPrefs.SetInt("FullscreenSetting", 0);
        }

        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Set music volume
    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicFaderVolume", musicVolume);
        musicVar = musicVolume;
    }

    // Set SFX volume
    public void SetSFXVolume(float sfxVolume)
    {
        audioMixer.SetFloat("SFXFaderVolume", sfxVolume);
        sfxVar = sfxVolume;
    }

    // Set UI volume
    public void SetUIVolume(float uiVolume)
    {
        audioMixer.SetFloat("UIFaderVolume", uiVolume);
        uiVar = uiVolume;
    }

    // Set graphics quality
    public void SetGraphicsQuality(int graphicsQuality)
    {
        QualitySettings.SetQualityLevel(graphicsQuality);
        graphicsVar = graphicsQuality;
    }

    // Set screen resolution
    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width,
                             resolutions[resolutionIndex].height,
                             Screen.fullScreen);
        resolutionVar = resolutionIndex;
    }

    // Set fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        fullscreenVar = isFullscreen;
    }

    // Show options menu
    public void ShowOptions()
    {
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Use this for initialization
    void Start()
    {
        // Load music volume settings
        musicVar = PlayerPrefs.GetFloat("MusicVolume");
        audioMixer.SetFloat("MusicFaderVolume", musicVar);
        musicSlider.value = musicVar;

        // Load SFX volume settings
        sfxVar = PlayerPrefs.GetFloat("SFXVolume");
        audioMixer.SetFloat("SFXFaderVolume", sfxVar);
        sfxSlider.value = sfxVar;

        // Load UI volume settings
        uiVar = PlayerPrefs.GetFloat("UIVolume");
        audioMixer.SetFloat("UIFaderVolume", uiVar);
        uiSlider.value = uiVar;

        // Load graphics settings
        graphicsVar = PlayerPrefs.GetInt("GraphicsQuality");
        QualitySettings.SetQualityLevel(graphicsVar);
        graphicsDropdown.value = graphicsVar;
        graphicsDropdown.RefreshShownValue();

        // Load resolution settings
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionVar = PlayerPrefs.GetInt("ResolutionSetting");
        resolutionDropdown.value = resolutionVar;
        resolutionDropdown.RefreshShownValue();

        // Load fullscreen settings
        fullscreenVar = (PlayerPrefs.GetInt("FullscreenSetting") == 1) 
            ? true : false;
        fullscreenToggle.isOn = fullscreenVar;
    }
}