using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damageToGive = 20;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent <EnemyHealth> ().HurtEnemy (damageToGive);
		}
	}
}