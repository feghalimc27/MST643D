using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameButton : MonoBehaviour
{
    EventSystem currentEventSystem;

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

            if (Input.GetButtonDown("Submit"))
            {
                currentEventSystem.SetSelectedGameObject(null);
                transform.parent.Find("Fade").SetAsLastSibling();
                StartCoroutine(fadeOut());
            }

            if (Input.GetAxisRaw("Horizontal") > 0.1 && Time.time > MainMenu.lastInput + 0.25f)
            {
                transform.SetAsFirstSibling();
                MainMenu.lastInput = Time.time;
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("LevelSelectButton").gameObject);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.1 && Time.time > MainMenu.lastInput + 0.25f)
            {
                transform.SetAsFirstSibling();
                MainMenu.lastInput = Time.time;
                currentEventSystem.SetSelectedGameObject(transform.parent.Find("SettingsButton").gameObject);
            }
        }
        else
        {
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
        }
	}

    IEnumerator fadeOut()
    {
        for (float t = 0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.parent.Find("Fade").gameObject.GetComponent<RawImage>().color = new Color(0, 0, 0, t);
            yield return null;
        }
        SceneManager.LoadScene("Super Seoul Ball 3D");
    }
}
