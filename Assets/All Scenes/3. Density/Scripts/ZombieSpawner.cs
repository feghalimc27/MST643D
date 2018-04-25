using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public Vector3[] spawnPoints;
    public int zombieCount;
    public GameObject enemy;
    public int spawnDelay;

    private int _spawnDelay;
    private ZombieBehavior[] zombies;

	// Use this for initialization
	void Start () {
        _spawnDelay = spawnDelay;
        spawnDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        SpawnLogic();
	}

    void SpawnLogic() {
        zombies = GetComponentsInChildren<ZombieBehavior>();

        if (zombies.Length < zombieCount && spawnDelay == 0) {
            GameObject zombie = Instantiate(enemy);
            int spawnPoint = Random.Range(0, spawnPoints.Length - 1);
            zombie.GetComponent<ZombieBehavior>().player = GameObject.Find("Player");
            zombie.transform.position = spawnPoints[spawnPoint];
            zombie.transform.parent = gameObject.transform;

            spawnDelay = _spawnDelay;
        }
        else if (spawnDelay > 0) {
            spawnDelay--;
        } 
    }
}
