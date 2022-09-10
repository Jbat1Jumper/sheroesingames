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

    public void PlayDrop()
    {
        DropSound.Play();
    }
}
