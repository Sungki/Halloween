using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour {

    public Camera cam;
    public float maximum;
    public Transform firePoint;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    public Texture2D aim;
    Rect aimRect;
    Vector3 mousePos;
    bool isXboxcon = false;

    Animation anim;

    private void Start()
    {
        float left = (Screen.width - aim.width) / 2;
        float top = (Screen.height - aim.height) / 2;
        aimRect = new Rect(left, top, aim.width, aim.height);
        mousePos = new Vector3(Screen.width/2, (Screen.height/2)+10.0f);
        anim = GetComponent<Animation>();
//        anim["Take 001"].wrapMode = WrapMode.Loop;
    }

    void Update()
    {
        if (cam != null)
        {
            //            RaycastHit hit;
            if ((Input.GetAxisRaw("rHorizontal") > 0)&&!isXboxcon)
            {
                isXboxcon = true;
                mousePos = new Vector3(Screen.width / 2, (Screen.height / 2)+10.0f);
            }
            if (!isXboxcon)
            {
                mousePos = Input.mousePosition;
            }

            rayMouse = cam.ScreenPointToRay(mousePos);
            Debug.DrawRay(firePoint.position, rayMouse.direction * 10, Color.red);

            rotation = Quaternion.LookRotation(rayMouse.direction);
            
            /*            if (Physics.Raycast(firePoint.position, rayMouse.direction, out hit, maximum))
                        {
                            RotateToMouseDirection(gameObject, hit.point);
                        }
                        else
                        {
                            var pos = rayMouse.GetPoint(maximum);
                            RotateToMouseDirection(gameObject, pos);
                        }*/
        }
        else
        {
            Debug.Log("No Camera");
        }
    }

    private void OnGUI()
    {
        if(isXboxcon)
            GUI.DrawTexture(aimRect, aim);
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;

        //        if (direction.z < 1.5) direction.z = 8;
        rotation = Quaternion.LookRotation(direction);
//        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}