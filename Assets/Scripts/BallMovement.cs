using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

    public float acceleration;
    public float friction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate() {
        AccelerateBall();
    }

    void AccelerateBall() {
        GetComponent<Rigidbody>().AddForce(acceleration * Input.GetAxis("Horizontal"), 0, acceleration * Input.GetAxis("Vertical"));
    }

    void ApplyFriction() {

    }
}
