using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    private float lastTime;
    private bool lightningOn;
    private int count;
    private float interval;

    // Use this for initialization
    void Start () {
        this.GetComponent<Light>().enabled = false;
        lightningOn = true;
        interval = 10;
    }
	
	// Update is called once per frame
	void Update () {
        RandomLightning();
	}

   void RandomLightning()
    {
        float chance = Random.value;
/*        Debug.Log("chance: "+chance);
        Debug.Log("count: "+count);
        Debug.Log(lightningOn);
        Debug.Log("lasttime:"+lastTime);
        Debug.Log("time:" + Time.time);*/
        if (Time.time - lastTime >= 0.4)
        {
            this.GetComponent<Light>().enabled = false;
        }
        if (count >= 3)
        {
            lightningOn = false;
            count = 0;
            interval = Random.Range(10, 25);
        }
        if (Time.time - lastTime >= interval)
        {
            lightningOn = true;
        }
        if (lightningOn && chance < 0.2 && Time.time - lastTime >= 0.4)
        {
            this.GetComponent<Light>().enabled = true;
            lastTime = Time.time;
            count++;
        }
    }
}
