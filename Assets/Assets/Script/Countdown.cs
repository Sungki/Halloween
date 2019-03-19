using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Count(float startTime)
    {
        if ((Time.time - startTime) < 10)
        {
            this.GetComponent<Image>().enabled = true;
            this.GetComponent<Image>().fillAmount = (10 - (Time.time - startTime)) / 10;
        }
        if ((Time.time - startTime) >= 10)
        {
            this.GetComponent<Image>().enabled = false;
        }
    }
}
