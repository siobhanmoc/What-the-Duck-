using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	//To add score when shooting enemies or boxes
	public int scoreCount = 0;

	public Text scoreCounter;


	public void AddScore (int newScoreValue) {
		scoreCount += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreCounter.text = "Score: " + scoreCount;
	}
}