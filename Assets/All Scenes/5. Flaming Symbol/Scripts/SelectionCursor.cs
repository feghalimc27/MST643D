using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCursor : MonoBehaviour {

	public int speed;
	[SerializeField]
	private int movementCooldown = 30;
	private int currentCool = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveCursor();
		Countdown();
	}

	void MoveCursor() {
		Vector3 move = new Vector3(0, 0, 0);

		if (Input.GetAxis("Horizontal") > 0.2 && currentCool == 0 || Input.GetAxis("Horizontal") < -0.2 && currentCool == 0) {
			move.x = Input.GetAxisRaw("Horizontal") * speed;
			currentCool = movementCooldown;
		}
		else if (Input.GetAxis("Vertical") > 0.2 && currentCool == 0 || Input.GetAxis("Vertical") < -0.2 && currentCool == 0) {
			move.y = Input.GetAxisRaw("Vertical") * speed;
			currentCool = movementCooldown;
		}

		transform.position += move;
	}

	void Countdown() {
		if (currentCool > 0) {
			currentCool--;
		}
	}
}
