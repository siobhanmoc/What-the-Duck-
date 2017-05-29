using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public List<GameObject> groundPieces = new List<GameObject> ();

	public float depthOfGroundPiece = 6;

	public float playerPositionCounter = 0;
	public GameObject player;

	int groundPieceCounter = 0;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 40; i++) {
			BuildGround ();
		}
	}

	void Update(){
		if (player.transform.position.z > playerPositionCounter) {
			playerPositionCounter += depthOfGroundPiece;
			BuildGround ();
		}
	}

	private void BuildGround (){
		Instantiate (groundPieces [Random.Range (0, groundPieces.Count)], Vector3.forward * groundPieceCounter * depthOfGroundPiece, Quaternion.identity);
		groundPieceCounter++;
	}
}
