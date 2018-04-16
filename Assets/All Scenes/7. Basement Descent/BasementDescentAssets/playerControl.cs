using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    private float xMove, yMove, xFacing, yFacing;
    private Vector2 moveVector;
    public float speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        moveVector = new Vector2(xMove * speed, yMove * speed);
        
        GetComponent<Rigidbody2D>().velocity = moveVector;

        xFacing = Input.GetAxis("HorizontalR");
        yFacing = Input.GetAxis("VerticalR");

        transform.LookAt(transform.position, moveVector);
        
    }
}
