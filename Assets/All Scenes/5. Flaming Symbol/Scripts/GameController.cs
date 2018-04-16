using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject playerTurnManager;
	public GameObject enemyTurnManager;

	// Use this for initialization
	void Start () {
		(enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = false;
		(playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartEnemyManager() {
		(enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = true;
		(playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled = false;
	}

	public void StartPlayerManager() {
		(enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = false;
		(playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled = true;
	}
}
