using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

    public float health;
    public bool isDead;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death()
    {
        if (health <= 0)
        {
            this.GetComponentInParent<AudioSource>().enabled = false;
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
            isDead = true;
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
