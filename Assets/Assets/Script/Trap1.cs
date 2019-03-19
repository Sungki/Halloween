using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    public GameObject trapObject;
    public GameObject trapObject1;
    Animation anim;
    Animation anim1;

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;

    private void Start()
    {
        anim = trapObject.GetComponent<Animation>();
        anim1 = trapObject1.GetComponent<Animation>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision co)
    {
        anim.Play(); anim1.Play();
        audio.PlayOneShot(SoundToPlay, Volume);
    }
}
