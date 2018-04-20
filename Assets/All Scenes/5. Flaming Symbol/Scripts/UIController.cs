using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Image uBase, eBase, pHighlight, enemyHighlight, pPhaseText, ePhaseText;
    public Text[] playerStatsText = new Text[5]; // HP, ATK, DEF, SPD, LCK
    public Text[] enemyStatsText = new Text[5]; // HP, ATK, DEF, SPD, LCK

    public GameObject playerCursor;
    public GameObject playerTurnManager;
    public GameObject enemyTurnManger;

	// Use this for initialization
	void Start () {
        foreach (var text in playerStatsText) {
            text.text = "";
        }
        foreach (var text in enemyStatsText) {
            text.text = "";
        }

        eBase.enabled = false;
        pHighlight.enabled = false;
        enemyHighlight.enabled = false;
        pPhaseText.enabled = false;
        ePhaseText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        GetPlayerHighlight();
		GetEnemyHighlight();
        BackgroundManager();
	}

    IEnumerator StartEnemyPhase() {
        ePhaseText.enabled = true;

        for (float i = 0; i <= 1; i += 0.1f) {
            Color c = ePhaseText.color;

            c.a = i;
            ePhaseText.color = c;

            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        GetComponent<GameController>().SendMessage("DisableCursor");

        yield return new WaitForSeconds(1.5f);

        for (float i = 1; i >= 0; i -= 0.1f) {
            Color c = ePhaseText.color;

            c.a = i;
            ePhaseText.color = c;

            yield return null;
        }

        ePhaseText.enabled = false;

        GetComponent<GameController>().SendMessage("BeginEnemyTurn");
    }

    IEnumerator StartPlayerPhase() {
        pPhaseText.enabled = true;

        for (float i = 0; i <= 1; i += 0.1f) {
            Color c = pPhaseText.color;

            c.a = i;
            pPhaseText.color = c;

            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        for (float i = 1; i >= 0; i -= 0.1f) {
            Color c = pPhaseText.color;

            c.a = i;
            pPhaseText.color = c;

            yield return null;
        }

        pPhaseText.enabled = false;

        GetComponent<GameController>().SendMessage("BeginPlayerTurn");
    }

    void BackgroundManager() {
        if ((enemyTurnManger.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled == true) {
            eBase.enabled = true;
        }
        else if (pPhaseText.enabled == true) {
            eBase.enabled = false;
        }
        else if (ePhaseText.enabled == true) {
            eBase.enabled = true;
        }
        else {
            eBase.enabled = false;
        }
    }

    void GetPlayerHighlight() {
        GameObject playerUnit = playerCursor.GetComponent<SelectionCursor>().player;

        if (playerUnit != null && (enemyTurnManger.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled == false && (playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled == true) {
            FEFriendlyUnit unitStats = playerUnit.GetComponent<FEFriendlyUnit>();

            pHighlight.enabled = true;

            playerStatsText[0].text = "" + unitStats.GetCurrentHP() + "/" + unitStats.maxHp;
            playerStatsText[1].text = "" + unitStats.atk;
            playerStatsText[2].text = "" + unitStats.def;
            playerStatsText[3].text = "" + unitStats.spd;
            playerStatsText[4].text = "" + unitStats.lck;
        }
        else {
            foreach (var text in playerStatsText) {
                text.text = "";
            }

            pHighlight.enabled = false;
        }
    }

	void GetEnemyHighlight() {
		GameObject enemyUnit = playerCursor.GetComponent<SelectionCursor>().enemy;

		if (playerCursor.GetComponent<SelectionCursor>().enemy != null && playerCursor.GetComponent<SelectionCursor>().player != null && (enemyTurnManger.GetComponent<EnemyTurnManager>() as MonoBehaviour).enabled == false && (playerTurnManager.GetComponent<PlayerTurnManager>() as MonoBehaviour).enabled == true) {
			enemyUnit = playerCursor.GetComponent<SelectionCursor>().enemy;
		}
		else {
			enemyUnit = null;
		}

		if (enemyUnit != null) {
			FEHostileUnit enemyStats = enemyUnit.GetComponent<CursorBlock>().enemy.GetComponent<FEHostileUnit>();

			enemyHighlight.enabled = true;

			enemyStatsText[0].text = "" + enemyStats.GetCurrentHP() + "/" + enemyStats.maxHp;
			enemyStatsText[1].text = "" + enemyStats.atk;
			enemyStatsText[2].text = "" + enemyStats.def;
			enemyStatsText[3].text = "" + enemyStats.spd;
			enemyStatsText[4].text = "" + enemyStats.lck;
		}
		else {
			foreach (var text in enemyStatsText) {
				text.text = "";
			}

			enemyHighlight.enabled = false;
		}
	}
}
