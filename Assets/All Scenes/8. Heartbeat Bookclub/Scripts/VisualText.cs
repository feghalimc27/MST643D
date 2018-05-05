using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualText : MonoBehaviour
{

    public Text text;

    //Object that holds both names
    public GameObject myobject;

    public GameObject choiceOne;

    public GameObject choiceTwo;

    //Mary Soul the other char
    public Text name1;

    //Merry Seoul which is us
    public Text name2;

    public Text choiceText1;

    public Text choiceText2;

    public Image classroom, hallway, roof, stairs, merry;

    private enum States { begin, begin2, class1, class2, class3, class4, class5, class6, class7, class8, dead1, dead2, hallway, hallway1, hallway2, hallway3, hallway4, hallway5, hallway6, hallway7, dead3, dead4, hallway8, hallway9, hallway10, hallway11, hallway12, hallway13, hallway14, hallway15, hallway16, hallway17, stairs, dead5, dead6, dead7, dead8, dead9, dead10, stairs1, stairs2, stairs3, stairs4, stairs5, stairs6, stairs7, roof, roof1, roof2 }

    private States myState;

    // Use this for initialization
    void Start()
    {
        text.supportRichText = true;
        text.text = "Welcome to the Heartbeat Bookclub.";
        myState = States.begin;
    }

    // Update is called once per frame
    void Update()
    {
        print(myState);
        if (myState == States.begin)          { state_begin(); }
        else if (myState == States.begin2)    { state_begin2(); }
        else if (myState == States.class1)    { state_class1(); }
        else if (myState == States.class2)    { state_class2(); }
        else if (myState == States.class3)    { state_class3(); }
        else if (myState == States.class4)    { state_class4(); }
        else if (myState == States.class5)    { state_class5(); }
        else if (myState == States.class6)    { state_class6(); }
        else if (myState == States.class7)    { state_class7(); }
        else if (myState == States.class8)    { state_class8(); }
        else if (myState == States.dead1)     { state_dead1(); }
        else if (myState == States.dead2)     { state_dead2(); }
        else if (myState == States.hallway)   { state_hallway(); }
        else if (myState == States.hallway1)  { state_hallway1(); }
        else if (myState == States.hallway2)  { state_hallway2(); }
        else if (myState == States.hallway3)  { state_hallway3(); }
        else if (myState == States.hallway4)  { state_hallway4(); }
        else if (myState == States.hallway5)  { state_hallway5(); }
        else if (myState == States.hallway6)  { state_hallway6(); }
        else if (myState == States.hallway7)  { state_hallway7(); }
        else if (myState == States.dead3)     { state_dead3(); }
        else if (myState == States.dead4)     { state_dead4(); }
        else if (myState == States.hallway8)  { state_hallway8(); }
        else if (myState == States.hallway9)  { state_hallway9(); }
        else if (myState == States.hallway10) { state_hallway10(); }
        else if (myState == States.hallway11) { state_hallway11(); }
        else if (myState == States.hallway12) { state_hallway12(); }
        else if (myState == States.hallway13) { state_hallway13(); }
        else if (myState == States.hallway14) { state_hallway14(); }
        else if (myState == States.hallway15) { state_hallway15(); }
        else if (myState == States.hallway16) { state_hallway16(); }
        else if (myState == States.hallway17) { state_hallway17(); }
        else if (myState == States.stairs)    { state_stairs(); }
        else if (myState == States.dead5)     { state_dead5(); }
        else if (myState == States.dead6)     { state_dead6(); }
        else if (myState == States.dead7)     { state_dead7(); }
        else if (myState == States.dead8)     { state_dead8(); }
        else if (myState == States.dead9)     { state_dead9(); }
        else if (myState == States.dead10)    { state_dead10(); }
        else if (myState == States.stairs1)   { state_stairs1(); }
        else if (myState == States.stairs2)   { state_stairs2(); }
        else if (myState == States.stairs3)   { state_stairs3(); }
        else if (myState == States.stairs4)   { state_stairs4(); }
        else if (myState == States.stairs5)   { state_stairs5(); }
        else if (myState == States.stairs6)   { state_stairs6(); }
        else if (myState == States.stairs7)   { state_stairs7(); }
        else if (myState == States.roof)      { state_roof(); }
        else if (myState == States.roof1)     { state_roof1(); }
        else if (myState == States.roof2)     { state_roof2(); }
    }

    void state_begin()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = false;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = ". . .";
        if (Input.GetButtonDown("Jump")) { myState = States.begin2; }
    }

    void state_begin2()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = false;
        text.text = "Oh, hey! You're finally up. I was starting to get worried you might've died! Hah.\n"
            + "\n<i>You quickly stand up.</i>";
        
        if (Input.GetButtonDown("Jump")) { myState = States.class1; }
    }

    void state_class1()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Uh, so who are you?";
        if (Input.GetButtonDown("Jump")) { myState = States.class2; }
    }

    void state_class2()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "My name is Mary! Mary Seoul.\n"
            + "When I walked in, you were unconscious on the floor.";
        if (Input.GetButtonDown("Jump")) { myState = States.class3; }
    }

    void state_class3()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Oh... Well, I should be leaving now.";
        if (Input.GetButtonDown("Jump")) { myState = States.class4; }
    }

    void state_class4()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Oh don't be silly, everyone's gone for the day! Take your time.";
        if (Input.GetButtonDown("Jump")) { myState = States.class5; }
    }

    void state_class5()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>This chick weirds me out.</i>\n"
            + "Thank you, but I really have to g-";
        if (Input.GetButtonDown("Jump")) { myState = States.class6; }
    }

    void state_class6()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceText1.text = "Go with Mary";
        choiceText2.text = "Deny and Leave";
        text.text = "<b>Mary stands in your way.</b>\n"
            + "No, really. You should stay!";
        if (Input.GetAxis("ADS") > 0.1) { myState = States.class7; }
        else if (Input.GetAxis("FPSFire") > 0.1) { myState = States.dead1; }
    }

    void state_class7()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "<i>I've got a bad feeling that it wouldn't be good for me to leave</i>\n"
            + "Alright, I'll stay for a while.";
        if (Input.GetButtonDown("Jump")) { myState = States.class8; }
    }

    void state_class8()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Perfect!\n" + "<i>She motions me to follow her into the hallway, so I do.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway; }
    }

    void state_dead1()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "<i>This chick is unhinged, I gotta get out of here.</i>\n"
            + "I'm sorry, but I'm gonna go ahead an lea-";
        if (Input.GetButtonDown("Jump")) { myState = States.dead2; }
    }

    void state_dead2()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = true;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>I feel a sharp pain. I look down and see a pool of red and a knife handle sticking out of me.</i>\n"
            + "<i>Something tells me I messed up...</i>\n"
            + "<b>Your're dead.</b>";
        if (Input.GetButtonDown("Jump")) { myState = States.begin; }
    }

    void state_hallway()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>We're in the hallway, but there's not a single soul in this building but us. It's unsettling.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway1; }
    }

    void state_hallway1()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "So, uh, where is everyone else?";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway2; }
    }

    void state_hallway2()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "I told you, everyone's gone for today. But don't worry about that, let's talk about your game.";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway3; }
    }

    void state_hallway3()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>Game? What in the world is she talking about?</i>/n"
            + "Uh, I don't know what you're talking about. I'm not playing any game.";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway4; }
    }

    void state_hallway4()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "How do you know this isn't a game right now?";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway5; }
    }

    void state_hallway5()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>I have no idea what's going on. What game?</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway6; }
    }

    void state_hallway6()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Oh! Wait here a second, I forgot something in the classroom! <b><i>Dont</b></i> leave!\n"
            + "Soul goes back in to the classroom with out any sort of agreement from me";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway7; }
    }

    void state_hallway7()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceText1.text = "Leave";
        choiceText2.text = "Wait";
        text.text = "<i>I could use this opportunity to leave, or maybe I should I wait for her...</i>";
        if (Input.GetAxis("ADS") > 0.1) { myState = States.dead3; }
        else if (Input.GetAxis("FPSFire") > 0.1) { myState = States.hallway8; }    
    }

    void state_dead3()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "<i>I should take my chance while I have it, I gotta get out of here.</i>\n"
            + "<i>I make it a few steps before the next thing I know, I'm looking at the open window I was just next to. From the outside.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.dead4; }
    }

    void state_dead4()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>I see Mary in the window, and I hear the wind rush by my ears.</i>\n"
            + "<b>You're dead.</b>";
        if (Input.GetButtonDown("Jump")) { myState = States.begin; }
    }

    void state_hallway8()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "<i>I decide to wait. It's too risky to take my chances right now.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway9; }
    }

    void state_hallway9()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>At least the weather's nice.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway10; }
    }

    void state_hallway10()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>I hear a loud voice in my ear, causing me to jump</i>\n"
            + "Please don't do that.";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway11; }
    }

    void state_hallway11()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Hah. My bad.\n"
            + "<i>She stares out the window</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway12; }
    }

    void state_hallway12()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "I'm glad I met you here.\n"
            + "It's been a while since I've talked to a real person, and not a video game character.";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway13; }
    }

    void state_hallway13()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "<i>There's an awkward silence.</i>\n"
            + "<i>She suddenly looks at me.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway14; }
    }

    void state_hallway14()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Let's keep walking.\n"
            + "<i>I decide it's in my best interest to follow her.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway15; }
    }

    void state_hallway15()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "So where are we going, exactly?";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway16; }
    }

    void state_hallway16()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = true;
        roof.enabled = false;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Oh, sorry. We're going to the roof.\n"
            + "I just wanted a look around, since I don't feel like this place is real. If you know what I mean.";
        if (Input.GetButtonDown("Jump")) { myState = States.hallway17; }
    }

    void state_hallway17()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "<i>We walk up a flight of stairs, and just before she opens the door to the roof, I hesitate...</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs; }
    }

    void state_stairs()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
        choiceText1.text = "\"Sorry, I spaced out for a second.\"";
        choiceText2.text = "Suggest to Part Ways";
        text.text = "What's wrong?";
        if (Input.GetAxis("ADS") > 0.1) { myState = States.stairs1; }
        else if (Input.GetAxis("FPSFire") > 0.1) { myState = States.dead5; }
    }

    void state_dead5()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "I appreciate the, uh, time we've spent, but I've got to-";
        if (Input.GetButtonDown("Jump")) { myState = States.dead6; }
    }

    void state_dead6()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "Leave, huh?\n" + "<i>A chill crawls up my spine...</i>\n"
            + "<i>She turns to look at me in eyes.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.dead7; }
    }

    void state_dead7()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "I figured this would happen.\n" + "It's so lonely here, you know?\n"
            + "<i>She looks down.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.dead8; }
    }

    void state_dead8()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "<i>I'm really sorry, but it's getting pretty dark, and I'm sure my parents are worried.\n"
            + "<i>I feel a little bad about lying, but I've gotta get away from this girl.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.dead9; }
    }

    void state_dead9()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "<i>She lunges at me.</i>\n" + "<i>Before I know it, I'm over the railing of the stairway.</i>";
        if (Input.GetButtonDown("Jump")) { myState = States.dead10; }
    }

    void state_dead10()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "<i>With the air rushing by my ears, I take one last look at Mary. She's angry, but crying. Whoops.</i>\n"
            + "<i><b>You're dead.</i></b>";
        if (Input.GetButtonDown("Jump")) { myState = States.begin; }
    }

    void state_stairs1()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        text.text = "Sorry, I just spaced out for a second.";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs2; }
    }

    void state_stairs2()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "You know," +
            " you seem like a clumsy person. No wonder I found you sleeping in class.";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs3; }
    }

    void state_stairs3()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "Hey, I didn't chose to sleep there and besides, it's also getting outside.";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs4; }
    }

    void state_stairs4()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "It is but what I have to show you will be worth your while. \n"
            + "She continues to walk. \n"
            + "Come on.";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs5; } 
    }

    void state_stairs5()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "We arrive at a flight of stairs that lead up with a single door. She skips the steps as she goes up and waits for me at the top. ";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs6; }
    }

    void state_stairs6()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "I get to the top and she opens the door. There's a loud boom and the sky gets lit up with different colors.";
        if (Input.GetButtonDown("Jump")) { myState = States.stairs7; }
    }

    void state_stairs7()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = false;
        stairs.enabled = true;
        merry.enabled = true;
        text.text = "We made it just in time.";
        if (Input.GetButtonDown("Jump")) { myState = States.roof; }
    }

    void state_roof()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = true;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "She runs out onto the roof and gazes at the fireworks going off. I take a couple steps outside under the sky. Mary gazes at me.";
        if (Input.GetButtonDown("Jump")) { myState = States.roof1; }
    }

    void state_roof1()
    {
        name1.enabled = true;
        name2.enabled = false;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = true;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "Thanks for joining me. You've really made today special.";
        if (Input.GetButtonDown("Jump")) { myState = States.roof2; }
    }

    void state_roof2()
    {
        name1.enabled = false;
        name2.enabled = true;
        classroom.enabled = false;
        hallway.enabled = false;
        roof.enabled = true;
        stairs.enabled = false;
        merry.enabled = true;
        text.text = "She smiles at me. \n" + "The end.";
        if (Input.GetButtonDown("Jump")) { DontDestroyOnLoad(new GameObject("levelCompleted")); } 
    }
}

