using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour {

    public GameObject merry;
    
    public AudioClip playDeath;
    public AudioSource deathSound;


    void Start()
    {
        deathSound = GetComponent<AudioSource>();    // assign AudioSource
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Merry")
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
            Camera.main.GetComponent<Camera_System>().enabled = false;    // causes error for some reason

            if (merry.transform.position.y < -6.38)
            {
                SceneManager.LoadScene("Super Seoul Sisters");
            }
        }
    }
}
