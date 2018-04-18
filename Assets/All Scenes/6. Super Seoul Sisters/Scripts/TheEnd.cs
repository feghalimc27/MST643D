using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D fin)
    {
        if (fin.name == "Merry")
        {
            DontDestroyOnLoad(new GameObject("levelCompleted"));
        }
    }
}
