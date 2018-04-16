using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEFriendlyUnit : MonoBehaviour {

	public int atk, mag, def, spd, res, skl, lck, mov, range, maxHp, level, xpToLevel;
	[SerializeField]
	private int hp, xp;

    [HideInInspector]
    public bool turnOver = false;

	private Coroutine fade;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        SetColor();
		if (hp <= 0) {
			hp = 0;
			fade = StartCoroutine("FadeAway");
		}
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
