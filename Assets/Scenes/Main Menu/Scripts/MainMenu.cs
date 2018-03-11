using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static float lastInput;
    public GameObject startScreen;

    void Start ()
    {
        lastInput = 0.0f;
	}

	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            startScreen.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }
}
