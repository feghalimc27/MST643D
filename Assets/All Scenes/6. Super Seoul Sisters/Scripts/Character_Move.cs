using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {

    public float playerSpeed = 3;
    public int hasJumped = 0;
    private int playerJumpPower;
    private float moveX;
    public bool onGround = true;
    public bool canDoubleJump = true;
    public Player_Health _player_health;
    public float raycastDown = .3f;

    public AudioClip playJump;
    private AudioSource jumpSound;
    public AudioClip playLanding;
    private AudioSource landingSound;
    public AudioClip playerMonsterDie;
    private AudioSource monsterDieSound;


    void Start()
    {
        jumpSound = GetComponent<AudioSource>();    // assign AudioSource
        monsterDieSound = GetComponent<AudioSource>();    // assign AudioSource
        landingSound = GetComponent<AudioSource>();    // assign AudioSource
    }
    // Update is called once per frame
    void Update () {
        CharacterMove();
        PlayerRaycast();
    }

    // controls character movement and physics
    void CharacterMove()
    {
        moveX = Input.GetAxis("Horizontal");

        // jump
        if (Input.GetButtonDown("Jump") && (canDoubleJump == true || onGround == true))
        {
            if((canDoubleJump == true && onGround == true))
            {
                playerJumpPower = 110;
                Jump();
            }
            else if (canDoubleJump == true && onGround == false)
            {
                playerJumpPower = 110;
                Jump();
            }
        }

        //animations
        if(moveX != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        // determine what way the character is facing
        if(moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // physics stuff
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce((Vector2.up * playerJumpPower));
        onGround = false;
        hasJumped++;
        if(hasJumped >= 2){
            canDoubleJump = false;
            hasJumped = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, 0);
        }
        jumpSound.PlayOneShot(playJump); // play sound
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            //landingSound.PlayOneShot(playLanding); // play sound
            onGround = true;
            canDoubleJump = true;
            hasJumped = 0;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit != null && hit.collider != null && hit.distance < raycastDown && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);

            if(hit != null && hit.collider != null && hit.collider.tag == "Enemy")
            {
                monsterDieSound.PlayOneShot(playerMonsterDie); // play sound
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<Enemy_AI>().enabled = false;

            }
        }
    }
}

