using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleMark : MonoBehaviour {

    public GameObject candle;
    public GameObject candlePosition;
   // private Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LeaveCandle();
    }

    void LeaveCandle()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            //position = new Vector3((this.transform.position.x + mainCamera.transform.position.x) / 2, this.transform.position.y, (this.transform.position.z + mainCamera.transform.position.z) / 2);
            Instantiate(candle, candlePosition.transform.position, this.transform.rotation);
        }
    }
}
