using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 20;
	public float destroyTime = .1f;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 4f);
	}


	void OnTriggerEnter (Collider other) {
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