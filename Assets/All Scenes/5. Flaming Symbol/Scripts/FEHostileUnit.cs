using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEHostileUnit : MonoBehaviour {

	public int atk, mag, def, spd, res, skl, lck, mov, range, maxHp, level, xpToLevel;
	[SerializeField]
	private int hp, xp;

	public Coroutine fade;

	public bool turnOver = false;

	// Use this for initialization
	void Start() {
		hp = maxHp;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			hp = 0;
			fade = StartCoroutine("FadeAway");
		}
	}

	// type 0 = physical 1 = magic
	public void TakeDamage(int damage) {
		int type = 0;

		hp -= damage;
	}

    public int GetCurrentHP() {
        return hp;
    }

	public int GetCurrentSpd() {
		return spd;
	}

    IEnumerator FadeAway() {
		for (float i = 1; i >= 0; i -= 0.03f) {
			Color c = gameObject.GetComponent<SpriteRenderer>().material.color;

			c.a = i;
			gameObject.GetComponent<SpriteRenderer>().material.color = c;

			if (c.a <= 0) {
				this.gameObject.transform.position = new Vector3(10000000, 10000000, 10000000);
			}

			yield return null;
		}

		StopCoroutine(fade);
		Object.Destroy(this.gameObject);
	}
}
