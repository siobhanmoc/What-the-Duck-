using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float bulletspeed = 20;

	public GameObject bulletPrefab;
	public GameObject gun;

	public Transform bulletSpawnPoint;


	private float shootingTimer;
	public float timeBetweenShots = 2f;	
	public Rigidbody rigidBody;
	
	// Update is called once per frame
	void Update () {

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
