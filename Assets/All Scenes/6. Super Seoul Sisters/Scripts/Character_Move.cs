using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {

    public int playerSpeed = 800;
    private bool facingRight = false;
    public int playerJumpPower = 100000;
    private float moveX;
    public bool onGround = false;

	// Update is called once per frame
	void Update () {
        CharacterMove();
    }

    // controls character movement and physics
    void CharacterMove()
    {
        moveX = Input.GetAxis("Horizontal");

        // jump
        if (Input.GetButtonDown("Jump") && onGround == true)
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
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
}
