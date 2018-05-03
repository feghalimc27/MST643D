using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{

    private float speed = 80;
    public AudioClip soundToPlay;
    public AudioSource ringSound;
    private int ringPoints;
    public int currentScore;

    private ScoreManager sM;

    // Use this for initialization
    void Start()
    {
        ringSound = GetComponent<AudioSource>();    // assign AudioSource
        sM = FindObjectOfType<ScoreManager>();
        ringPoints = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);   // rotate coin
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Merry")
        {
            ringSound.PlayOneShot(soundToPlay); // play sound
            gameObject.GetComponent<SpriteRenderer>().enabled = false;  // disable sprite, can't destroy right away because it will not play sound
            gameObject.GetComponent<BoxCollider2D>().enabled = false;   // disable collider so it only plays once

            Destroy(gameObject, 1f);    // destroy after one second

            sM.AddScore(ringPoints);
        }
    }
}
