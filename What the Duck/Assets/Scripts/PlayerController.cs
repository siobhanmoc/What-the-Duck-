﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int health = 100;
	public int position = 2;
	public int ammoCount = 50;

	public Text ammoCounter;

	private bool grounded = true;
	public bool canShoot;

	public float jumpHeight = 2f;
	public float gravity = 20f;
	public float bulletSpeed = 100;
	public float sidestepSpeed = 10;
	public float runningSpeed = 6;

	public GameObject bulletPrefab;
	public GameObject gun;
	public GameObject mainCamera;
	public GameObject playerObject;
	public GameObject leftPositionMarker;
	public GameObject middlePositionMarker;
	public GameObject rightPositionMarker;
	public GameObject targetPosition;

	public Transform bulletSpawnPoint;



	public void TakeDamage(int damageToTake) {
		health = health - damageToTake;
	}

	// Use this for initialization
	void Start () {
		targetPosition = middlePositionMarker;
		UpdateText ();
	}


	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//this exits the function and does not run anything after it.
			return;
		}

		//camera position, behind player
		transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
		float cameraXpos = 0;
		float cameraYpos = 1.5f;
		float cameraZpos = this.transform.position.z -3;
		mainCamera.transform.position = new Vector3 (cameraXpos,cameraYpos,cameraZpos);
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

		//Moving the player between the three lanes
		if (Input.GetKeyDown (KeyCode.A) && position > 1) {
			if (position == 2) {
				position = 1;
				targetPosition = leftPositionMarker;
			} else if (position == 3) {
				position = 2;
				targetPosition = middlePositionMarker;
			}
		}

		if (Input.GetKeyDown (KeyCode.D) && position < 3) {
			if (position == 2) {
				position = 3;
				targetPosition = rightPositionMarker;
			} else if (position == 1) {
				position = 2;
				targetPosition = middlePositionMarker;
			}
		}

		BulletShoot ();

		//Make the player jump without double jumping
		if (!grounded && (GetComponent<Rigidbody> ().velocity.y == 0)) {
			grounded = true;
		}
	
		if (Input.GetKeyDown (KeyCode.W) && grounded == true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (runningSpeed, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}
	}

	//Shooting. Player can't shoot once ammo reaches 0
	public void BulletShoot () {
		
		if (Input.GetKeyDown (KeyCode.Space) && canShoot == true) {
			ammoCount--;
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
		}

		playerObject.transform.position = Vector3.MoveTowards (playerObject.transform.position, targetPosition.transform.position, sidestepSpeed * Time.deltaTime);

		if (ammoCount >= 1) {
			canShoot = true;
		}
		if (ammoCount <= 0) {
			canShoot = false;
		}

		UpdateText ();
	}

	private void UpdateText () {

		ammoCounter.text = "Ammo: " + ammoCount.ToString ();

	}


	void OnTriggerEnter (Collider other) {

		//To turn off bullets collectables
		if (other.tag == "PickUpBullet") {
			other.gameObject.SetActive (false);
		}
		//Give player ammo
		if (other.tag == "PickUp") {
			other.gameObject.SetActive (false);
			ammoCount = ammoCount + 5;
		}
	}
}
