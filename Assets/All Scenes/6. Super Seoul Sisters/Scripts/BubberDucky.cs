using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BubberDucky : MonoBehaviour {
    public GameObject merry;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(12, 13);
        InvokeRepeating("JumpMikeJump", 2.0f, 1.0f);
    }

    void JumpMikeJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 250);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Merry")
        {
            merry.GetComponent<Rigidbody2D>().gravityScale = 5;
            merry.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            merry.GetComponent<Rigidbody2D>().gravityScale = 2;
            merry.GetComponent<Rigidbody2D>().freezeRotation = false;
            merry.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
            merry.GetComponent<BoxCollider2D>().enabled = false;
            merry.GetComponent<Rigidbody2D>().gravityScale = 5;

            if (merry.transform.position.y < -6.38)
            {
                SceneManager.LoadScene("Super Seoul Sisters");
            }
        }
    }
}

