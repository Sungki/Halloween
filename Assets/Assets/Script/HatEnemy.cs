using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatEnemy : MonoBehaviour {

    public GameObject enemyFire;
    public float fireRate;

    private float lastFire = 0;
    private Vector3 fireDirection;
    private Vector3 enermyPosition;
    private Vector3 playerPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.LookAt(other.transform);
            Fire();
        }
    }

    void Fire()
    {
        if (Time.time >= fireRate + lastFire)
        {
            //Use this enemy's transform to initialize the transform of the fire so that when enemy change direction, the fire will follow.
            Instantiate(enemyFire, this.transform.position, this.transform.rotation); 
            //enemyFire.GetComponent<AudioSource>().Play(0);
            lastFire = Time.time;
        }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().Play(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }
}
