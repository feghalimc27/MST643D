using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalMenu : MonoBehaviour
{
    public Button retryButton;
    public Button quitToMenuButton;
    public Button quitToDesktopButton;
    public EventSystem currentEventSystem;

    float lastInput;

    void Start()
    {
        Button retryButtonPress = retryButton.GetComponent<Button>();
        Button quitToMenuButtonPress = quitToMenuButton.GetComponent<Button>();
        Button quitToDesktopButtonPress = quitToDesktopButton.GetComponent<Button>();
        retryButtonPress.onClick.AddListener(() => {
                                                        if (!(transform.parent.Find("Fade/Fade").gameObject.activeInHierarchy))
                                                        {
                                                            transform.parent.Find("Codec").gameObject.GetComponent<Codec>().stopAll();
                                                            transform.parent.Find("Codec").gameObject.SetActive(false);
                                                            transform.parent.Find("Fade/Fade").gameObject.SetActive(false);
                                                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                                                            transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                                                        }
                                                   });
        quitToMenuButtonPress.onClick.AddListener(() => {
                                                            transform.parent.Find("Codec").gameObject.GetComponent<Codec>().stopAll();
                                                            transform.parent.Find("Codec").gameObject.SetActive(false);
                                                            transform.parent.Find("Fade/Fade").gameObject.SetActive(false);
                                                            SceneManager.LoadScene(0);
                                                            transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                                                        });
        quitToDesktopButtonPress.onClick.AddListener(() => {
                                                                Application.Quit();
                                                           });
        lastInput = 0.0f;
    }

    void OnEnable()
    {
        Time.timeScale = 0;
        currentEventSystem.SetSelectedGameObject(retryButton.gameObject);
        retryButton.OnSelect(null);
    }

    void OnDisable()
    {
        Time.timeScale = 1;
        currentEventSystem.SetSelectedGameObject(null);
    }

    void Update()
    {
        Time.timeScale = 0;

        if (transform.parent.Find("Fade/Fade").gameObject.activeInHierarchy)
        {
            retryButton.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
        else
        {
            retryButton.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f || Input.GetButtonDown("Submit"))
        {
            lastInput = Time.unscaledTime;
        }

        if (currentEventSystem.currentSelectedGameObject == retryButton.gameObject)
        {
            if (Input.GetAxisRaw("Vertical") > 0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(quitToDesktopButton.gameObject);
                lastInput = Time.unscaledTime;
            }
            else if (Input.GetAxisRaw("Vertical") < -0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(quitToMenuButton.gameObject);
                lastInput = Time.unscaledTime;
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == quitToMenuButton.gameObject)
        {
            if (Input.GetAxisRaw("Vertical") > 0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(retryButton.gameObject);
                lastInput = Time.unscaledTime;
            }
            else if (Input.GetAxisRaw("Vertical") < -0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(quitToDesktopButton.gameObject);
                lastInput = Time.unscaledTime;
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == quitToDesktopButton.gameObject)
        {
            if (Input.GetAxisRaw("Vertical") > 0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(quitToMenuButton.gameObject);
                lastInput = Time.unscaledTime;
            }
            else if (Input.GetAxisRaw("Vertical") < -0.1 && Time.unscaledTime > lastInput + 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(retryButton.gameObject);
                lastInput = Time.unscaledTime;
            }
        }
        else
        {
            currentEventSystem.SetSelectedGameObject(retryButton.gameObject);
        }
    }
}
