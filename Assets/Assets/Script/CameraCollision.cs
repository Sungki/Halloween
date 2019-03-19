using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public float minDistance = 0.2f;
    public float maxDistance = 4.0f;
    public float smooth = 5.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

	void Awake() {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
	}
	
	void Update () {
        Vector3 desiredCameraPos = transform.TransformPoint(dollyDir * distance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit)) {
              distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime*smooth);
    }
}
