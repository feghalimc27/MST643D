using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalLogic : MonoBehaviour
{
    public static float gameVolume = 1;

    private static GlobalLogic currentInstance;

    private static float startTime;
    public static float currentTime;
    
    public static bool finalBossKilled;

    public GameObject eventSystemObj;

    GameObject levelCompleted;
    GameObject levelTesting;

    void Awake ()
    {
        if (!currentInstance)
        {
            currentInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        startTime = -1;
        finalBossKilled = false;
    }

    void OnEnable()
    {
        StartCoroutine(fadeIn());
        try
        {
            levelTesting = GameObject.Find("levelTesting").gameObject;
        }
        catch (NullReferenceException e) { }
    }

    void Update ()
    {
        AudioListener.volume = gameVolume;

        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (startTime == -1) && (!(transform.Find("Codec").gameObject.activeInHierarchy)))
            {
                startTime = Time.time;
                transform.Find("Timer").gameObject.SetActive(true);
            }

            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (transform.Find("Timer").gameObject.activeInHierarchy == true) && (finalBossKilled == false))
            {
                currentTime = Time.time - startTime;
                transform.Find("Timer/Timer Minutes").GetComponent<Text>().text = ((int)(currentTime / 60)).ToString("00");
                transform.Find("Timer/Timer Seconds").GetComponent<Text>().text = ((int)(currentTime % 60)).ToString("00");
                transform.Find("Timer/Timer Milliseconds").GetComponent<Text>().text = (((int)(currentTime * 100f) % 100)).ToString("00");
            }

            if (Input.GetButtonDown("Start"))
            {
                transform.Find("Global Menu").gameObject.SetActive(!transform.Find("Global Menu").gameObject.activeInHierarchy);
            }

            try
            {
                levelCompleted = GameObject.Find("levelCompleted").gameObject;
                if (levelCompleted != null)
                {
                    if (levelTesting != null)
                    {
                        Destroy(levelCompleted);
                        StartCoroutine(fadeOutSpecial());
                    }
                    else if (SceneManager.GetActiveScene().buildIndex == 9)
                    {
                        SaveLoad.Load();
                        if (currentTime > SaveLoad.bestScore)
                        {
                            SaveLoad.bestScore = currentTime;
                            SaveLoad.Save();
                        }
                        Destroy(levelCompleted);
                        StartCoroutine(fadeOutSpecial());
                    }
                    else
                    {
                        Destroy(levelCompleted);
                        StartCoroutine(fadeOut());
                    }
                }
            }
            catch (NullReferenceException e) { }
        }
        else
        {
            if (levelTesting != null)
            {
                Destroy(levelTesting);
            }
            transform.Find("Fade").GetComponent<Canvas>().sortingOrder = 8;
            transform.Find("Fade/Fade").gameObject.SetActive(false);
            Destroy(transform.gameObject);
        }
    }

    IEnumerator fadeIn()
    {
        Time.timeScale = 0;
        transform.Find("Fade/Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("Fade/Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator fadeOut()
    {
        Time.timeScale = 0;
        eventSystemObj.GetComponent<GlobalSoundController>().playCodecCall();
        yield return new WaitForSecondsRealtime(eventSystemObj.GetComponent<GlobalSoundController>().codecCall.length);
        transform.Find("Fade/Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        SceneManager.LoadScene(11);
        yield return null;
        transform.Find("Codec").gameObject.SetActive(true);
        yield return new WaitUntil(() => !(transform.Find("Codec").gameObject.activeInHierarchy));
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("Fade/Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator fadeOutSpecial()
    {
        Time.timeScale = 0;
        transform.Find("Fade/Fade").gameObject.SetActive(true);
        transform.Find("Fade").GetComponent<Canvas>().sortingOrder = 12;
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
