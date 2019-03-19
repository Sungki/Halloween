using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour {

    public float speed;

    private Transform target;
 
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
            target = other.transform;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().Play(0);
        }
    }

}
