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
    public int graphicsVar;
    public int resolutionVar;
    public bool fullscreenVar;
    public float musicVar;
    public float sfxVar;
    public float uiVar;

    // Hide options menu
    public void HideOptions()
    {
        // Save settings
        PlayerPrefs.SetInt("GraphicsQuality", graphicsVar);
        PlayerPrefs.SetFloat("MusicVolume", musicVar);
        PlayerPrefs.SetFloat("SFXVolume", sfxVar);
        PlayerPrefs.SetFloat("UIVolume", uiVar);

        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Set screen resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution screenResolution = resolutions[resolutionIndex];
        Screen.SetResolution(screenResolution.width, screenResolution.height,
                             Screen.fullScreen);
        //TD: Update variable
    }

    // Set fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        // TD: Update variable
    }

    // Set graphics quality
    public void SetGraphicsQuality(int graphicsQuality)
    {
        QualitySettings.SetQualityLevel(graphicsQuality);
        graphicsVar = graphicsQuality;
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

    // Show options menu
    public void ShowOptions()
    {
        optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;

        // Load graphics settings
        graphicsVar = PlayerPrefs.GetInt("GraphicsQuality");
        QualitySettings.SetQualityLevel(graphicsVar);
        graphicsDropdown.value = graphicsVar;
        graphicsDropdown.RefreshShownValue();

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
    }

    // Use this for initialization
    void Start()
    {
        // Load resolution settings
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionVar = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = resolutionVar;
        resolutionDropdown.RefreshShownValue();

        // Load fullscreen settings
        if (PlayerPrefs.GetInt("FullscreenSetting") == 1)
        {
            fullscreenVar = true;
        }
        else
        {
            fullscreenVar = false;
        }
        Screen.fullScreen = fullscreenVar;
        // TD: refresh toggle
    }

    // Update is called once per frame
    void Update()
    {

    }
}