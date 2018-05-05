using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Settings : MonoBehaviour
{
    public Text timeMinutes;
    public Text timeSeconds;
    public Text timeMilliseconds;

    public Image volumeBar;
    public Text volumeText;
    public Text volumeTextShadow;

    public GameObject mainMenu;
    public EventSystem eventSystem;
    public GameObject credits;

    bool fading;

    void Awake()
    {
        SaveLoad.Load();
        timeMinutes.text = ((int)(SaveLoad.bestScore / 60)).ToString("00");
        timeSeconds.GetComponent<Text>().text = ((int)(SaveLoad.bestScore % 60)).ToString("00");
        timeMilliseconds.GetComponent<Text>().text = (((int)(SaveLoad.bestScore * 100f) % 100)).ToString("00");
    }

    void OnEnable()
    {
        volumeBar.fillAmount = GlobalLogic.gameVolume;
        StartCoroutine(fadeIn());
    }

    void Update()
    {
        if (credits.activeInHierarchy == true)
        {
            if (Input.anyKeyDown)
            {
                credits.SetActive(false);
                fading = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel") && fading == false)
            {
                StartCoroutine(fadeToMenu());
            }

            if (fading == false)
            {
                if (Input.GetAxis("ADS") > 0.1)
                {
                    if (Input.GetAxis("FPSFire") > 0.1)
                    {
                        if (Input.GetButton("Submit"))
                        {
                            if (Input.GetButton("Start"))
                            {
                                credits.SetActive(true);
                                fading = true;
                            }
                        }
                    }
                }
            }

            if (Input.GetAxis("Horizontal") > 0.1)
            {
                volumeBar.fillAmount += 1f / 100f;
            }
            else if (Input.GetAxis("Horizontal") < -0.1)
            {
                volumeBar.fillAmount -= 1f / 100f;
            }
        }

        GlobalLogic.gameVolume = volumeBar.fillAmount;
        AudioListener.volume = GlobalLogic.gameVolume;
        volumeText.text = "" + (int)(volumeBar.fillAmount * 100f);
        volumeTextShadow.text = "" + (int)(volumeBar.fillAmount * 100f);
    }

    IEnumerator fadeIn()
    {
        fading = true;
        Time.timeScale = 0;
        transform.Find("Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
        fading = false;
    }

    IEnumerator fadeToMenu()
    {
        fading = true;
        Time.timeScale = 0;
        eventSystem.gameObject.GetComponent<MainMenuSoundController>().playSelect();
        transform.Find("Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(mainMenu.transform.Find("PlayGameButton").gameObject);
        Time.timeScale = 1;
        fading = false;
        transform.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
