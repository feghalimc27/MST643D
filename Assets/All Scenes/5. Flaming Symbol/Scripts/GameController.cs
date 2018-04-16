using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject enemyTurnManager;

	// Use this for initialization
	void Start () {
		(enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyTurnManager.GetComponent<EnemyTurnManager>().turnOver) {
			player.GetComponent<FEFriendlyUnit>().turnOver = false;
		}

		if (player.GetComponent<FEFriendlyUnit>().turnOver && (enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled == false) {
			(enemyTurnManager.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled = true;
		}
	}
}
