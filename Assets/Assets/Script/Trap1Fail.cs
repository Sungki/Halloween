using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1Fail : MonoBehaviour
{
    public GameObject movePlayer;

    Transform playerTransform;

    private void Start()
    {
        playerTransform = movePlayer.transform;
    }

    void OnCollisionEnter(Collision co)
    {
        playerTransform.position += new Vector3(0, 0, 5);
    }
}
