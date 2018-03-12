using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerFollower : MonoBehaviour {

	public GameObject character;

	[HideInInspector]
	public bool lookAtBall;

	[SerializeField]
	private float fallingDistance = 100;

	// Use this for initialization
	void Start () {
		lookAtBall = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > -fallingDistance) {
			transform.position = character.transform.position;
		}
		else {
			transform.position = new Vector3(transform.position.x, -fallingDistance, transform.position.z);
			lookAtBall = true;
		}
	}
}
