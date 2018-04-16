using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

    public float acceleration;
    public float torque;
    public float friction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }


    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.name == "End")
        {
            DontDestroyOnLoad(new GameObject("levelCompleted"));
        }
    }

    void FixedUpdate() {
        AccelerateBall();
    }

    void AccelerateBall() {
        //transform.GetChild(0).position = transform.position;
        //transform.rotation = transform.GetChild(0).rotation;
        transform.GetComponent<Rigidbody>().AddForce(transform.GetChild(0).forward.x * acceleration * Input.GetAxis("Horizontal"), 0, transform.GetChild(0).forward.z * acceleration * Input.GetAxis("Vertical"));
        transform.GetComponent<Rigidbody>().AddTorque(transform.GetChild(0).up * torque * Input.GetAxis("Horizontal"));
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.GetChild(0).forward.x * acceleration * Input.GetAxis("Horizontal"), 0, transform.GetChild(0).forward.z * acceleration * Input.GetAxis("Vertical"));
        transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(transform.GetChild(0).up * torque * Input.GetAxis("Horizontal"));
    }

    void ApplyFriction() {

    }
}
