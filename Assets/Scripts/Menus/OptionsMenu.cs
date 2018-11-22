using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject optionsMenuUI;

    // Hide options menu
    public void HideOptions()
    {
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // Set music volume
    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicFaderVolume", musicVolume);
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}