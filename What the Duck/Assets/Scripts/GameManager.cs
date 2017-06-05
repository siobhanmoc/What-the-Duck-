using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int ammoCount = 50;
	public int scoreCount = 0;
	public int healthCount;

	public Text ammoCounter;
	public Text scoreCounter;
	public Text healthCounter;

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
		ammoCounter.text = ammoCount.ToString ();
		healthCounter.text = healthCount.ToString ();
	}
}