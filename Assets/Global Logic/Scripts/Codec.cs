using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Codec : MonoBehaviour
{
    public Texture bar1;
    public Texture bar2;
    public Texture bar3;
    public Texture bar4;
    public Texture bar5;
    public Texture bar6;
    public Texture bar7;
    public Texture bar8;
    public Texture bar9;
    public AsyncOperation levelLoader;

    Texture[] allBars;
    int[] levelOrder;
    int currentPos;
    Coroutine startCR;
    Coroutine mikeCR;
    Coroutine typingCR;
    int currentLevel;
    string selectedLine;

    void Awake()
    {
        allBars = new Texture[] { bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9 };
        levelOrder = new int[] { 2, 3, 4, 5, 6, 7, 8 };
        for (int i = 0; i < levelOrder.Length; i++)
        {
            int temp = levelOrder[i];
            int r = Random.Range(i, levelOrder.Length);
            levelOrder[i] = levelOrder[r];
            levelOrder[r] = temp;
        }
        currentLevel = 0;
    }

    void OnEnable()
    {
        levelLoader = SceneManager.LoadSceneAsync(levelOrder[currentLevel], LoadSceneMode.Single);
        if (currentLevel == 0)
        {
            selectedLine = "Start Game";
        }
        else if (levelOrder[currentLevel] == 2)
        {
            selectedLine = "Density";
        }
        else if (levelOrder[currentLevel] == 3)
        {
            selectedLine = "Alley Combatant";
        }
        else if (levelOrder[currentLevel] == 4)
        {
            selectedLine = "Flaming Symbol";
        }
        else if (levelOrder[currentLevel] == 5)
        {
            selectedLine = "Super Seoul Sisters";
        }
        else if (levelOrder[currentLevel] == 6)
        {
            selectedLine = "Delve";
        }
        else if (levelOrder[currentLevel] == 7)
        {
            selectedLine = "Visual Novel";
        }
        else if (levelOrder[currentLevel] == 8)
        {
            selectedLine = "Western Dentist";
        }
        else if (levelOrder[currentLevel] == 0)
        {
            selectedLine = "Final Boss";
        }


        if (currentLevel == (levelOrder.Length - 1))
        {
            levelOrder[currentLevel] = 0; //DEBUG, set to boss later
        }
        else
        {
            currentLevel++;
        }
        transform.Find("Text Line").GetComponent<Text>().text = "";
        currentPos = 0;
        startCR = StartCoroutine(startUp());
    }

    void OnDisable()
    {
        transform.Find("Text Line").GetComponent<Text>().text = "";
        currentPos = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            currentPos = selectedLine.Length;
            transform.Find("Text Line").GetComponent<Text>().text = selectedLine;
        }
    }

    IEnumerator startUp()
    {
        transform.Find("Bar").gameObject.SetActive(true);
        for (int i = 0; i < 9; i++)
        {
            transform.Find("Bar").GetComponent<RawImage>().texture = allBars[i];
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(1.0f);
        transform.Find("Portraits Center").gameObject.SetActive(true);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime * 3)
        {
            transform.Find("Portraits Center").localScale = new Vector3(1, Mathf.Pow(t, 2), 1);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1.0f);
        mikeCR = StartCoroutine(mikeTalking());
        typingCR = StartCoroutine(textType());
    }

    IEnumerator mikeTalking()
    {
        transform.Find("Mike Talk").gameObject.SetActive(!transform.Find("Mike Talk").gameObject.activeInHierarchy);
        transform.Find("Bar").GetComponent<RawImage>().texture = allBars[Random.Range(5, 9)];
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.5f));
        mikeCR = StartCoroutine(mikeTalking());
    }

    IEnumerator textType()
    {
        if (currentPos < selectedLine.Length)
        {
            transform.Find("Text Line").GetComponent<Text>().text += "" + selectedLine[currentPos];
            currentPos++;
            yield return new WaitForSecondsRealtime(0.1f);
            typingCR = StartCoroutine(textType());
        }
        else
        {
            if (mikeCR != null)
            {
                StopCoroutine(mikeCR);
            }
            transform.Find("Mike Talk").gameObject.SetActive(false);
            for (int i = 0; i < 9; i++)
            {
                transform.Find("Bar").GetComponent<RawImage>().texture = allBars[8-i];
                yield return new WaitForSecondsRealtime(0.1f);
            }
            transform.Find("Bar").gameObject.SetActive(false);
            for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime * 3)
            {
                transform.Find("Portraits Center").localScale = new Vector3(1, Mathf.Pow(1-t, 2), 1);
                yield return null;
            }
            transform.Find("Portraits Center").gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(3.0f);
            yield return new WaitUntil(() => levelLoader.isDone);
            transform.gameObject.SetActive(false);
        }
    }
    
    public void stopAll()
    {
        if (mikeCR != null && typingCR != null)
        {
            StopCoroutine(startCR);
            StopCoroutine(mikeCR);
            StopCoroutine(typingCR);
        }
    }
}
