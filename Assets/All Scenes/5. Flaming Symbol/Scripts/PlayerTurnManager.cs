using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTurnManager : MonoBehaviour {

	public Vector3 endTile = new Vector3(6.92f, 4.52f, 0);
    public AudioClip victorySound;

    [SerializeField]
	private FEFriendlyUnit[] units;
    bool endTurn = false;
    bool sounded = false;

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

			if (unit.transform.position == endTile) {
				endTurn = true;
                if (!sounded) {
                    GetComponent<AudioSource>().PlayOneShot(victorySound);
                    sounded = true;
                }
				GameObject.Find("Controller").GetComponent<UIController>().SendMessage("EndLevel");
			}
		}

        if (!endTurn) {
            StartCoroutine("DelayStart");
            endTurn = true;
        }
    }
}
