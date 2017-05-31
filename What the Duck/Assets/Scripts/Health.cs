using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int startingHealth = 100;
	public int startingLives = 5;

	private int currentHealth;
	private int currentLives;

	[HideInInspector]
	public int damage;

	void Start () {

		currentHealth = startingHealth;
		currentLives = startingLives;
	}
	void Update () {

		if (currentLives > startingLives) {
			currentLives = startingLives;
		}
		if (currentHealth > startingHealth) {
			currentHealth = startingHealth;
		}
		if (currentHealth <= 0) {

			if (currentLives >= 1) {
				
				TakeLife ();
				ResetPlayer ();
			} else {
				Debug.Log ("You Dead");
			}
		}
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
}
