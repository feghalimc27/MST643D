using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mike_Camera : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Update(){
        if (false/*(player.transform.position.x > 38.85f && player.transform.position.x < 40.4f) && player.transform.position.y < -3.614f*/)
        {
            yMin = -3.905f;
        }
        else if (player.transform.position.y > -3.0f)
        {
            yMin = 1.9f;
        }
    }
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
