using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public AudioSource Button;
    public AudioClip hoverButtonSFX;
    public AudioClip clickButtonSFX;

    // Play button sound
    public void PlayButton()
    {
        Button.Play();
    }

    // Play hover over button sound
    public void HoverSound()
    {
        Button.PlayOneShot(hoverButtonSFX);
    }

    // Play click on button sound
    public void ClickSound()
    {
        Button.PlayOneShot(clickButtonSFX);
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