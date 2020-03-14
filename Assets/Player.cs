using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 40f;
	[SerializeField] float xRange = 9f;

	[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 40f;
	[SerializeField] float yRange = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float rawNewXPos = transform.localPosition.x + xOffset;
		float NewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
		
		float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float yOffset = yThrow * ySpeed * Time.deltaTime;
		float rawNewYPos = transform.localPosition.y + yOffset;
		float NewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

		transform.localPosition = new Vector3(NewXPos, NewYPos, transform.localPosition.z);
	}
}
