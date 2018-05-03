using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour {

    public GameObject duck;
	public int duckCount;
    private Vector3 spawnPoint;

    void Start()
    {
    }

    public void Spawn (Vector3 spawnPosition)
    {
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //Instantiate (duck, player.transform.position.x, player.transform.position.y);
        Instantiate(duck);
		duckCount++;
    }
}
