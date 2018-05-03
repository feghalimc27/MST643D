using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIScript : MonoBehaviour {

    private bool playerSighted;
    public Transform playerPosition;
	// Use this for initialization
	void Start () {

        playerSighted = false;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (playerSighted == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(-(playerPosition.position.x - transform.position.x),
                playerPosition.position.y - transform.position.y) * (180 / 3.14f)));
        }
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "player")
        {
            Vector2 direction = collider.transform.position - transform.position;
            RaycastHit2D lineOfSight = Physics2D.Raycast(transform.position, direction);
            Debug.Log("I might see 'im.");
            if (lineOfSight.collider.gameObject.name == "player")
                playerSighted = true;
            else
                playerSighted = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name == "player")
            playerSighted = false;
    }
}
