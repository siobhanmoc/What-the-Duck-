using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float bulletspeed = 100;

	public GameObject bulletPrefab;
	public GameObject gun;

	public Transform bulletSpawnPoint;

	public int health = 100;
	public void TakeDamage(int damageToTake) {
		health = health - damageToTake;
	}
		

	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//this exits the function and does not run anything after it.
			return;
		}

		transform.position = transform.position + new Vector3 (0.1f, 0, 0);
		if (Input.GetKeyUp (KeyCode.A)) {
			transform.position = transform.position + new Vector3 (0, 0, 1);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			transform.position = transform.position + new Vector3 (0, 0, -1);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.position = transform.position + new Vector3 (0, 0.4f, 0);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			transform.position = transform.position + new Vector3 (0, 0, 1);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			transform.position = transform.position + new Vector3 (0, 0, -1);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position = transform.position + new Vector3 (0, 0.4f, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (gun.transform.forward * bulletspeed, ForceMode.Impulse);
		}
	}
}
