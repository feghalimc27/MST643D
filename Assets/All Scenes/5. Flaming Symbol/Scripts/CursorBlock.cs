using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBlock : MonoBehaviour {

	public bool blocked = false;
    public bool canAttack = false;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.layer == 9 || collision.gameObject.tag == "Enemy") {
			blocked = true;
		}

        if (collision.gameObject.tag == "Enemy") {
            canAttack = true;
        }
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.layer == 9 || collision.gameObject.tag == "Enemy") {
			blocked = false;
		}

        if (collision.gameObject.tag == "Enemy") {
            canAttack = false;
        }
    }

	// Update is called once per frame
	void Update () {

    }
}
