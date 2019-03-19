using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Dictionary<string, int> inventory;
    public float healthPlus = 35;
    public Text greenNumber;
    public Text orangeNumber;
    public Text whiteNumber;

    private float time;
    private bool invincible;
    private bool ghostified;
    private float currentHealth;
    private GameObject wall;
    private float initialHight;

    // Use this for initialization
    void Start () {
        inventory = new Dictionary<string, int>();
        inventory.Add("Green", 1);
        inventory.Add("Orange", 0);
        inventory.Add("White", 0);

        time = Time.time;
        invincible = false;
        ghostified = false;
    }
	
	// Update is called once per frame
	void Update () {

        TrackInventory();
        ConsumeGreen();
        ConsumeOrange();
        ConsumeWhite();
        //StuckToDeath();
        //Debug.Log(playerHP);
       //Debug.Log(ghostified);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            inventory["Green"] += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Orange"))
        {
            inventory["Orange"] += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("White"))
        {
            inventory["White"] += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (ghostified && hit.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Hit");
            initialHight = this.transform.position.y;
            wall = hit.gameObject;
            wall.GetComponent<BoxCollider>().enabled = false;
        }
        else if (wall != null && !ghostified)
        {
            //Debug.Log(ghostified);
            wall.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void ConsumeGreen()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.JoystickButton2)) && inventory["Green"] > 0)
        {
            inventory["Green"] -= 1;
            if (this.GetComponent<PlayerHP>().health <= (100 - healthPlus))
            {
                //Debug.Log("less than 65");
                this.GetComponent<PlayerHP>().health += healthPlus;
            }
            else
            {
                //Debug.Log("more than 65");
                this.GetComponent<PlayerHP>().health = 100;
            }
        }
    }

    private void ConsumeOrange()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.JoystickButton3)) && inventory["Orange"] > 0)
        {
            time = Time.time;
            inventory["Orange"] -= 1;
            invincible = true;
            currentHealth = this.GetComponent<PlayerHP>().health;
        }
        if (Time.time - time <= 10 && invincible)
        {
            this.GetComponent<PlayerAni>().runSpeed = 30;
            this.GetComponent<PlayerHP>().health = currentHealth;
        }
        else
        {
            this.GetComponent<PlayerAni>().runSpeed = 7;
            invincible = false;
        }
    }

    private void ConsumeWhite()
    {
        if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.JoystickButton1)) && inventory["White"] > 0)
        {
            inventory["White"] -= 1;
            time = Time.time;
            ghostified = true;
        }
        if (Time.time - time <= 10 && ghostified)
        {
            this.GetComponent<CharacterController>().detectCollisions = false; //A "bug" exists. While ghostified, you cannot collect items
        }
        else
        {
            this.GetComponent<CharacterController>().detectCollisions = true;
            ghostified = false;
        }
    }

    private void TrackInventory()
    {
        greenNumber.text = "x" + inventory["Green"];
        orangeNumber.text = "x" + inventory["Orange"];
        whiteNumber.text = "x" + inventory["White"];
    }

   /* private void StuckToDeath()
    {
        if (this.transform.position.y - initialHight > 2.5)
        {
            Destroy(this.gameObject);
        }
    }*/
}
