using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour {

	private FEFriendlyUnit[] units;

	private void Awake() {
		units = GetComponentsInChildren<FEFriendlyUnit>();
	}

	// Use this for initialization
	void Start () {
		units = GetComponentsInChildren<FEFriendlyUnit>();
	}
	
	// Update is called once per frame
	void Update () {
		TestUnits();
	}

	private void OnEnable() {
		foreach (var unit in units) {
			unit.turnOver = false;
		}
	}

	private void OnDisable() {
		
	}

	void TestUnits() {
		foreach (var unit in units) {
			if (!unit.turnOver) {
				return;
			}
		}

		GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartEnemyManager");
	}
}
