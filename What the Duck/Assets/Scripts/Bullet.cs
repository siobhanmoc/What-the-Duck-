using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float destroyTime = .1f;

	public int damageToGive = 20;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5f);

	}


	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.GetComponent <Health> ().HurtPlayer (damageToGive);
		}

		if (other.tag == "Enemy") {
			//Destroy(this.gameObject);
			Destroy (other.gameObject, destroyTime);
		}

		if (other.tag == "Box") {
			//Destroy(this.gameObject);
			Destroy (other.gameObject, destroyTime);
		}

		Destroy (this.gameObject);
	}
}