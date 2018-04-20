using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour {

	private FEHostileUnit[] units;

	private int currentUnit;
	private int tempCounter = 0;
	private int unitMoves = 0;
	private int waitStart = 300;

    [SerializeField]
    private float movSpeed = 0.5f;

	public bool turnOver = true;

	Coroutine moveUnits;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (units.Length > 0) {
			moveUnits = StartCoroutine("MoveUnits");
		}

		if (units.Length <= 0) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}

		if (currentUnit >= units.Length) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}
	}

	private void OnEnable() {
		units = GetComponentsInChildren<FEHostileUnit>();
		turnOver = false;
		tempCounter = 0;
		currentUnit = 0;
	}

	private void OnDisable() {
		turnOver = true;
	}

	IEnumerator MoveUnits() {
		while (!turnOver) {
			FEHostileUnit stats = units[currentUnit];
			if (units[currentUnit].fade == null && units[currentUnit] != null) {
				Vector3 position = stats.gameObject.transform.position;
				if (unitMoves < stats.mov && tempCounter == 0) {
					position.x += movSpeed;
					unitMoves++;
					stats.gameObject.transform.position = position;
					tempCounter = 30;
				}
				else if (tempCounter > 0) {
					tempCounter--;
				}
				else {
					unitMoves = 0;
					currentUnit++;
					if (currentUnit >= units.Length) {
						turnOver = true;
						break;
					}
				}
			}
			else if (units[currentUnit] == null) {
				currentUnit++;
			}

			yield return null;
		}

		StopCoroutine(moveUnits);
	}
}
