using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    private float xFacing, yFacing;
    public float speed = 5;
	// Use this for initialization
	void Start () {

        xFacing = Input.GetAxis("HorizontalR");
        yFacing = -Input.GetAxis("VerticalR");

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed*xFacing, speed*yFacing);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
