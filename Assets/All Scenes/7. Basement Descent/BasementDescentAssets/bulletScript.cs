using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    private float xFacing, yFacing;
    private Vector2 lastFacing;
    public float speed = 5;
	// Use this for initialization
	void Start () {

        xFacing = Input.GetAxis("HorizontalR");
        yFacing = -Input.GetAxis("VerticalR");

        lastFacing = new Vector2(speed * xFacing, speed * yFacing);

        GetComponent<Rigidbody2D>().velocity = lastFacing;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
