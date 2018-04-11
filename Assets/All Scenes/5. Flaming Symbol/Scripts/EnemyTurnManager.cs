using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour {

	private GameObject[] units;

	private int currentUnit;

	private bool turnOver = true;

	// Use this for initialization
	void Start () {
		units = GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
