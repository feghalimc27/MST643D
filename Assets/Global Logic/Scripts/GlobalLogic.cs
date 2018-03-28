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
	
	void Update ()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (startTime == -1))
            {
                startTime = Time.unscaledTime;
                transform.Find("Timer").gameObject.SetActive(true);
            }

            if ((SceneManager.GetActiveScene().name != "Super Seoul Ball 3D") && (transform.Find("Timer").gameObject.activeInHierarchy == true) && (finalBossKilled == false))
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

            if ((SceneManager.GetActiveScene().name == "Super Seoul Ball 3D") && (Time.timeSinceLevelLoad > 15.0f))
            {
                SceneManager.LoadScene(2);
            }

            if ((SceneManager.GetActiveScene().name == "Density") && (Time.timeSinceLevelLoad > 15.0f))
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            transform.Find("Timer").gameObject.SetActive(false);
        }
    }
}
