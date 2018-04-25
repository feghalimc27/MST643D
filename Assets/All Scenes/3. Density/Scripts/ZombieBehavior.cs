using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {

    public float health, speed;
    public float damage;
    public GameObject player;

    private int damageWait;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.SendMessage("TakeDamage", damage);
            damageWait = 60;
        }
    }

    void OnCollisionStay(Collision col) {
        if (col.gameObject.tag == "Player") {
            if (damageWait == 0) {
                col.gameObject.SendMessage("TakeDamage", damage);
            }
            else {
                damageWait--;
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Player") {
            damageWait = 0;
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
