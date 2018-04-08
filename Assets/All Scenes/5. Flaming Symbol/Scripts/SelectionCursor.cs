using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCursor : MonoBehaviour {

	public int movementCooldown;

	private float speed = 0.5f;
	private int coolCounter = 0;

	private GameObject player = null;

	private Vector3 startPos;
	private float endPosPlusX;
	private float endPosMinusX;
	private float endPosPlusY;
	private float endPosMinusY;

	private int movCountX = 0;
	private int movCountY = 0;

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

		if (unitSelected) {
			if ((transform.position + move).x < endPosPlusX && Input.GetAxis("Horizontal") > 0.2 && coolCounter == 0) {
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.x += speed;
					movCountX += 1;
				}
				else if (movCountX < 0) {
					move.x += speed;
					movCountX += 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position - move).x > endPosMinusX && Input.GetAxis("Horizontal") < -0.2 && coolCounter == 0) {
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.x -= speed;
					movCountX -= 1;
				}
				else if (movCountX > 0) {
					move.x -= speed;
					movCountX -= 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position + move).y < endPosPlusY && Input.GetAxis("Vertical") > 0.2 && coolCounter == 0) {
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.y += speed;
					movCountY += 1;
				}
				else if (movCountY < 0) {
					move.y += speed;
					movCountY += 1;
				}

				coolCounter = movementCooldown;
			}
			else if ((transform.position - move).y > endPosMinusY && Input.GetAxis("Vertical") < -0.2 && coolCounter == 0) {
				if (Mathf.Abs(movCountX) + Mathf.Abs(movCountY) != player.gameObject.GetComponent<FEFriendlyUnit>().mov) {
					move.y -= speed;
					movCountY -= 1;
				}
				else if (movCountY > 0) {
					move.y -= speed;
					movCountY -= 1;
				}

				coolCounter = movementCooldown;
			}
		}
		else {
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

				startPos = player.transform.position;
				float movRange = player.GetComponent<FEFriendlyUnit>().mov * speed;

				endPosPlusX = startPos.x + movRange;
				endPosMinusX = startPos.x - movRange;
				endPosPlusY = startPos.y + movRange;
				endPosMinusY = startPos.y - movRange;
			}
			else if (Input.GetButtonDown("Jump") && unitSelected) {
				unitSelected = false;

				movCountX = 0;
				movCountY = 0;
			}
		}
	}

	void UpdateCounter() {
		if (coolCounter > 0) {
			coolCounter--;
		}
	}
}
