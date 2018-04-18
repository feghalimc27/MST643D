using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_AI : MonoBehaviour {

    public float enemySpeed = 1.7f;
    public int xMoveDirection;
    public int xMove;
    public float thingy = .106f;
    public float diediedie = .9f;
    public Player_Health _player_health;

    // Update is called once per frame
    void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;

        if (hit.distance < .2f)
        {
            FlipEnemy();
            if (hit != null && hit.collider != null && hit.collider.tag == "Player")
            {
                //Destroy(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //hit.collider.gameObject.GetComponent<Enemy_AI>().enabled = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;

                if (gameObject.transform.position.y < -6.38)
                {
                    SceneManager.LoadScene("Super Seoul Sisters");
                }
            }
        }
    }

    void FlipEnemy()
    {
        if(xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }

        else
        {
            xMoveDirection = 1;
        }
    }
}
/*
RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0f));
gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        if(hit != null && hit.collider != null && hit.distance<thingy)
        {

            if(hit != null && hit.collider != null && hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
_player_health.Die();
            }
        }

        RaycastHit2D anotherHit = Physics2D.Raycast(transform.position, new Vector2(xMove, .9f));
        if (anotherHit != null && anotherHit.collider != null && anotherHit.distance<thingy)
        {
            if (anotherHit != null && anotherHit.collider != null && anotherHit.collider.tag == "Player")
            {
                Destroy(anotherHit.collider.gameObject);
_player_health.Die();
            }
        }
        */
