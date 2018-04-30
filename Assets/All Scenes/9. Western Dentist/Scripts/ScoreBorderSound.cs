using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBorderSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip scoreOrbClip;

    float lastSound;

    void Start()
    {
        lastSound = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointProjectile" && Time.time > lastSound + 0.01f)
        {
            lastSound = Time.time;
            audioSource.PlayOneShot(scoreOrbClip);
        }
    }
}
