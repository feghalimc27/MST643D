using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text printScore;
	public int currentScore;

	public int coinPoints;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		PrintText();
	}

	public void AddScore(int pointAmmount){
		currentScore += pointAmmount;
	}

	public void PrintText(){
		printScore.text = "Score: " + currentScore;
	}
}
