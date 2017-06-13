using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnScript : MonoBehaviour {

	//To load a scene when scelected - from tutorial
	public void LoadByIndex (int sceneIndex) {

		SceneManager.LoadScene (sceneIndex);

	}
}
