using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource PickUpSound;
    public AudioSource DropSound;
    public AudioSource Bg;
    public AudioSource BgAmbience;

    private float TargetAmbienceVolume = 0.6f;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Sounds").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this);
        }
    }

    // private SoundController GetSoundController()
    // {
    //     var soundControllers = ;
    //     if (soundControllers.Length > 1) {
    //         for (var i = 1; i < soundControllers.Length; i++) {
    //             Destroy()
    //         }
    //     }
    // }

    private void Update()
    {
        BgAmbience.volume = BgAmbience.volume * 0.9f + TargetAmbienceVolume * 0.1f;
    }

    public void EnteredMainScene()
    {
        Bg.Play();
        TargetAmbienceVolume = 0.1f;
    }

    public void LeftMainScene()
    {
        Bg.Stop();
        TargetAmbienceVolume = 0.6f;
    }

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
