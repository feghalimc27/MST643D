using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Minions : MonoBehaviour {
    public GameObject merry;
    public GameObject leftCamera;
    public GameObject minionMovement;

    public AudioClip soundToPlay;
    private AudioSource landSound;
    public AudioClip playDeath;
    private AudioSource deathSound;

    private Character_Move _character_move;


    void Start()
    {
        merry.GetComponent<Character_Move>().enabled = false;

        landSound = GetComponent<AudioSource>();    // assign AudioSource
        deathSound = GetComponent<AudioSource>();    // assign AudioSource

        _character_move = FindObjectOfType<Character_Move>();

        Physics2D.IgnoreLayerCollision(12, 13);

        StartCoroutine(EnableMovementAfterDelay(3.5f));

        InvokeRepeating("JumpMikeJump", 2.0f, 1.0f);
    }

    void Update()
    {
        if(gameObject.transform.position.x < minionMovement.transform.position.x)
        {
            gameObject.SetActive(true);
        }

        if (gameObject.transform.position.x < leftCamera.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    void JumpMikeJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150);
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 75);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Merry" && _character_move.onGround == true)
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
            Camera.main.GetComponent<Mike_Camera>().enabled = false;

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

