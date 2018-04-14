using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Stuff : MonoBehaviour {
	
	private int xMoveDirection;
	public Player_Health pH;

	// Update is called once per frame
	void Update () {
		PlayerRaycast();
	}

	void PlayerRaycast()
    {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<Enemy_AI>().enabled = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;

                pH.Die();
            }

			
    }
	
	private void OnTriggerEnter2D(Collider2D trap)
    {
        if (trap.name == "Merry")
        {
            pH.Die();
        }
    }
}
