using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("loadNextScene", 5);
	}


	void loadNextScene()
	{
		EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex + 1);
	}
}
