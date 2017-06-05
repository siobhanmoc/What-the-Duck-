using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int ammoCount = 50;
	public int scoreCount = 0;


	public Text ammoCounter;
	public Text scoreCounter;

	void Start () {
		UpdateText ();
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {

			if (ammoCount > 0) {
				ammoCount--;
				UpdateText ();
			}
		}
	}

	private void UpdateText () {
		ammoCounter.text = "Ammo: " + ammoCount.ToString ();
	}

	public void AddScore (int newScoreValue) {
		scoreCount += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreCounter.text = "Score: " + scoreCount;
	}
}