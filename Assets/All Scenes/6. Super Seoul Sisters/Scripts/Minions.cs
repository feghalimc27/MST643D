using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Minions : MonoBehaviour {
    public GameObject merry;

    public AudioClip soundToPlay;
    public AudioSource landSound;
    public AudioClip playDeath;
    public AudioSource deathSound;


    void Start()
    {
        merry.GetComponent<Character_Move>().enabled = false;

        landSound = GetComponent<AudioSource>();    // assign AudioSource
        deathSound = GetComponent<AudioSource>();    // assign AudioSource

        Physics2D.IgnoreLayerCollision(12, 13);
        StartCoroutine(EnableMovementAfterDelay(1.5f));
        InvokeRepeating("JumpMikeJump", 2.0f, 1.0f);
    }

    void JumpMikeJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150);
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 75);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Merry")
        {
            deathSound.PlayOneShot(playDeath); // play sound
            merry.GetComponent<Rigidbody2D>().gravityScale = 5;
            merry.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            merry.GetComponent<Rigidbody2D>().gravityScale = 2;
            merry.GetComponent<Rigidbody2D>().freezeRotation = false;
            merry.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
            merry.GetComponent<BoxCollider2D>().enabled = false;
            merry.GetComponent<Rigidbody2D>().gravityScale = 5;
            merry.GetComponent<Character_Move>().enabled = false;
            //Camera.main.GetComponent<Camera_System>().enabled = false;    // causes error for some reason

            if (merry.transform.position.y < -6.38)
            {
                SceneManager.LoadScene("Super Seoul Sisters");
            }
        }
        else if(collision.name != "Merry")
        {
            landSound.PlayOneShot(soundToPlay); // play sound
        }
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        merry.GetComponent<Character_Move>().enabled = true;
    }

}

