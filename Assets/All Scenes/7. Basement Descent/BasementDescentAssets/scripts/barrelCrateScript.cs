using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelCrateScript : MonoBehaviour {

    public float structPoints = 3;

    void Update()
    {
        if (structPoints == 0)
            GameObject.Destroy(gameObject);
    }

	void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.name == "dud(Clone)")
            structPoints -= 1;
    }
}
