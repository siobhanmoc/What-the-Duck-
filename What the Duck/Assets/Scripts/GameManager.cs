using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int ammoCount = 50;
	public int scoreCount = 0;

	public bool canShoot;

	public Text ammoCounter;
	public Text scoreCounter;

	void Start () {
		
		//UpdateText ();
			
	}

	void Update () {
		//
		//canShoot == true;
		//
		//if (GetComponent<PlayerController> ().Bullet ()) {
		//	ammoCount > 0;
		//	ammoCount--;
		//}
		//
		//canShoot == false;

		//if (ammoCount <= 0) {
		//	ammoCount = 0;
		//}

		//UpdateText ();

		//if (ammoCount <= 0) {
		//	ammoCount = 0;
		//	canShoot = false;
		//}
		//
		//	if (ammoCount > 0) {
		//		ammoCount--;
		//		canShoot = true;
		//		UpdateText ();
		//}
	}

	//private void UpdateText () {
	//	ammoCounter.text = "Ammo: " + ammoCount.ToString ();
	//}

	public void AddScore (int newScoreValue) {
		scoreCount += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreCounter.text = "Score: " + scoreCount;
	}
}