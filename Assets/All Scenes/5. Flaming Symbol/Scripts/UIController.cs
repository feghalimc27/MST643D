using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Image uBase, eBase, pHighlight, enemyHighlight;
    public Text[] playerStatsText = new Text[5]; // HP, ATK, DEF, SPD, LCK
    public Text[] enemyStatsText = new Text[5]; // HP, ATK, DEF, SPD, LCK

    public GameObject playerCursor;

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
    }
	
	// Update is called once per frame
	void Update () {
        GetPlayerHighlight();
	}

    void GetPlayerHighlight() {
        GameObject playerUnit = playerCursor.GetComponent<SelectionCursor>().player;

        if (playerUnit != null) {
            FEFriendlyUnit unitStats = playerUnit.GetComponent<FEFriendlyUnit>();

            pHighlight.enabled = true;

            playerStatsText[0].text = "" + unitStats.GetCurrentHP() + "/" + unitStats.maxHp;
            playerStatsText[1].text = "" + unitStats.atk;
            playerStatsText[2].text = "" + unitStats.def;
            playerStatsText[3].text = "" + unitStats.spd;
            playerStatsText[4].text = "" + unitStats.lck;

            GameObject enemyUnit = playerCursor.GetComponent<SelectionCursor>().enemy;

            if (enemyUnit != null) {
                FEHostileUnit enemyStats = enemyUnit.GetComponent<FEHostileUnit>();

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
        else {
            foreach (var text in playerStatsText) {
                text.text = "";
            }

            pHighlight.enabled = false;
        }
    }
}
