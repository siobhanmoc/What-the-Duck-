using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	//To quit the game
	public void Exit () {

		#if UNITY_EDITOR

		UnityEditor.EditorApplication.isPlaying = false;

		#else

//		Application.Exit ();

		#endif


	}
}
