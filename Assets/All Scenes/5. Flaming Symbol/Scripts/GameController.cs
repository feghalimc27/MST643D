using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playerCursor;
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
		(playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled = false;
        GetComponent<UIController>().SendMessage("StartEnemyPhase");
	}

    private void DisableCursor() {
        (playerCursor.GetComponent<SelectionCursor>() as MonoBehaviour).enabled = false;
    }

    private void BeginEnemyTurn() {
        (enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = true;
    }

    private void BeginPlayerTurn() {
        (playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled = true;
        (playerCursor.GetComponent<SelectionCursor>() as MonoBehaviour).enabled = true;
    }

    public void StartPlayerManager() {
        (enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = false;
        GetComponent<UIController>().SendMessage("StartPlayerPhase");
    }
}
