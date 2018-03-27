using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalMenu : MonoBehaviour
{
    public Button retryButton;
    public Button quitToMenuButton;
    public Button quitToDesktopButton;

    void Start()
    {
        Button retryButtonPress = retryButton.GetComponent<Button>();
        Button quitToMenuButtonPress = quitToMenuButton.GetComponent<Button>();
        Button quitToDesktopButtonPress = quitToDesktopButton.GetComponent<Button>();
        retryButtonPress.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy); });
        quitToMenuButtonPress.onClick.AddListener(() => { SceneManager.LoadScene(0); transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy); });
        quitToDesktopButtonPress.onClick.AddListener(() => { Application.Quit(); transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy); });
    }

    void OnEnable ()
    {
        Time.timeScale = 0;
	}

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    void Update ()
    {
		
	}
}
