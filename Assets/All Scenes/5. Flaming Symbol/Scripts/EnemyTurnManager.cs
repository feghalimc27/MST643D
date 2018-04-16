using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour {

	private FEHostileUnit[] units;

	private int currentUnit;
	private int tempCounter = 0;

	public bool turnOver = true;

	// Use this for initialization
	void Start () {
		units = GetComponentsInChildren<FEHostileUnit>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnOver) {
			tempCounter += 1;
		}

		if (units.Length <= 0) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}

		if (tempCounter > 300) {
			GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartPlayerManager");
		}
	}

	private void OnEnable() {
		units = GetComponentsInChildren<FEHostileUnit>();
		turnOver = false;
		tempCounter = 0;
	}

	private void OnDisable() {
		turnOver = true;
	}
}
