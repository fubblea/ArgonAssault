using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	[SerializeField] float timeBeforeSuicide = 2f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeBeforeSuicide);
	}

}
