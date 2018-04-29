using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Update(){
        if((player.transform.position.x > 54.408f && player.transform.position.x < 61.619f) && player.transform.position.y < 0.86f)
        {
            yMin = .1f;
        }
        else if(player.transform.position.y > -3.0f)
        {
            yMin = 2.5f;
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
