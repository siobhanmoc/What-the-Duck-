using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	
	public int startingHealth = 100;

	private int currentHealth;
	public int scoreValue = 15;

	private GameManager gameManager;

	void Start () {

		currentHealth = startingHealth;

		GameObject gameManagerObject = GameObject.FindWithTag ("GameManager");
		if (gameManagerObject != null) {
			gameManager = gameManagerObject.GetComponent <GameManager> ();
		}
	}
	void Update () {
		if (currentHealth <= 0) {

			gameManager.AddScore (scoreValue);

			Destroy(this.gameObject);
		}
	}
		
	public void HurtEnemy (int damage) {

		currentHealth -= damage;
	}
}
