using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraFollow : MonoBehaviour {

    public float distance;
    public GameObject character;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
    }

    void UpdatePosition() {
        float x = character.transform.position.x;
        float y = character.transform.position.y + distance / 2;
        float z = character.transform.position.z - distance;

        transform.position = new Vector3(x, y, z);
    }
}
