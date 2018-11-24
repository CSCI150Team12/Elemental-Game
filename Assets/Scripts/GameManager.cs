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
        // Load volume settings
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Debug.Log("HasMKEY");
            audioMixer.SetFloat("MusicFaderVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            Debug.Log("HasSKEY");
            audioMixer.SetFloat("SFXFaderVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }

        if (PlayerPrefs.HasKey("UIVolume"))
        {
            Debug.Log("HasUKEY");
            audioMixer.SetFloat("UIFaderVolume", PlayerPrefs.GetFloat("UIVolume"));
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