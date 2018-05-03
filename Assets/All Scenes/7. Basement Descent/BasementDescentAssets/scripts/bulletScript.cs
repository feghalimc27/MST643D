using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public float speed = 5;
    private float xFacing, yFacing;
	// Use this for initialization
	void Start () {
        
        xFacing = Input.GetAxis("HorizontalR");
        yFacing = -Input.GetAxis("VerticalR");

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * xFacing, speed * yFacing);
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.name != "player")
        {
            Object.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
