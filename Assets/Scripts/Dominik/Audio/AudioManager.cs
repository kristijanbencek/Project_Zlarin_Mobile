using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager:MonoBehaviour
{
    [SerializeField] AudioSource myAs;
    public AudioSources myAudioSource;

    public void PlayOneShot()
    {
        myAs.PlayOneShot(myAudioSource.buttonClip);
    }
}
