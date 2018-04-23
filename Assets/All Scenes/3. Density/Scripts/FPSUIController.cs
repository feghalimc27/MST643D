using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSUIController : MonoBehaviour {

    public Image healthBar;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 width = healthBar.transform.localScale;
        width.x = (player.GetComponent<FPSPlayer>().hp / player.GetComponent<FPSPlayer>().maxHp);
        healthBar.transform.localScale = width;

        if (player.GetComponent<FPSPlayer>().hp <= 25) {
            healthBar.color = Color.red;
        }
        else {
            healthBar.color = Color.white;
        }
	}
}
