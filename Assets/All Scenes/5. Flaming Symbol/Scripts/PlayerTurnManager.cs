using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTurnManager : MonoBehaviour {

    [SerializeField]
	private FEFriendlyUnit[] units;
    bool endTurn = false;

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

        endTurn = false;
	}

	private void OnDisable() {
		
	}

    IEnumerator DelayStart() {
        yield return new WaitForSeconds(0.7f);

        GameObject.Find("Controller").GetComponent<GameController>().SendMessage("StartEnemyManager");
    }

    void TestUnits() {
        units = GetComponentsInChildren<FEFriendlyUnit>();

        if (units.Length == 0) {
            SceneManager.LoadScene("Flaming Symbol");
        }

        foreach (var unit in units) {
			if (!unit.turnOver) {
				return;
			}
		}

        if (!endTurn) {
            StartCoroutine("DelayStart");
            endTurn = true;
        }
    }
}
