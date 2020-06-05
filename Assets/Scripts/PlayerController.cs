using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{	
	[Header("Genrel")]
	[Tooltip("In ms^-1")] [SerializeField] float ControlSpeed = 4f;
	[Tooltip("In meter")] [SerializeField] float xRange = 4f;
	[Tooltip("In meter")] [SerializeField] float yRange = 2.4f;
	[Tooltip("Number of guns")][SerializeField] private GameObject[] guns;
	
	[Header("Screen-Position Based")]
	[SerializeField] float PositionPitchFactor = -10f;
	[SerializeField] float PositionYawFactor = 10f;

	[Header("Controll Throw Based")]
	[SerializeField] float ControllPitchFactor = -10f;
	[SerializeField] float PositionRollFactor = -10f;
	[SerializeField] private Texture2D cursoreArrow;
	void Start()
	{
		Cursor.visible = false;
		//Cursor.SetCursor(cursoreArrow,Vector2.zero,CursorMode.ForceSoftware);
	}

	private float xThrow, yThrow;

	private bool isControlEnabled = true;
	// Update is called once per frame
	void Update()
	{
		//--------------------Horizontal & Vertical--------------------
		if (isControlEnabled == true)
		{
			ProcessTranslation();
			RotationTranslation();
			processFireing();
		}
		else
		{
			print("Control Frozen");	
		}
	}

	private void processFireing()
	{
		if (CrossPlatformInputManager.GetButton("Fire"))
		{
			activateGuns(true);
		}
		else
		{
			activateGuns(false);
		}
	}

	/*
	private void deActivateGuns()
	{
		foreach (GameObject gun in guns)
		{
			gun.SetActive(false);
		}
	}
	*/

	private void activateGuns(bool isActive)
	{
		foreach (GameObject gun in guns)
		{
			var ParticalEmmission = gun.GetComponent<ParticleSystem>().emission;
			ParticalEmmission.enabled = isActive;
			//gun.SetActive(true);
		}
	}

	void onPlayerDeath()  // code by string reference
	{
		isControlEnabled = false;
	}

	private void RotationTranslation()
	{
		float PitchDueToThePosition = transform.localPosition.y * PositionPitchFactor;
		float PitchDueToControllThrow = yThrow * ControllPitchFactor;
		float pitch=PitchDueToThePosition+PitchDueToControllThrow;
		float yaw=transform.localPosition.x*PositionYawFactor;
		float roll=xThrow*PositionRollFactor;
		transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * ControlSpeed * Time.deltaTime;
        float yOffset = yThrow * ControlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    
	}
}
