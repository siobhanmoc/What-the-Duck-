using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float bulletSpeed = 100;

	public GameObject bulletPrefab;
	public GameObject gun;

	public Transform bulletSpawnPoint;

	public GameObject mainCamera;
	public float runningSpeed = 6;


	public GameObject playerObject;

	public GameObject leftPositionMarker;
	public GameObject middlePositionMarker;
	public GameObject rightPositionMarker;

	public int position = 2;

	public float sidestepSpeed = 10;
	public GameObject targetPosition;

	public float jumpHeight = 2f;
	public float gravity = 20f;

	private bool grounded = true;


	public int health = 100;
	public void TakeDamage(int damageToTake) {
		health = health - damageToTake;
	}

	// Use this for initialization
	void Start () {
		targetPosition = middlePositionMarker;
	}


	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//this exits the function and does not run anything after it.
			return;
		}

		transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
		float cameraXpos = 0;
		float cameraYpos = 1.5f;
		float cameraZpos = this.transform.position.z -3;
		mainCamera.transform.position = new Vector3 (cameraXpos,cameraYpos,cameraZpos);
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

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

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
		}

		playerObject.transform.position = Vector3.MoveTowards (playerObject.transform.position, targetPosition.transform.position, sidestepSpeed * Time.deltaTime);
	}

	void FixedUpdate () {

		if (!grounded && (GetComponent<Rigidbody> ().velocity.y == 0)) {
			grounded = true;
		}

		if (Input.GetKeyDown (KeyCode.W) && grounded == true) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (runningSpeed, Mathf.Sqrt (2 * jumpHeight * gravity), 0);
			grounded = false;
		}
	}
}
