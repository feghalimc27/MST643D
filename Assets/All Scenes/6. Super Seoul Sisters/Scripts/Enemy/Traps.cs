using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour {

    public GameObject merry;
    public GameObject wrongGame;
    
    public AudioClip playDeath;
    private AudioSource deathSound;

    void Start()
    {
        deathSound = GetComponent<AudioSource>();    // assign AudioSource
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Merry")
        {
            merry.GetComponent<Animator>().enabled = false;
            merry.GetComponent<Character_Move>().enabled = false;
            merry.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            StartCoroutine(WrongGame(1));
            StartCoroutine(ShootMerryUpAfterDelay(2.3f));

            if (merry.transform.position.y < -6.38)
            {
                SceneManager.LoadScene("Super Seoul Sisters");
            }
        }
    }

    IEnumerator WrongGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        wrongGame.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator ShootMerryUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        deathSound.PlayOneShot(playDeath); // play sound
        merry.GetComponent<Rigidbody2D>().gravityScale = 10;
        merry.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
        merry.GetComponent<Rigidbody2D>().freezeRotation = false;
        merry.GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, 180);
        merry.GetComponent<BoxCollider2D>().enabled = false;
    }
}
