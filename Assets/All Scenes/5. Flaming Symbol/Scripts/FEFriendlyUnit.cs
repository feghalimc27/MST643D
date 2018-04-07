﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEFriendlyUnit : MonoBehaviour {

	public int atk, mag, def, spd, res, lck, mov, range, maxHp, level, xpToLevel;
	[SerializeField]
	private int hp, xp;

	// Use this for initialization
	void Start () {
		hp = maxHp;
		xp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
}