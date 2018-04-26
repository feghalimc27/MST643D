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
    string[] selectedLines;
    int currentLine;
    Coroutine startCR;
    Coroutine mikeCR;
    Coroutine typingCR;
    Coroutine shutdownCR;
    int currentLevel;
    bool startingUp;
    float timeBetweenCharacters;

    void Awake()
    {
        allBars = new Texture[] { bar1, bar2, bar3, bar4, bar5, bar6, bar7, bar8, bar9 };
        levelOrder = new int[] { 3, 4, 5, 6, 7, 8, 9 };
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
        timeBetweenCharacters = 0.05f;
        levelLoader = SceneManager.LoadSceneAsync(levelOrder[currentLevel], LoadSceneMode.Single);
        if (currentLevel == 0)
        {
            selectedLines = new string[] { "Is this thing on? Oh, looks like it.",
                                           "Kind of familiar interface here, huh? Wonder what it reminds me of.",
                                           "Nevermind that. I have taken over your game, Merry. No more of this monkey and ball business.",
                                           "I think we'll play a little game. Or seven of them, to be more specific.",
                                           "See if you can survive. But don't worry, you can always just 'Quit to Desktop'! Hahaha!",
                                           "Now, how do I turn this thing off? That nerd with the glasses didn't help me out much. Oh, there it is, the red but-" };
        }
        else if (levelOrder[currentLevel] == 3)
        {
            selectedLines = new string[] { "Snake, your mission is to infiltrate the enemy base and retrieve the intelligence briefcase.",
                                           "Remember, stealth is of utmost importance. If you are caught, it's game over.",
                                           "Just kidding.",
                                           "I think in this next one you have to escape from some zombies. Or something like that.",
                                           "If you ask me, it's not a very original idea, but I'm not the one who programmed this mess.",
                                           "Oh, you get a gun at least. Have fun. Or not, I'm just the bad guy." };
        }
        else if (levelOrder[currentLevel] == 4)
        {
            selectedLines = new string[] { "Wait a second, is that building familiar at all to you? Oh, I guess you can't see it yet.",
                                           "Well, whatever. Anyways, uh, this next one's easy. Just one of those arcade fighting games.",
                                           "Punch and kick the other guy to death, right? Although I feel a little bad.",
                                           "This bald guy looks a little funny, is all. You'll see in a moment.",
                                           "And what's with the title of this game? Alley Combatant? That's just Stree-" };
        }
        else if (levelOrder[currentLevel] == 5)
        {
            selectedLines = new string[] { "This next one is different, that's for sure.",
                                           "Looks like whoever made this one wants you to, uh, siege the castle?",
                                           "Something like that. He also told me he fights for his friends, and that he wants PM Lyn back?",
                                           "No idea who PM Lyn is.",
                                           "Well, go for it, I guess. Or lose horribly, that's probably better for me." };
        }
        else if (levelOrder[currentLevel] == 6)
        {
            selectedLines = new string[] { "This next game is called Super Seoul Sisters?",
                                           "Isn't that like, indirect copyright infringement?",
                                           "I've been told by my lawyers I make a special cameo in this level, but I have no idea what that is.",
                                           "If I were you, I would be very worried. Since I'm the best and all." };
        }
        else if (levelOrder[currentLevel] == 7)
        {
            selectedLines = new string[] { "No idea what to say about this next one.",
                                           "I'll just leave it to you, I guess." };
        }
        else if (levelOrder[currentLevel] == 8)
        {
            selectedLines = new string[] { "A visual novel? Really?",
                                           "I'm just letting you know now, I didn't approve this. I wanted cool action games!",
                                           "I've heard bad things about visual novels, anyways.",
                                           "Apparently this guy named Dan made one before, and everyone who played it changed.",
                                           "They were all obsessed with some person named Monika. Kind of scary if you ask me.",
                                           "\t.\t.\t.\t",
                                           "I've just been informed that Hike Mize died for this. No idea what that's suppose to mean.",
                                           "Whatever. I hope you lose." };
        }
        else if (levelOrder[currentLevel] == 9)
        {
            selectedLines = new string[] { "Is this some kind of reference? I can tell it's a reference to something, but I'm lost to it.",
                                           "It's called Western Dentist, and it looks like the title is in, Japanese, I think?",
                                           "A bullet hell? That's what it is apparently. Have fun with that one, yeesh." };
        }
        else if (levelOrder[currentLevel] == 10)
        {
            selectedLines = new string[] { "\t.\t.\t.\t.\t.\t.\t.\t.\t.\t",
                                           "Huh? Wait, you're still here? I thought you'd quit by now.",
                                           "I mean, you can always still quit you know. It'd be much easier. Just pause, then select that 'Quit to Desktop' button.",
                                           "You aren't going to? That's kind of lame, you know. Now I have to do something myself, that's far too much work.",
                                           "Cut me some slack would ya?",
                                           "Ugh, fine. I don't know how you made it this far, but I guess I've got no choice.",
                                           "Now you have to face me!",
                                           "Our battle arena, and your final resting place, will be the stage called 'Final Location'!",
                                           "Prepare yourself, Merry. Because there's no way I can lose, probably!" };
        }


        if (currentLevel == (levelOrder.Length - 1))
        {
            levelOrder[currentLevel] = 10;
        }
        else
        {
            currentLevel++;
        }
        transform.Find("Text Line").GetComponent<Text>().text = "";
        currentLine = 0;
        startCR = StartCoroutine(StartUp());
        startingUp = true;
    }

    void OnDisable()
    {
        stopAll();
        transform.Find("Text Line").GetComponent<Text>().text = "";
        currentLine = 0;
        startingUp = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && startingUp == false)
        {
            timeBetweenCharacters = 0.0f;
        }
    }

    IEnumerator StartUp()
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
        startingUp = false;
        typingCR = StartCoroutine(TextType());
    }

    IEnumerator MikeTalking()
    {
        transform.Find("Mike Talk").gameObject.SetActive(!transform.Find("Mike Talk").gameObject.activeInHierarchy);
        transform.Find("Bar").GetComponent<RawImage>().texture = allBars[Random.Range(5, 9)];
        yield return new WaitForSecondsRealtime(Random.Range(0.1f, 0.5f));
        mikeCR = StartCoroutine(MikeTalking());
    }

    IEnumerator TextType()
    {
        if (currentLine < selectedLines.Length)
        {
            transform.Find("Text Line").GetComponent<Text>().text = "";
            mikeCR = StartCoroutine(MikeTalking());
            for (int j = 0; j < selectedLines[currentLine].Length; j++)
            {
                transform.Find("Text Line").GetComponent<Text>().text += "" + selectedLines[currentLine][j];
                yield return new WaitForSecondsRealtime(timeBetweenCharacters);
            }
            StopCoroutine(mikeCR);
            transform.Find("Bar").GetComponent<RawImage>().texture = allBars[5];
            transform.Find("Mike Talk").gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(1.0f);
            timeBetweenCharacters = 0.05f;
            currentLine++;
            typingCR = StartCoroutine(TextType());
        }
        else
        {
            if (shutdownCR == null)
            {
                shutdownCR = StartCoroutine(ShutDown());
            }
        }
        
    }

    IEnumerator ShutDown()
    {
        transform.Find("Text Line").GetComponent<Text>().text = "";
        if (mikeCR != null)
        {
            StopCoroutine(mikeCR);
        }
        if (typingCR != null)
        {
            StopCoroutine(typingCR);
        }
        if (startCR != null)
        {
            StopCoroutine(startCR);
        }
        transform.Find("Mike Talk").gameObject.SetActive(false);
        for (int i = 0; i < 6; i++)
        {
            transform.Find("Bar").GetComponent<RawImage>().texture = allBars[5 - i];
            yield return new WaitForSecondsRealtime(0.1f);
        }
        transform.Find("Bar").gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1.0f);
        for (float t = 0f; t < 1.0f; t += Time.unscaledDeltaTime * 3)
        {
            transform.Find("Portraits Center").localScale = new Vector3(1, Mathf.Pow(1 - t, 2), 1);
            yield return null;
        }
        transform.Find("Portraits Center").gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(3.0f);
        yield return new WaitUntil(() => levelLoader.isDone);
        transform.gameObject.SetActive(false);
    }
    
    public void stopAll()
    {
        if (mikeCR != null)
        {
            StopCoroutine(mikeCR);
            mikeCR = null;
        }
        if (typingCR != null)
        {
            StopCoroutine(typingCR);
            typingCR = null;
        }
        if (startCR != null)
        {
            StopCoroutine(startCR);
            startCR = null;
        }
        if (shutdownCR != null)
        {
            StopCoroutine(shutdownCR);
            shutdownCR = null;
        }
    }
}
