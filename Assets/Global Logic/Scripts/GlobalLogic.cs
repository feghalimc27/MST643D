using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalLogic : MonoBehaviour
{
    private static GlobalLogic currentInstance;

    private static float startTime;
    public static float currentTime;
    
    public static bool finalBossKilled;

    bool pauseTimer;

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
        pauseTimer = true;
    }
	
	void Update ()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (startTime == -1) && (!(transform.Find("Codec").gameObject.activeInHierarchy)))
            {
                startTime = Time.unscaledTime;
                transform.Find("Timer").gameObject.SetActive(true);
            }

            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (transform.Find("Timer").gameObject.activeInHierarchy == true) && (finalBossKilled == false)  && (pauseTimer == false))
            {
                currentTime = Time.unscaledTime - startTime;
                transform.Find("Timer/Timer Minutes").GetComponent<Text>().text = ((int)(currentTime / 60)).ToString("00");
                transform.Find("Timer/Timer Seconds").GetComponent<Text>().text = ((int)(currentTime % 60)).ToString("00");
                transform.Find("Timer/Timer Milliseconds").GetComponent<Text>().text = (((int)(currentTime * 100f) % 100)).ToString("00");
            }

            if (Input.GetButtonDown("Start"))
            {
                transform.Find("Global Menu").gameObject.SetActive(!transform.Find("Global Menu").gameObject.activeInHierarchy);
            }

            if ((SceneManager.GetActiveScene().name == "Super Seoul Ball 3D") && (Time.timeSinceLevelLoad > 5.0f))
            {
                StartCoroutine(fadeOut());
            }
        }
        else
        {
            transform.Find("Timer").gameObject.SetActive(false);
        }
    }

    IEnumerator fadeOut()
    {
        Time.timeScale = 0;
        pauseTimer = true;
        transform.Find("Fade/Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        transform.Find("Codec").gameObject.SetActive(true);
        yield return new WaitUntil(() => !(transform.Find("Codec").gameObject.activeInHierarchy));
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade/Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        pauseTimer = false;
        Time.timeScale = 1;
    }
}
