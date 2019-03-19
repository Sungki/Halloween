using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundSound : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
}
