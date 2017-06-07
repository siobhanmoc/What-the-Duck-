using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public int damageToGive = 20;

	void OnTriggerEnter (Collider other) {

		//So enemy can kill player
		if (other.tag == "Player") {
			other.GetComponent <Health> ().HurtPlayer (damageToGive);
			Destroy (gameObject);
		}
		if (other.tag == "Bullet") {
			return;
		}
	}
}
