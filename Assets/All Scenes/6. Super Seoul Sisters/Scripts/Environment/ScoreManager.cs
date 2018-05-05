using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text printScore;

	public int currentScore;

	// Use this for initialization
	void Start () {
        currentScore = 0;
	}

    void Awake()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update () {
		PrintText();
	}

	public void AddScore(int pointAmmount){
		currentScore += pointAmmount;
	}

	public void PrintText(){
		printScore.text = "Score : " + currentScore.ToString("0000");
	}
}
