using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource PickUpSound;
    public AudioSource DropSound;


    public void PlayPickUp()
    {
        PickUpSound.Play();
    }

    public void PlayDropDown()
    {
        DropSound.Play();
    }

    public void PlaySwipeLeft()
    {
        DropSound.Play();
    }

    public void PlaySwipeRight()
    {
        DropSound.Play();
    }

    public void PlayPreviewLeft()
    {
    }

    public void PlayPreviewRight()
    {
    }
}
