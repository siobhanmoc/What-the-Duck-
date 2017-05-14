using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 20;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 4f);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<PlayerController>() .TakeDamage (damage);
		}

		Destroy (this.gameObject);
	}
}
