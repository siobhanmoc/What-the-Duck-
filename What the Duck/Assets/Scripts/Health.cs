using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int startingHealth = 100;
	public int startingLives = 5;

	public Text health;
	public Text lives;

	public bool playerAlive;

	private static int currentHealth;
	private int currentLives;

	[HideInInspector]
	public int damage;

	void Start () {

		currentHealth = startingHealth;
		currentLives = startingLives;
	}
	void Update () {
		CurrentHealth ();
	}

	public void TakeLife () {

		currentLives--;
	}
	public void GiveLife () {

		currentLives++;
	}
	public void HurtPlayer (int damage) {

		currentHealth -= damage;
	}
	public void ResetPlayer () {

		currentHealth = startingHealth;

	}

	public void CurrentHealth (){
		
		//To reduce health and lives from starting health
		if (currentLives > startingLives) {
			currentLives = startingLives;
		}
		if (currentHealth > startingHealth) {
			currentHealth = startingHealth;
		}
		if (currentHealth <= 0) {

			if (currentHealth >= 0) {
				playerAlive = true;
			}
			if (currentLives >= 1) {
				playerAlive = true;
			}

			if (currentLives <= 0) {
				playerAlive = false;
			}

			if (playerAlive == false) {
				GetComponent <PlayerController> ().enabled = false;
			}

				TakeLife ();
				ResetPlayer ();
			} else {
				Debug.Log ("You Dead");
			}

		UpdateText ();
	}

	private void UpdateText () {
		health.text = "Health: " + currentHealth.ToString ();
		lives.text = "Lives: " + currentLives.ToString ();
	}
}
