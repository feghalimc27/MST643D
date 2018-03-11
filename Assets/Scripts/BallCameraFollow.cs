using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFollow : MonoBehaviour {

    public float distance;
    public GameObject character;

	// Use this for initialization
	void Start () {
		UpdatePosition();
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        //transform.LookAt(character.transform);

        Debug.Log("L/R: " + Input.GetAxisRaw("Horizontal") + " U/D: " + Input.GetAxisRaw("Vertical"));
    }

    void UpdatePosition() {
        float x = character.transform.position.x;
        float y = character.transform.position.y + distance / 2;
        float z = character.transform.position.z - distance;

		transform.position = new Vector3(x, transform.position.y, z);
    }
}
