using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBlock : MonoBehaviour {

	public bool blocked = false;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.layer == 9) {
			blocked = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.layer == 9) {
			blocked = false;
		}	
	}

	// Update is called once per frame
	void Update () {

    }
}
