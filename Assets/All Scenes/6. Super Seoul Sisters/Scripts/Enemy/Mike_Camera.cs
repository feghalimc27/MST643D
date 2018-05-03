using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mike_Camera : MonoBehaviour {

    private GameObject player;
    public GameObject spawnDuck;

    MinionSpawn spawnMinion;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public bool spawnAtForty;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        spawnMinion = FindObjectOfType<MinionSpawn>();

        spawnAtForty = false;
    }

    void Update(){
        if (player.transform.position.y > 4)
        {
            Camera.main.orthographicSize = 1.5f;
            yMax = 100;
            yMin = 9.1f;
            xMin = 2.995f;
        }
        else if(player.transform.position.y < 4)
        {
            Camera.main.orthographicSize = 2.496301f;
            yMin = 1.9f;
            yMax = 1.9f;
        }
        else if (player.transform.position.y > -3.0f)
        {
            yMin = 1.9f;
            xMin = 3.11f;
            yMax = 1.9f;
        }

        if(spawnDuck.transform.position.x > 40 && spawnAtForty == false)
        {
            spawnMinion.Spawn(spawnDuck.transform.position);
            spawnAtForty = true;
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
