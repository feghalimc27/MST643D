using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {

    public float health, speed;
    public float damage;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.SendMessage("TakeDamage", damage);
        }
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        if (health <= 0) {
            Object.Destroy(gameObject);
        }
	}

    public void TakeDamage(float damage) {
        health -= damage;
    }
}
