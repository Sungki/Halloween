using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;

    CharacterController player;
    private Vector3 moveDirection = Vector3.zero;
    

    // Use this for initialization
    void Start () {
        player = this.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        player.Move(moveDirection * Time.deltaTime * speed);
    }
}
