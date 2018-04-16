using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    EventSystem currentEventSystem;

    public GameObject levelSelect;

    void Start()
    {
        currentEventSystem = EventSystem.current;
    }

    void FixedUpdate()
    {
        if (currentEventSystem.currentSelectedGameObject == transform.gameObject)
        {
            transform.SetAsLastSibling();
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(800 * 1.25f, 600 * 1.25f);
            transform.Find("LockedButton").GetComponent<RectTransform>().sizeDelta = new Vector2(800 * 1.25f, 600 * 1.25f);

            if (transform.parent.gameObject.GetComponent<MainMenu>().gameCompleted == true && Input.GetButtonDown("Submit"))
            {
                transform.parent.gameObject.SetActive(false);
                levelSelect.SetActive(true);
            }

            if (Input.GetAxisRaw("Horizontal") > 0.1 && Time.time > MainMenu.lastInput + 0.25f)
            {
                transform.SetAsFirstSibling();
                MainMenu.lastInput = Time.time;
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("SettingsButton").gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.1 && Time.time > MainMenu.lastInput + 0.25f)
            {
                transform.SetAsFirstSibling();
                MainMenu.lastInput = Time.time;
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("PlayGameButton").gameObject);
            }
        }
        else
        {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
            transform.Find("LockedButton").GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
        }
    }

}
