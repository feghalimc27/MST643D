using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFollow : MonoBehaviour {

    public float distance;
    public GameObject character;
	[HideInInspector]
	public bool look;

	private CameraControllerFollower parent;

	// Use this for initialization
	void Start () {
		//UpdatePosition();
		parent = GetComponentInParent<CameraControllerFollower>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //UpdatePosition();
        //transform.LookAt(character.transform);
		SwitchCamera();
    }

    /*void UpdatePosition() {
        float x = character.transform.position.x;
        float y = character.transform.position.y + distance / 2;
        float z = character.transform.position.z - distance;

		transform.position = new Vector3(x, transform.position.y, z);
    }*/

	void SwitchCamera() {
		if (parent.lookAtBall) {
			transform.LookAt(character.transform);
			look = true;
		}
	}
}
