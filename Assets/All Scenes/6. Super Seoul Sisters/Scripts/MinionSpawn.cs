using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour {


	private GameObject player;
    public GameObject duck;
	public int duckCount;



    void Start ()
    {	
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", 2, 10);
    }


    void Spawn ()
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //Instantiate (duck, player.transform.position.x, player.transform.position.y);
		Instantiate(duck);
		duckCount++;
    }
}
