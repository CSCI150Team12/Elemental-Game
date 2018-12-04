using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource hoverSFX;
    public AudioSource clickSFX;

    // Play hover over button sound
    public void HoverSound()
    {
        hoverSFX.Play();
    }

    // Play click on button sound
    public void ClickSound()
    {
        clickSFX.Play();
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