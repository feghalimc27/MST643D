using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GroundTiltControl : MonoBehaviour {

    public float tiltAngle;

    private Vector2 planeTilt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TiltControl();
	}

    void TiltControl() {
        Vector2 tilt = new Vector2(Input.GetAxis("Horizontal") * tiltAngle, Input.GetAxis("Vertical") * tiltAngle);

        planeTilt.y = Mathf.Clamp(tilt.y, -tiltAngle, tiltAngle);
        planeTilt.x = Mathf.Clamp(tilt.x, -tiltAngle, tiltAngle);

        transform.localRotation = Quaternion.AngleAxis(tilt.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(tilt.x, Vector3.back);
    }
}
