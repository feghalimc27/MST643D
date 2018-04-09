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

	[SerializeField]
	private GameObject[] blocking = new GameObject[4];
	private bool[] blocked = new bool[4];

    [SerializeField]
    private float deadzone = 0.4f;

    private int movCountX = 0;
	private int movCountY = 0;

    [HideInInspector]
	public bool unitSelected = false;

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
			player = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			player = null;
		}
	}

	void MoveCursor() {
		Vector3 move = new Vector3(0, 0, 0);

		if (unitSelected) {

			for (int i = 0; i < 4; ++i) {
				blocked[i] = blocking[i].GetComponent<CursorBlock>().blocked;
			}

			if ((transform.position + move).x < endPosPlusX && Input.GetAxis("Horizontal") > deadzone && coolCounter == 0 && !blocked[2]) {
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
			else if ((transform.position - move).x > endPosMinusX && Input.GetAxis("Horizontal") < -deadzone && coolCounter == 0 && !blocked[3]) {
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
			else if ((transform.position + move).y < endPosPlusY && Input.GetAxis("Vertical") > deadzone && coolCounter == 0 && !blocked[0]) {
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
			else if ((transform.position - move).y > endPosMinusY && Input.GetAxis("Vertical") < -deadzone && coolCounter == 0 && !blocked[1]) {
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
			if (Input.GetAxis("Horizontal") > deadzone && coolCounter == 0) {
				move.x += speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Horizontal") < -deadzone && coolCounter == 0) {
				move.x -= speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Vertical") > deadzone && coolCounter == 0) {
				move.y += speed;

				coolCounter = movementCooldown;
			}
			else if (Input.GetAxis("Vertical") < -deadzone && coolCounter == 0) {
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

    public GameObject GetSelectedUnit() {
        if (unitSelected) {
            return player;
        }
        else {
            return null;
        }
    }

	void UpdateCounter() {
		if (coolCounter > 0) {
			coolCounter--;
		}
	}
}
