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

    public GameObject controls;

    public Texture ssbControls;
    public Texture densityControls;
    public Texture alleyCombatantControls;
    public Texture flamingSymbolControls;
    public Texture sssControls;
    public Texture basementDwellerControls;
    public Texture hbbcControls;
    public Texture westernDentistControls;

    float lastInput;

    Texture[] controlsTextures;

    void Awake()
    {
        controlsTextures = new Texture[] { ssbControls, densityControls, alleyCombatantControls, flamingSymbolControls, sssControls, basementDwellerControls, hbbcControls, westernDentistControls };
        Button retryButtonPress = retryButton.GetComponent<Button>();
        Button quitToMenuButtonPress = quitToMenuButton.GetComponent<Button>();
        Button quitToDesktopButtonPress = quitToDesktopButton.GetComponent<Button>();
        retryButtonPress.onClick.AddListener(() => {
                                                        if (!(transform.parent.Find("Fade/Fade").gameObject.activeInHierarchy))
                                                        {
                                                            currentEventSystem.GetComponent<GlobalSoundController>().playSelect();
                                                            transform.parent.Find("Codec").gameObject.GetComponent<Codec>().stopAll();
                                                            transform.parent.Find("Codec").gameObject.SetActive(false);
                                                            transform.parent.Find("Fade/Fade").gameObject.SetActive(false);
                                                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                                                            transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                                                        }
                                                   });
        quitToMenuButtonPress.onClick.AddListener(() => {
                                                            currentEventSystem.GetComponent<GlobalSoundController>().playSelect();
                                                            transform.parent.Find("Codec").gameObject.GetComponent<Codec>().stopAll();
                                                            transform.parent.Find("Codec").gameObject.SetActive(false);
                                                            transform.parent.Find("Fade/Fade").gameObject.SetActive(false);
                                                            SceneManager.LoadScene(1);
                                                            transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
                                                        });
        quitToDesktopButtonPress.onClick.AddListener(() => {
                                                            currentEventSystem.GetComponent<GlobalSoundController>().playSelect();
                                                                Application.Quit();
                                                           });
        lastInput = 0.0f;
    }

    void OnEnable()
    {
        currentEventSystem.GetComponent<GlobalSoundController>().playSelect();
        controls.GetComponent<RawImage>().texture = controlsTextures[SceneManager.GetActiveScene().buildIndex - 2];
        Time.timeScale = 0;
        currentEventSystem.SetSelectedGameObject(retryButton.gameObject);
        retryButton.OnSelect(null);
    }

    void OnDisable()
    {
        Time.timeScale = 1;
        currentEventSystem.GetComponent<GlobalSoundController>().playSelect();
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
