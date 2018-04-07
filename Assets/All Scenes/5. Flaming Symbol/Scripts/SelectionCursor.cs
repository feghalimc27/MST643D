using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCursor : MonoBehaviour {

	public int movementCooldown;

	private float speed = 0.5f;
	private int coolCounter = 0;
	private GameObject player = null;
	private bool unitSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveCursor();
		SelectUnit();
		UpdateCounter();
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Why you such a weeb?");
			player = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log("This should store values");
			player = null;
		}
	}

	void MoveCursor() {
		Vector3 move = new Vector3(0, 0, 0);

		if (Input.GetAxis("Horizontal") > 0.2 && coolCounter == 0) {
			move.x += speed;

			coolCounter = movementCooldown;
		}
		else if (Input.GetAxis("Horizontal") < -0.2 && coolCounter == 0) {
			move.x -= speed;

			coolCounter = movementCooldown;
		}
		else if (Input.GetAxis("Vertical") > 0.2 && coolCounter == 0) {
			move.y += speed;

			coolCounter = movementCooldown;
		}
		else if (Input.GetAxis("Vertical") < -0.2 && coolCounter == 0) {
			move.y -= speed;

			coolCounter = movementCooldown;
		}

		transform.position += move;
		if (unitSelected) {
			player.transform.position += move;
		}
	}

	void SelectUnit() {
		if (player != null) {
			if (Input.GetButtonDown("Jump") && !unitSelected) {
				unitSelected = true;
			}
			else if (Input.GetButtonDown("Jump") && unitSelected) {
				unitSelected = false;
			}
		}
	}

	void UpdateCounter() {
		if (coolCounter > 0) {
			coolCounter--;
		}
	}
}
