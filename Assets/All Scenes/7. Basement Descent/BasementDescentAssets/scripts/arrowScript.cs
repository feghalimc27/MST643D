using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {

    public float speed = 5;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
      GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Enemy" && collider.tag != "Obstacle")
        {
            Object.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
