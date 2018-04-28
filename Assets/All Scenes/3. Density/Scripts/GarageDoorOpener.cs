using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorOpener : MonoBehaviour {

	public float speed;
	private bool open = false;
	private Vector3 movePoint;

	// Use this for initialization
	void Start () {
		movePoint = transform.position;
		movePoint.y += 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (ZombieBehavior.objectiveAccomplished) {
			transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);
		}
	}
}
