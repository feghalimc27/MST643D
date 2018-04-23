using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlock : MonoBehaviour {

    public bool blocked = false;
    public bool canAttack = false;
    public GameObject player = null;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.layer == 9 || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") {
            blocked = true;
        }

        if (collision.gameObject.tag == "Player") {
            canAttack = true;
            player = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 9 || collision.gameObject.tag == "Player") {
            blocked = false;
        }

        if (collision.gameObject.tag == "Player") {
            canAttack = false;
            player = collision.gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
