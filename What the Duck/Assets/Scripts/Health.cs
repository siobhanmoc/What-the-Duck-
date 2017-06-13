using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	[HideInInspector]
	public int damage;
	public int startingHealth = 100;
	public int startingLives = 5;

	private int currentLives;
	private static int currentHealth;

	public Text health;
	public Text lives;
	public Text gameOver;

	public GameObject player;

	void Start () {

		currentHealth = startingHealth;
		currentLives = startingLives;

		gameOver.text = "";
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

			if (currentLives >= 1) {
				TakeLife ();
			}

			if (currentLives <= 0) {
				currentLives = 1;
				gameOver.text = "Game Over";

				Destroy (this.gameObject);
			}

			TakeLife ();
			ResetPlayer ();
		}

		UpdateText ();
	}
		
	private void UpdateText () {
		health.text = "Health: " + currentHealth.ToString ();
		lives.text = "Lives: " + currentLives.ToString ();
	}

	//Give lives and turns off collectable item
	void OnTriggerEnter (Collider other) {

		if (other.tag == "PickUpLives") {
			other.gameObject.SetActive (false);
			currentLives = currentLives + 1;
		}
	}
}
