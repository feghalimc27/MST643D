using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSUIController : MonoBehaviour {

    public Image healthBar, hitmarker, lift, liftBar, dodge, dodgeBar;
    public GameObject player;
    public Text loading, playing;

	// Use this for initialization
	void Start () {
        playing.text = " ";
        playing.enabled = false;
        hitmarker.enabled = false;
        StartCoroutine("FlashObjectiveText");
	}
	
	// Update is called once per frame
	void Update () {
        if (!ZombieBehavior.objectiveAccomplished) {
            playing.text = "Zombies Defeated: " + ZombieBehavior.zombieKillCount;
        }
        else {
            playing.text = "Get to the house!";
        }

        Vector3 width = healthBar.transform.localScale;
        width.x = (player.GetComponent<FPSPlayer>().hp / player.GetComponent<FPSPlayer>().maxHp);
        healthBar.transform.localScale = width;

        liftBar.fillAmount = player.GetComponent<FPSMovement>().GetLiftFill();
        dodgeBar.fillAmount = player.GetComponent<FPSMovement>().GetDodgeFill();

        if (dodgeBar.fillAmount != 1) {
            dodge.color = Color.gray;
        }
        else {
            dodge.color = Color.white;
        }

        if (liftBar.fillAmount == 0) {
            lift.color = Color.gray;
        }
        else {
            lift.color = Color.white;
        }

        if (player.GetComponent<FPSPlayer>().hp <= 25) {
            healthBar.color = Color.red;
        }
        else {
            healthBar.color = Color.white;
        }
	}

    IEnumerator FlashObjectiveText() {
        float i = 1;
        bool yes = false;

        while (true) {
            if (i < 1.5f && !yes) {
                i += 0.01f;

                if (i >= 1.4f) {
                    yes = true;
                }

                loading.transform.localScale = new Vector3(i, i, i);

                yield return null;
            }
            else if (i > 0.7f && yes) {
                i -= 0.01f;

                if (i <= 0.7f) {
                    yes = false;
                    i = 0.7f;
                }

                loading.transform.localScale = new Vector3(i, i, i);
                yield return null;
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetButton("Fire1")) {
                loading.text = " ";
                loading.enabled = false;
                playing.enabled = true;
                break;
            }
        }
    }

    void Hit() {
        StartCoroutine("Hitmarker");
    }

    IEnumerator Hitmarker() {
        while (true) {
            hitmarker.enabled = true;
            yield return new WaitForSeconds(0.2f);
            hitmarker.enabled = false;
            break;
        }
    }
}
