using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxTilt : MonoBehaviour {

	public Camera mainCamera;

	private bool look = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		look = mainCamera.GetComponent<BallCameraFollow>().look;
		if (look) {
			transform.rotation = mainCamera.transform.rotation;
		}
	}
}
