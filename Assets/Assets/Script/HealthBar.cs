using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    private Image healthBar;
    //    private GameObject player;
    public GameObject player;
    private PlayerHP playerHealth;

    void Start () {
//        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHP>();
        healthBar = this.GetComponent<Image>();
	}
	
	void Update () {
        healthBar.fillAmount = playerHealth.GetHealth()/100;


        if (playerHealth.GetHealth() <= 0)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene("Maze");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Application.Quit();
            }
        }
    }

    private void OnGUI()
    {
        if (playerHealth.GetHealth() <= 0)
        {
            if (GUI.Button(new Rect(Screen.width / 2-150, Screen.height / 2, 300, 100), "Do you want to Continue? (Xbox: Press A)"))
            {
                SceneManager.LoadScene("Maze");
            }
            if (GUI.Button(new Rect(Screen.width / 2-150, Screen.height / 2+150, 300, 100), "Do you want to Quit? (Xbox: Press B)"))
            {
                Application.Quit();
            }
        }
    }

}
