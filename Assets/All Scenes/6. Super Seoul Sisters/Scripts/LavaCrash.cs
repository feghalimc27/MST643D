using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCrash : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > -2.75)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
	}
}
