using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {

    public float acceleration;
    public float torque;
    public float friction;
    public GameObject sphereTracker;

	// Use this for initialization
	void Start () {
        transform.GetComponent<Rigidbody>().maxAngularVelocity = 200;

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
        transform.GetChild(0).rotation = sphereTracker.transform.rotation;
        sphereTracker.transform.position = transform.position;
        sphereTracker.transform.Rotate(Vector3.up * 2.0f *  Input.GetAxis("Horizontal"), Space.World);
        transform.GetComponent<Rigidbody>().AddForce(sphereTracker.transform.forward * torque * Input.GetAxis("Vertical"), ForceMode.Acceleration);
        transform.GetComponent<Rigidbody>().AddForce(sphereTracker.transform.right * torque * Input.GetAxis("Horizontal"), ForceMode.Acceleration);
        //transform.GetComponent<Rigidbody>().AddTorque(Vector3.up * torque * Input.GetAxis("Horizontal"));
    }

    void ApplyFriction() {

    }
}
