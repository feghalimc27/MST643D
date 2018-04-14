using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public float xMove, yMove, xFacing, yFacing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (xMove != 100 || yMove != 100)
        {
            if (Input.GetAxis("Horizontal") > 0)
                xMove++;
            if (Input.GetAxis("Horizontal") < 0)
                xMove--;
            if (Input.GetAxis("Vertical") > 0)
                yMove++;
            if (Input.GetAxis("Vertical") < 0)
                yMove--;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (xMove == 0)
            { }
            if (xMove > 0)
                xMove = xMove - 5;
            if (xMove < 0)
                xMove = xMove + 5;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            if (yMove == 0)
            { }
            if (yMove > 0)
                yMove = yMove - 5;
            if (yMove < 0)
                yMove = yMove + 5;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2((xMove/25), (yMove/25));
    }
}
