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
    string[] allLines;
    int[] levelOrder;
    int currentString;
    int currentPos;
    Coroutine mikeCR;
    Coroutine typingCR;
    int currentLevel;
    string selectedLine;

    void Awake()
    {
        allBars = new Texture[] { bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9 };
        allLines = new string[] { "I used to be able to keep going with these lines, you know.\nThough whoever coded them got lazy I guess.",
                                  "I can't let you do that, Starmerry.",
                                  "Mo has been fired " + Random.Range(500, 50000) + " times, apparently.",
                                  "Ha ha! This next game will be your end!\nI have no idea what game it is, though, since whoever wrote these lines got too lazy.",
                                  "Who named this game?\nWhat does Merry Seoul Thoughts even stand for?",
                                  "I fight for my friends.",
                                  "Sure is taking you a while to beat this game, huh?\nI'm not even sure you'll finish, at this rate.",
                                  "Who named these games anyways? It's pretty obvious everything is just ripped off.\nLike, Alley Combatant? Obviously just Stree-",
                                  "Ban wobbling.",
                                  "Merry, turn the game console off right now!\nThe mission is a failure! Cut the power right now!",
                                  "Are you alright?\nSnake?\nSnake!?\nSNAAAAAKE!",
                                  "Hike Maze died for this." };
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
            selectedLine = "Hello? Is this thing on?\nOh.\nHa Ha! I have finally caught you Merry, and now you must pay, in the form of video games!\nCan you survive? Good luck.";
        }
        else if (levelOrder[currentLevel] == 0)
        {
            selectedLine = ".   .   .\nHuh?\nOh, it's you. You haven't given up yet? The \"Quit to Desktop\" button is right there, you know?\nOh well, looks like I'll have to take matters into my own, pixelated hands!\nYou face the Haze!";
        }
        else
        {
            selectedLine = allLines[currentString];
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
        transform.Find("Text Line 2").GetComponent<Text>().text = "";
        currentString = Random.Range(0, allLines.Length);
        currentPos = 0;
        mikeCR = StartCoroutine(mikeTalking());
        typingCR = StartCoroutine(textType());
    }

    void OnDisable()
    {
        transform.Find("Text Line").GetComponent<Text>().text = "";
        transform.Find("Text Line 2").GetComponent<Text>().text = "";
        currentPos = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            currentPos = selectedLine.Length;
            transform.Find("Text Line").GetComponent<Text>().text = selectedLine;
            transform.Find("Text Line 2").GetComponent<Text>().text = selectedLine;
        }
    }

    IEnumerator mikeTalking()
    {
        transform.Find("Bar").gameObject.SetActive(true);
        transform.Find("Mike Highlight").gameObject.SetActive(!transform.Find("Mike Highlight").gameObject.activeInHierarchy);
        transform.Find("Bar").GetComponent<RawImage>().texture = allBars[Random.Range(0, 9)];
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.5f));
        mikeCR = StartCoroutine(mikeTalking());
    }

    IEnumerator textType()
    {
        if (currentPos < selectedLine.Length)
        {
            transform.Find("Text Line").GetComponent<Text>().text += "" + selectedLine[currentPos];
            transform.Find("Text Line 2").GetComponent<Text>().text += "" + selectedLine[currentPos];
            currentPos++;
            yield return new WaitForSecondsRealtime(0.1f);
            typingCR = StartCoroutine(textType());
        }
        else
        {
            StopCoroutine(mikeCR);
            transform.Find("Mike Highlight").gameObject.SetActive(false);
            transform.Find("Bar").gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(3.0f);
            yield return new WaitUntil(() => levelLoader.isDone);
            transform.gameObject.SetActive(false);
        }
    }
    
    public void stopAll()
    {
        if (mikeCR != null && typingCR != null)
        {
            StopCoroutine(mikeCR);
            StopCoroutine(typingCR);
        }
        
    }
}
