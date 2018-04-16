using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour {

	private GameObject[] units;

	private int currentUnit;
	private int tempCounter = 0;

	public bool turnOver = true;

	// Use this for initialization
	void Start () {
		units = GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnOver) {
			Debug.Log(tempCounter);
			tempCounter += 1;
		}

		if (tempCounter > 30) {
			(GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = false;
		}
	}

	private void OnEnable() {
		turnOver = false;
		tempCounter = 0;
	}

	private void OnDisable() {
		turnOver = true;
	}
}
