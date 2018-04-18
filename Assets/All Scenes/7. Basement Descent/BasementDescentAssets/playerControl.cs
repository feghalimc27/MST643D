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

        xFacing = -Input.GetAxis("HorizontalR");
        yFacing = -Input.GetAxis("VerticalR");

        if(yFacing > 0.3 || yFacing < -0.3 || xFacing > 0.3 || xFacing < -0.3)
                transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(xFacing, yFacing) * (180 / 3.14f)));
        
    }
}
