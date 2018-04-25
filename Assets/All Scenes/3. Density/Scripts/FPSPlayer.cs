using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSPlayer : MonoBehaviour {

    public float hp, maxHp, damage;

	// Use this for initialization
	void Start () {
        hp = maxHp;
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Finish") {
            DontDestroyOnLoad(new GameObject("levelCompleted"));
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    public void TakeDamage(float damage) {
        hp -= damage;
    }
}
