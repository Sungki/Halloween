using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour {

    public float runSpeed = 7.0f;
    float mouseSensitivity = 1.0f;
    float gravity = 150f;

    public float maxLength;

    Transform myTransform;
    Transform model;
    Transform modelRig;

    CharacterController cc;

    Vector3 mouseMove;
    Vector3 move;
    Vector3 direction;
    Quaternion rotation;

    Transform cameraParentTransform;
    Transform cameraTransform;

    public PlayAni2 rotateToMouse;
    public Transform firePoint;

    public GameObject playerBullet;

    bool isShoot = true;
    float shootTimer = 0f;
    float shootDelay = 0.5f;

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;

    void Start()
    {
        move = Vector3.zero;
        myTransform = transform;
        cc = GetComponent<CharacterController>();
        model = transform.GetChild(0);
        modelRig = model.GetChild(0);
        cameraTransform = Camera.main.transform;
        cameraParentTransform = cameraTransform.parent;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //        Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 inputMoveXZ = new Vector3(x, 0, z);

        float inputMoveXZMgnitude = inputMoveXZ.sqrMagnitude;

        inputMoveXZ = myTransform.TransformDirection(inputMoveXZ);
        if (inputMoveXZMgnitude <= 1)
            inputMoveXZ *= runSpeed;
        else
            inputMoveXZ = inputMoveXZ.normalized * runSpeed;

        //        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        if (x == 0 && z == 0)
        {
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMgnitude) * runSpeed);
        }
        else
        {
            Quaternion cameraRotation = cameraTransform.rotation;
            cameraRotation.x = cameraRotation.z = 0;
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);
            if (move != Vector3.zero)
            {
                Quaternion characterRotation = Quaternion.LookRotation(-move);
                characterRotation.x = characterRotation.z = 0;
//                model.rotation = Quaternion.Slerp(model.rotation, characterRotation, 10.0f * Time.deltaTime);
                modelRig.rotation = Quaternion.Slerp(modelRig.rotation, characterRotation, 10.0f * Time.deltaTime);
            }

            move = Vector3.MoveTowards(move, inputMoveXZ, runSpeed);
        }
        //        }
        //        else
        //        {
        //            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMgnitude) * runSpeed);
        //            move = Vector3.MoveTowards(move, Vector3.zero, runSpeed);
        //        }


//        modelRig.rotation = Quaternion.Euler(0,Time.time*100, 0);

        if (!cc.isGrounded)
        {
            move.y -= gravity * Time.deltaTime;
        }

        cc.Move(move * Time.deltaTime);

        CameraMove();

        ShootControl();
    }

    void ShootControl()
    {
        if (isShoot)
        {
            if (shootTimer > shootDelay && (Input.GetButtonDown("Fire1") || Input.GetAxisRaw("RightTrigger") > 0))
            {
                Instantiate(playerBullet, firePoint.position, rotateToMouse.GetRotation());
                audio.PlayOneShot(SoundToPlay, Volume);
                shootTimer = 0;
            }
            shootTimer += Time.deltaTime;
        }
    }

    void CameraMove()
    {
        cameraParentTransform.position = myTransform.position + Vector3.up * 0.5f;
        mouseMove += new Vector3(-Input.GetAxisRaw("Mouse Y") * mouseSensitivity, Input.GetAxisRaw("Mouse X") * mouseSensitivity, 0);
        mouseMove += new Vector3(Input.GetAxisRaw("rVertical") * mouseSensitivity, Input.GetAxisRaw("rHorizontal") * mouseSensitivity, 0);
        if (mouseMove.x < -30)
            mouseMove.x = -30;
        else if (30 < mouseMove.x)
            mouseMove.x = 30;

        cameraParentTransform.localEulerAngles = mouseMove;
    }
}
