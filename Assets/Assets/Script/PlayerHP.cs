using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HP {

    private float initialHight;

    // Use this for initialization
    void Start () {
        health = 100;
        initialHight = this.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        Death();
        FallToDeath();
        //print(health);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyFire"))
        {
            this.health -= 2;
        }

        if (other.CompareTag("Ghost"))
        {
            Destroy(other.gameObject);
            this.health -= 10;
        }
    }

    private void FallToDeath()
    {
        if (initialHight - this.transform.position.y > 10)
        {
            this.health = 0;
            Destroy(this.gameObject);
        }
    }
}
