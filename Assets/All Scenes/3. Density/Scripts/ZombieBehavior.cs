using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {

    public float health, speed;
	public float randomSpeed;
    public float damage;
    public GameObject player;

    private int damageWait;
	public static int zombieKillCount = 0;
	public static int zombieKillsRequired = 70;
	public static bool objectiveAccomplished = false;

	// Use this for initialization
	void Start () {
		randomSpeed = Random.Range ((speed - 3.0f), (speed + 7.0f));
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.SendMessage("TakeDamage", damage);
            damageWait = 60;
        }
    }

    void OnCollisionStay(Collision col) {
        if (col.gameObject.tag == "Player") {
            if (damageWait == 0) {
                col.gameObject.SendMessage("TakeDamage", damage);
                damageWait = 60;
            }
            else {
                damageWait--;
            }
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Player") {
            damageWait = 0;
        }
    }

	// Update is called once per frame
	void Update () {
		float step = randomSpeed * Time.deltaTime;

        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        if (health <= 0) {
            Object.Destroy(gameObject);

			objectiveAccomplished = isObjectiveAccomplished ();
			if (objectiveAccomplished) {
				print ("*** OBJECTIVE ACCOMPLISEHED!***");
			} else {
				++zombieKillCount;
				print (zombieKillCount);
			}
        }
	}

    public void TakeDamage(float damage) {
        health -= damage;
    }

	public bool isObjectiveAccomplished() {
		if (zombieKillCount >= zombieKillsRequired - 1)
			return true;
		else
			return false;
	}

}
