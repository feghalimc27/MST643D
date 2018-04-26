using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public EventSystem currentEventSystem;
    public GameObject mainMenu;
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;
    public Button level7Button;
    public Button level8Button;
    public Button level9Button;
    public GameObject selectionCursor;
    public GameObject selectedLevelText;
    public Texture superSeoulBallText;
    public Texture densityText;
    public Texture alleyCombatantText;
    public Texture flamingSymbolText;
    public Texture superSeoulSistersText;
    public Texture spookyBasementText;
    public Texture visualNovelText; //
    public Texture westernDentistText;
    public Texture masterFootText;

    float lastInput;
    int sceneToLoad;

    void Start()
    {
        Button level1ButtonPress = level1Button.GetComponent<Button>();
        Button level2ButtonPress = level2Button.GetComponent<Button>();
        Button level3ButtonPress = level3Button.GetComponent<Button>();
        Button level4ButtonPress = level4Button.GetComponent<Button>();
        Button level5ButtonPress = level5Button.GetComponent<Button>();
        Button level6ButtonPress = level6Button.GetComponent<Button>();
        Button level7ButtonPress = level7Button.GetComponent<Button>();
        Button level8ButtonPress = level8Button.GetComponent<Button>();
        Button level9ButtonPress = level9Button.GetComponent<Button>();
        level1ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 2;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level2ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 3;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level3ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 4;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level4ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 5;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level5ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 6;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level6ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.25f)
                                                        {
                                                            sceneToLoad = 7;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level7ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 8;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level8ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 9;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        level9ButtonPress.onClick.AddListener(() => {
                                                        if (Time.time > MainMenu.lastInput + 1.0f)
                                                        {
                                                            sceneToLoad = 10;
                                                            StartCoroutine(fadeOut());
                                                        }
                                                    });
        lastInput = 0.0f;
    }

    void OnEnable()
    {
        currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
        StartCoroutine(fadeIn());
    }

    void Update()
    {
        selectionCursor.transform.position = currentEventSystem.currentSelectedGameObject.transform.position;

        if (Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(fadeToMenu());
        }

        if (Input.GetAxisRaw("Horizontal") > 0.25f || Input.GetAxisRaw("Horizontal") < -0.25f || Input.GetAxisRaw("Vertical") > 0.25f || Input.GetAxisRaw("Vertical") < -0.25f || Input.GetButtonDown("Submit"))
        {
            lastInput = Time.time;
        }

        if (currentEventSystem.currentSelectedGameObject == level1Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = superSeoulBallText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level2Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = densityText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level3Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = alleyCombatantText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level4Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = flamingSymbolText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level5Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = superSeoulSistersText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level6Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = spookyBasementText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level7Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = visualNovelText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level8Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = westernDentistText;
        }
        else if (currentEventSystem.currentSelectedGameObject == level9Button.gameObject)
        {
            selectedLevelText.GetComponent<RawImage>().texture = masterFootText;
        }

        if (currentEventSystem.currentSelectedGameObject == level1Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level2Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level3Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level7Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level4Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level2Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level3Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level8Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level5Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level3Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level2Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level9Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level6Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level4Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level5Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level6Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level7Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level5Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level6Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level4Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level2Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level8Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level6Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level5Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level4Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level3Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level9Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level7Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level8Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level9Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level4Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level8Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level9Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level7Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level5Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level2Button.gameObject);
            }
        }
        else if (currentEventSystem.currentSelectedGameObject == level9Button.gameObject && Time.time > lastInput + 0.25f)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level7Button.gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level8Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level6Button.gameObject);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.25f)
            {
                currentEventSystem.SetSelectedGameObject(level3Button.gameObject);
            }
        }
        else if (Time.time > lastInput + 0.25f)
        {
            currentEventSystem.SetSelectedGameObject(level1Button.gameObject);
        }
    }

    IEnumerator fadeIn()
    {
        Time.timeScale = 0;
        transform.Find("Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator fadeOut()
    {
        Time.timeScale = 0;
        transform.Find("Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        Time.timeScale = 1;
        transform.Find("Fade").gameObject.SetActive(false);
        DontDestroyOnLoad(new GameObject("levelTesting"));
        Instantiate(Resources.Load("Global Logic") as GameObject);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    IEnumerator fadeToMenu()
    {
        Time.timeScale = 0;
        transform.Find("Fade").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime)
        {
            transform.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        transform.Find("Fade").gameObject.SetActive(false);
        currentEventSystem.SetSelectedGameObject(mainMenu.transform.Find("PlayGameButton").gameObject);
        Time.timeScale = 1;
        transform.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
