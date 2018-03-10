using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    EventSystem currentEventSystem;

    void Start()
    {
        currentEventSystem = EventSystem.current;
    }

    void Update()
    {
        if (currentEventSystem.currentSelectedGameObject == transform.gameObject)
        {
            transform.SetAsLastSibling();

            if (Input.GetButtonDown("Submit"))
            {
                //LoadScene();
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("SettingsButton").gameObject);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("PlayGameButton").gameObject);
            }
        }
        else
        {
            transform.SetAsFirstSibling();
        }
    }

}
