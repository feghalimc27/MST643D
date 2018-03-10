using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    void Start ()
    {
        InvokeRepeating("pressStart", 0f, 1f);
        StartCoroutine(titleCenterRotate());
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            transform.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
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
}
