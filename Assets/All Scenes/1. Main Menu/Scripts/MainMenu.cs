using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static float lastInput;
    public GameObject startScreen;
    public EventSystem currentEventSystem;
    public bool gameCompleted;

    bool fading;

    void Start ()
    {
        lastInput = 0.0f;
        gameCompleted = true;
	}

    void OnEnable()
    {
        currentEventSystem.SetSelectedGameObject(null);
        StartCoroutine(fadeIn());
    }

    void Update ()
    {
        if (Input.GetButtonDown("Cancel") && fading == false)
        {
            currentEventSystem.SetSelectedGameObject(null);
            transform.Find("Fade").SetAsLastSibling();
            StartCoroutine(fadeOut());
        }

        if (Input.GetButtonDown("Submit"))
        {
            lastInput = Time.time;
        }

        if (gameCompleted == true)
        {
            transform.Find("LevelSelectButton/LockedText").gameObject.SetActive(false);
            transform.Find("LevelSelectButton/LockedButton").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("LevelSelectButton/LockedText").gameObject.SetActive(true);
            transform.Find("LevelSelectButton/LockedButton").gameObject.SetActive(true);
        }
    }

    IEnumerator fadeOut()
    {
        fading = true;
        Time.timeScale = 0;
        currentEventSystem.gameObject.GetComponent<MainMenuSoundController>().playSelect();
        transform.Find("Fade").gameObject.SetActive(true); ;
        transform.Find("Fade").SetAsLastSibling();
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
        transform.Find("PlayGameButton").SetAsLastSibling();
        transform.Find("LevelSelectButton").SetAsFirstSibling();
        transform.Find("SettingsButton").SetAsFirstSibling();
        startScreen.SetActive(true);
        fading = false;
        transform.gameObject.SetActive(false);
    }

    IEnumerator fadeIn()
    {
        fading = true;
        Time.timeScale = 0;
        transform.Find("Fade").gameObject.SetActive(true); ;
        transform.Find("Fade").SetAsLastSibling();
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
        transform.Find("LevelSelectButton").SetAsFirstSibling();
        transform.Find("SettingsButton").SetAsFirstSibling();
        currentEventSystem.SetSelectedGameObject(transform.Find("PlayGameButton").gameObject);
        fading = false;
    }
}
