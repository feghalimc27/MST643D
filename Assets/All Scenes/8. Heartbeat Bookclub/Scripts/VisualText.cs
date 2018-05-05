using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

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
        text.text = "... \n" +  
            "......";
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
        text.text = "Oh Hey! Your finally up. I was getting worried there for a second. \n"
            + "\nSeoul gets up quickly";
        
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
        text.text = "What's going on here? Who are you? \n"
            + "... \n" + "And why was I on your lap?";
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
        text.text = "Well... I'm Mary Soul. \n"
            + "I saw you in here on the floor and I came to help.";
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
        text.text = "Why was my head on your lap though? Shouldn't you have gone to get the nurse? \n"
            + "What am I saying. I shouldn't even be here.";
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
        text.text = "Everyone's gone for the day and you just seemed to be asleep so it was a matter of time until you woke up.\n"
            + "You shouldn't sleep on the floor like that either, or you'll twist your neck.";
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
        text.text = "I gather myself together and begin to walk toward the door to leave. \n"
            + "Well thank you for your concern but I should be lea-";
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
        text.text = "Soul gets in the way of Seoul \n"
            + "Awww don't leave just yet, let's walk around the school for a bit. ";
        if (Input.GetButtonDown("Fire1")) { myState = States.class7; }
        else if (Input.GetButtonDown("Fire2")) { myState = States.dead1; }
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
        text.text = "I guess I should accompany her for a while since she did stay with me for a while. \n"
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
        text.text = "Wonderful!! \n" + "Soul takes me by the hand and pulls me in to the hallway.";
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
        text.text = "What's with this girl? I start walking past her. \n"
            + "I'm sorry but I have to g- ";
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
        text.text = "I feel a sharp pain in my stomach and I fall to the floor. The ground around me begins to feel wet and I catch sight of growing red. \n"
            + "My vision begins to go out.... \n"
            + "Your're dead.";
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
        text.text = "The hallways are empty and the only sound present is the trees rustling outside. There's a breeze that fills the hallway as some windows are cracked open";
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
        text.text = "So where is everyone?";
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
        text.text = "I told you, everyone's gone for today. But don't worry about that, why were you in sleeping in the classroom?";
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
        text.text = "I continue to play along but I still remain suspicious about the scenario. \n"
            + "I'm not even sure anymore, I've been through a lot and I keep dreaming about being placed in different styles of games.";
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
        text.text = "Huh. Well how do you know this isn't a game right now?";
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
        text.text = "I don't but this it the closet I've felt to being a real person so that must count for something.";
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
        text.text = "Oh hey can you wait here for a second, I left something in the classroom when I went in to help you. \n"
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
        text.text = "I could use this opportunity to leave or maybe I should I wait for her...";
        if (Input.GetButtonDown("Fire1")) { myState = States.dead3; }
        else if (Input.GetButtonDown("Fire2")) { myState = States.hallway8; }    
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
        text.text = "I start taking a few pace away from the classroom and suddenly hear the classroom door fling open. Before I know it I see Soul in my peripheral. \n"
            + "I feel a strong force that knocks me over to the windows. I lose my balance and feel no ground beneath me.";
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
        text.text = "I catch a glimpse of Soul looking out the window before everything goes black. \n"
            + "Your dead.";
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
        text.text = "I wait patiently. I look outside the windows in the hallway.";
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
        text.text = "Looks nice outside huh.";
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
        text.text = "I hear Mary's voice close to me ear and jump away \n"
            + "Ah! Please don't sneak up on me like that.";
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
        text.text = "Heh. Sorry. \n"
            + "She steps back and looks out the windows";
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
        text.text = "I often stay late after school studying and time seems to fly. It's usually boring but I'm glad I was able to meet you today. \n"
            + "It's been a while since the last time I actually talked to anyone...";
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
        text.text = "There's a moment of silent. \n"
            + "She breaks her sight of the window and turns towards me.";
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
        text.text = "Lets keep walking around. \n"
            + "She beings to walk and I begin to follow. She seems to be determined in her walk as if she knows where she's going.";
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
        text.text = "So where are we going exactly?";
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
        text.text = "Oh I never told you, we're headed to the roof of the school. \n"
            + "It's strange, nothing about this place feels familiar and I can't shake the feeling that something is off.";
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
        text.text = "We turn the corner and I can see the entrance of the building down a flight of stairs. I stop for a moment with Mary stopping a few steps ahead.";
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
        choiceText1.text = "Oh nothing, I spaced out for a moment.";
        choiceText2.text = "Suggest Parting Here";
        text.text = "What's wrong?";
        if (Input.GetButtonDown("Fire1")) { myState = States.stairs1; }
        else if (Input.GetButtonDown("Fire2")) { myState = States.dead5; }
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
        text.text = "I think it's about time I should-";
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
        text.text = "leave \n" + "I feel a chill crawl up my spine as Mary finished my sentence... \n"
            + "She turns to look at me in eyes.";
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
        text.text = "That's all everyone wants to do... \n" + "Everyone I knew always tries to leave. \n"
            + "She looks down";
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
        text.text = "It seems to be getting dark outside and I think maybe we should call it a day. I'm sure we'll see each other again though. \n"
            + "I feel kind of bad about lying to her but I really need to figure out what's on.";
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
        text.text = "Fine! If you're going to leave then just leave! \n" + "Her hands fly out at me and I tip over.";
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
        text.text = "I'm free falling down but all I can see it is her at the top of the stairs. I see a tear fall down her face before everything goes black. \n"
            + "Your dead.";
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
        text.text = "Oh nothing, I spaced out for a moment.";
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

