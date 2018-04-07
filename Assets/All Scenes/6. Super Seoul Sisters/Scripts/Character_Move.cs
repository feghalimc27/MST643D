using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {

    public float playerSpeed = 3;
    private bool facingRight = false;
    private int hasJumped = 0;
    public int playerJumpPower = 850;
    private float moveX;
    private int onGround = 1;
    public Player_Health _player_health;

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
        if (Input.GetButtonDown("Jump") && (onGround == 1 || onGround == 0) && (hasJumped == 0 || hasJumped == 1))
        {
            Jump();
        }

        // determine what way the character is facing
        if(facingRight == false && moveX < 0.0f)
        {
            FlipCharacter();
        }
        else if(facingRight == true && moveX > 0.0f)
        {
            FlipCharacter();
        }

        // physics stuff
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void FlipCharacter()
    {  
        // flip character
        facingRight = !facingRight;
        // create new vector
        Vector2 localScale = gameObject.transform.localScale;
        // flip basically
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce((Vector2.up * playerJumpPower));
        onGround++;
        hasJumped = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            hasJumped = 0;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit != null && hit.collider != null && hit.distance < 0.3f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);

            if(hit != null && hit.collider != null && hit.collider.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                hit.collider.gameObject.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                hit.collider.gameObject.GetComponent<Enemy_AI>().enabled = false;

            }
        }

        if (hit != null && hit.collider != null && hit.distance < 0.3f && hit.collider.tag != "Enemy")
        {
            onGround = 0;
        }
    }
}

