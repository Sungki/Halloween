using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHP : HP
{

    // Use this for initialization
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        //print(health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            this.health -= 5;
        }
    }
}
