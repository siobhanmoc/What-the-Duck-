﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnScript : MonoBehaviour {

	//To load a scene when scelected
	public void LoadByIndex (int sceneIndex) {

		SceneManager.LoadScene (sceneIndex);

	}
}
