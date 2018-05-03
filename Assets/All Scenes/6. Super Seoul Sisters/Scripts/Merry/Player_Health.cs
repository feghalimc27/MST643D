using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public AudioClip playDeath;
    public AudioSource deathSound;
    public bool hasDeathSoundPlayed = false;


    void Start()
    {
        deathSound = GetComponent<AudioSource>();   // assign AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<BoxCollider2D>().enabled == false)
        {
            hasDeathSoundPlayed = true;
        }
		if (gameObject.transform.position.y < -6.38f)
        {
            if (hasDeathSoundPlayed == false)
            {
                deathSound.PlayOneShot(playDeath); // play sound
                hasDeathSoundPlayed = true;
                Camera.main.GetComponent<Camera_System>().enabled = false;
            }
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(LoadLevelAfterDelay(.75f));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Super Seoul Sisters");
    }

    public void DiedToMonster()
    {
        hasDeathSoundPlayed = true;
    }
}
