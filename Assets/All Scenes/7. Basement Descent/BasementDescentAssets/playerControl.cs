using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    private float xMove, yMove, xFacing, yFacing;
    public float speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        
        GetComponent<Rigidbody2D>().velocity = new Vector2((xMove*speed), (yMove*speed));

        //xFacing = Input.GetAxis("HorizontalR");
        // yFacing = Input.GetAxis("VerticalR");
        Vector3 faceDirection = new Vector3(Input.GetAxis("HorizontalR"), Input.GetAxis("VerticalR"), 0);

        transform.LookAt(transform.position + faceDirection);
    }
}
