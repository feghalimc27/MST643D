using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEFriendlyUnit : MonoBehaviour {

	public int atk, mag, def, spd, res, skl, lck, mov, range, maxHp, level, xpToLevel;
	[SerializeField]
	private int hp, xp;

    [HideInInspector]
    public bool turnOver = false;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        SetColor();
	}

	public void TakeDamage(int damage) {
		int type = 0;

		hp -= damage;
	}


    void SetColor() {
        switch(turnOver) {
            case true:
                GetComponent<SpriteRenderer>().color = Color.gray;
                break;
            case false:
                GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }
}
