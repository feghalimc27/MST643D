using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraRotate : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Submit")) {
            transform.Rotate(Vector3.up * speed * 3 * Time.deltaTime);
        }
        else {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
