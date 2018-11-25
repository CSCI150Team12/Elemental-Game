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
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider uiSlider;
    public int graphicsVar;
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

        // Load volume settings
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVar = PlayerPrefs.GetFloat("MusicVolume");
            audioMixer.SetFloat("MusicFaderVolume", musicVar);
            musicSlider.value = musicVar;
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVar = PlayerPrefs.GetFloat("SFXVolume");
            audioMixer.SetFloat("SFXFaderVolume", sfxVar);
            sfxSlider.value = sfxVar;
        }

        if (PlayerPrefs.HasKey("UIVolume"))
        {
            uiVar = PlayerPrefs.GetFloat("UIVolume");
            audioMixer.SetFloat("UIFaderVolume", uiVar);
            uiSlider.value = uiVar;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}