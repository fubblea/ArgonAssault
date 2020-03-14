using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	float xThrow;
	[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 40f;
	[SerializeField] float xRange = 9f;

	float yThrow;
	[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 40f;
	[SerializeField] float yRange = 5f;

	[SerializeField] float positionPitchFactor = -1f;
	[SerializeField] float throwPitchFactor = -25f;

	[SerializeField] float postionYawFactor = 2.2f;

	[SerializeField] float throwRollFactor = -25f;

	// Use this for initialization
	void Start () {
		
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float xOffset = xThrow * xSpeed * Time.deltaTime;
		float rawNewXPos = transform.localPosition.x + xOffset;
		float NewXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float yOffset = yThrow * ySpeed * Time.deltaTime;
		float rawNewYPos = transform.localPosition.y + yOffset;
		float NewYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

		transform.localPosition = new Vector3(NewXPos, NewYPos, transform.localPosition.z);
	}

	private void ProcessRotation()
	{
		float pitch = transform.localPosition.y * positionPitchFactor + yThrow * throwPitchFactor;
		float yaw = transform.localPosition.x * postionYawFactor;
		float roll = xThrow * throwRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	// Update is called once per frame
	void Update () {
		ProcessTranslation();
		ProcessRotation();

	}

	

}
