using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject eventSystem;
    public GameObject mainMenu;

    bool fading;

    void OnEnable()
    {
        StartCoroutine(fadeIn());
        InvokeRepeating("pressStart", 0f, 1f);
        StartCoroutine(titleCenterRotate());
    }

    void OnDisable()
    {
        CancelInvoke("pressStart");
    }

    void Update()
    {
        if ((Input.GetButtonDown("Start") || Input.GetButtonDown("Submit")) && fading == false)
        {
            StartCoroutine(fadeOut());
        }
    }

    void pressStart()
    {
        transform.GetChild(2).gameObject.SetActive(!transform.GetChild(2).gameObject.activeInHierarchy);
    }

    IEnumerator titleCenterRotate()
    {
        for (float t = 0f; t < (2.0f * Mathf.PI); t += Time.deltaTime)
        {
            float newSize = (1.0f / 8.0f) * (Mathf.Sin(t)) + 1.0f;
            transform.GetChild(1).gameObject.transform.localScale = new Vector3(newSize, newSize, newSize);
            yield return null;
        }
        StartCoroutine(titleCenterRotate());
    }

    IEnumerator fadeOut()
    {
        fading = true;
        eventSystem.GetComponent<MainMenuSoundController>().playSelect();
        for (float t = 0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        mainMenu.SetActive(true);
        fading = false;
        transform.gameObject.SetActive(false);
    }

    IEnumerator fadeIn()
    {
        fading = true;
        for (float t = 0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        fading = false;
    }
}
