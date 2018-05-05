using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip introClip;
    public AudioClip player1WinClip;
    public AudioClip player2WinClip;

    public Image playerHealthBar;
    public Image enemyHealthBar;

    public RawImage gameText;

    public Texture round1;
    public Texture fight;
    public Texture p1Wins;
    public Texture p2Wins;

    Coroutine winCR;

    void Awake()
    {
        StartCoroutine(StartUp());
    }

    void Update ()
    {
        playerHealthBar.fillAmount = PlayerFighter.playerHealth / 100f;
        enemyHealthBar.fillAmount = EnemyFighter.enemyHealth / 100f;

        if (winCR == null && PlayerFighter.playerHealth <= 0)
        {
            winCR = StartCoroutine(P2Wins());
        }
        else if (winCR == null && EnemyFighter.enemyHealth <= 0)
        {
            winCR = StartCoroutine(P1Wins());
        }
    }

    IEnumerator StartUp()
    {
        Time.timeScale = 0;
        yield return null;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        audioSource.PlayOneShot(introClip);
        gameText.texture = round1;
        yield return new WaitForSecondsRealtime(1.75f);
        gameText.texture = fight;
        yield return new WaitForSecondsRealtime(1);
        gameText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator P1Wins()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(player1WinClip);
        yield return new WaitForSecondsRealtime(1.7f);
        gameText.gameObject.SetActive(true);
        gameText.texture = p1Wins;
        yield return new WaitForSecondsRealtime(3);
        gameText.gameObject.SetActive(false);
        Time.timeScale = 1;
        DontDestroyOnLoad(new GameObject("levelCompleted"));
    }

    IEnumerator P2Wins()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(player2WinClip);
        yield return new WaitForSecondsRealtime(1.7f);
        gameText.gameObject.SetActive(true);
        gameText.texture = p2Wins;
        yield return new WaitForSecondsRealtime(3);
        gameText.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }
}
