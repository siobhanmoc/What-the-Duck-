﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public float destroyTime = 1f;

	//When something enters the Trigger
	void OnTriggerEnter(Collider other) {

		//To destroy ground pieces after player goes past
		if (other.tag == "Ground") {

			Destroy (other.gameObject, destroyTime);
		}
		if (other.tag == "Bullet") {

			Destroy (other.gameObject, destroyTime);
		}
	}
}
