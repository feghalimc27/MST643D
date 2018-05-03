using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCompass : MonoBehaviour {

    SpriteRenderer arrow;
    public GameObject objective;

	// Use this for initialization
	void Start () {
        arrow = GetComponent<SpriteRenderer>();
        arrow.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ZombieBehavior.objectiveAccomplished) {
            arrow.enabled = true;
        }

        Vector3 direction = objective.transform.position - transform.position;
        float rotationAnlge = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(90, 0, -rotationAnlge));
    }
}
