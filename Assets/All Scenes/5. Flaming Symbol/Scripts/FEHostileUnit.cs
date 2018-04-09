using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEHostileUnit : MonoBehaviour {

	public int atk, mag, def, spd, res, lck, mov, range, maxHp, level, xpToLevel;
	[SerializeField]
	private int hp, xp;

	// Use this for initialization
	void Start() {
		hp = maxHp;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			StartCoroutine("FadeAway");
		}
	}

	// type 0 = physical 1 = magic
	public void TakeDamage(int attack, int type) {
		int damage = 0;

		if (type == 0) {
			damage = attack - def;
			if (damage >= 0) {
				damage = 0;
			}
		}
		else if (type == 1) {
			damage = attack - res;
			if (damage >= 0) {
				damage = 0;
			}
		}

		hp -= damage;
	}

	IEnumerator FadeAway() {
		for (float i = 1; i >= 0; i -= 0.03f) {
			Color c = gameObject.GetComponent<SpriteRenderer>().material.color;

			c.a = i;
			gameObject.GetComponent<SpriteRenderer>().material.color = c;

			if (c.a <= 0) {
				gameObject.SetActive(false);
			}

			yield return null;
		}
	}
}
