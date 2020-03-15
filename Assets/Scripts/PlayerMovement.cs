using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	[Header("X Throw")]
	[Tooltip("In ms^-1")] [SerializeField] float xSpeed = 40f;
	[SerializeField] float xRange = 9f;

	[Header("Y Throw")]
	[Tooltip("In ms^-1")] [SerializeField] float ySpeed = 40f;
	[SerializeField] float yRange = 5f;

	[Header("Pitch Factors")]
	[SerializeField] float positionPitchFactor = -1f;
	[SerializeField] float throwPitchFactor = -25f;

	[Header("Yaw Factors")]
	[SerializeField] float postionYawFactor = 2.2f;

	[Header("Roll Factors")]
	[SerializeField] float throwRollFactor = -25f;

	[SerializeField] GameObject[] guns;

	float xThrow, yThrow;
	bool isAlive = true;


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

	private void ProcessFiring()
	{
		if (CrossPlatformInputManager.GetButton("Fire"))
		{
			ActivateGuns();
		}
		else
		{
			DeactivateGuns();
		}
	}
	private void ActivateGuns()
	{
		foreach(GameObject gun in guns)
		{
			gun.SetActive(true);
		}
	}

	private void DeactivateGuns()
	{
		foreach (GameObject gun in guns)
		{
			gun.SetActive(false);
		}
	}

	private void OnPlayerDeath() //Called by string reference
	{
		isAlive = false;
	}
	void Update () {

		if (isAlive)
		{
			ProcessTranslation();
			ProcessRotation();
			ProcessFiring();
		}
		

	}





}
