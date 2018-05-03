using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour {

    private GameObject player;
    public GameObject doorStop;

    public AudioSource backgroundMusic;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Update(){
        if((player.transform.position.x > 68.94f && player.transform.position.x < 76.32f) && player.transform.position.y < 0.86f)
        {
            yMin = -1.2f;
            xMin = 70.1f;
            yMax = -1.2f;
            Camera.main.orthographicSize = 1.18f;
            Camera.main.transform.position = new Vector3(70.04052f, -.96f, -11);
            backgroundMusic.Pause();

            if(player.transform.position.y < -1)
            {
                doorStop.GetComponent<BoxCollider2D>().enabled = true;
            }
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
