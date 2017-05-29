using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float bulletspeed = 20;

	public GameObject bulletPrefab;
	public GameObject gun;

	public Transform bulletSpawnPoint;

	public int health = 100;
	public void TakeDamage(int damageToTake) {
		health = health - damageToTake;
	}

	private float shootingTimer;
	public float timeBetweenShots = 2f;	
	public Rigidbody rigidBody;
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//this exits the function and does not run anything after it.
			return;
		}

		if (Time.time - shootingTimer > timeBetweenShots) {
			
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (-gun.transform.forward * bulletspeed, ForceMode.Impulse);
			shootingTimer = Time.time;
		}
	}

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		shootingTimer = Time.time;
	}
}
