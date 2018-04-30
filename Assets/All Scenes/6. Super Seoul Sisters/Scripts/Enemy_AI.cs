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

    public AudioClip playDeath;
    public AudioSource deathSound;
    public AudioClip playerMonsterDie;
    private AudioSource monsterDieSound;


    void Start()
    {
        deathSound = GetComponent<AudioSource>();   // assign AudioSource
        monsterDieSound = GetComponent<AudioSource>();    // assign AudioSource
    }

    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));

        if (hit.distance < .2f)
        {
            FlipEnemy();
        }
    }

    public void FlipEnemy()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        }

        else
        {
            xMoveDirection = 1;
        }
    }
}
