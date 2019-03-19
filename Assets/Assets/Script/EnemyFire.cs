using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public float speed;
    public float fireRange;

    private Vector3 startPosition;
    private float distance;
    private bool hitObstacle = false;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Use transform.forward to move in a local perspective.
        transform.position += this.transform.forward * Time.deltaTime * speed;
        distance = Vector3.Distance(this.transform.position, startPosition);

        if (distance >= fireRange)
        {
            Destroy(this.gameObject);
        }

        //Fire is cancelled if hits obsticles
        if (hitObstacle)
        {
            Destroy(this.gameObject);
        }

        //Debug.Log(hitObstacle);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");
        if (other.CompareTag("Obstacle") || other.CompareTag("Player") || other.CompareTag("Ground")) //All the walls, stands, stairs should be tagged as "Obstacle". They also need a rigidbody so that CompareTag can work...╮（╯＿╰）╭
        {
            //Debug.Log("Obstacle");
            hitObstacle = true;
        }else
        {
            hitObstacle = false;
        }
    }
}
