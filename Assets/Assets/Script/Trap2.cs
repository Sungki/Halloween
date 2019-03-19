using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour {

    Animation anim;
    public GameObject trapObject;
    bool alreadyPlayed = false;

    void Start () {
        anim = trapObject.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!alreadyPlayed)
            {
                anim.Play();
                alreadyPlayed = true;
            }
        }
    }
}
