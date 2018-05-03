using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "player")
        {
            DontDestroyOnLoad(new GameObject("levelCompleted"));
        }
    }
}
