using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitPopup : MonoBehaviour {

    bool alreadyPlayed;
    public GameObject player;

    void Start()
    {
        alreadyPlayed = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            alreadyPlayed = true;
        }
    }

    void Update()
    {
        if(alreadyPlayed)
        {
            Destroy(player);
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
        if (alreadyPlayed)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 50), "Congratulation!!!");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to Continue? (Xbox: Press A)"))
            {
                SceneManager.LoadScene("Maze");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to Quit? (Xbox: Press B)"))
            {
                Application.Quit();
            }
        }
    }

}
