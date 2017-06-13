using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public GameObject bulletPrefab;
	public GameObject gun;

	public Transform bulletSpawnPoint;

	public float bulletspeed = 20;
	private float shootingTimer;
	public float timeBetweenShots = 2f;	

	public Rigidbody rigidBody;
	

	void Update () {

		//Enemy is able to shoot, with a gap between shots
		if (Time.time - shootingTimer > timeBetweenShots) {
			
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (-gun.transform.forward * bulletspeed, ForceMode.Impulse);
			shootingTimer = Time.time;
		}
	}


	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		shootingTimer = Time.time;
	}
}
