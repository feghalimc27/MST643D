using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BootScreen : MonoBehaviour
{
    public AudioSource startAudio;

    private void Awake()
    {
        StartCoroutine(Boot());
    }

    IEnumerator Boot()
    {
        yield return new WaitForSeconds(2f);
        transform.Find("Background").gameObject.SetActive(true);
        transform.Find("JEGA").gameObject.SetActive(true);
        transform.Find("Swipe Effect").gameObject.SetActive(true);
        for (float t = -218f; t < 206.5f; t += Time.deltaTime * 550)
        {
            transform.Find("Swipe Effect").gameObject.GetComponent<RawImage>().rectTransform.localPosition = new Vector3(t, 0, 0);
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        transform.Find("Swipe Effect").gameObject.SetActive(false);
        for (float t = 0f; t < 1.0f; t += Time.deltaTime * 4f)
        {
            transform.Find("JEGA").gameObject.transform.GetComponent<RawImage>().color = new Color(1, 1, 1, t);
            yield return null;
        }
        for (float t = 0f; t < 1.0f; t += Time.deltaTime * 4f)
        {
            transform.Find("JEGA").gameObject.transform.GetComponent<RawImage>().color = new Color(1, 1 - t, 1, 1);
            yield return null;
        }
        startAudio.Play();
        yield return new WaitForSeconds(3f);
        for (float t = 0f; t < 1.0f; t += Time.deltaTime * 3f)
        {
            transform.Find("JEGA").gameObject.transform.GetComponent<RawImage>().color = new Color(1 - t, 1 - t, 1 - t, 1);
            transform.Find("Background").gameObject.transform.GetComponent<RawImage>().color = new Color(1 - t, 1 - t, 1, 1);
            yield return null;
        }
        for (float t = 0f; t < 1.0f; t += Time.deltaTime * 3f)
        {
            transform.Find("JEGA").gameObject.transform.GetComponent<RawImage>().color = new Color(0, 0, 0, 1 - t);
            transform.Find("Background").gameObject.transform.GetComponent<RawImage>().color = new Color(0, 0, 1, 1 - t);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
