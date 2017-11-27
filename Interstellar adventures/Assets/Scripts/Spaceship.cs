using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	//Inspector variables

	public spaceshipConfig Settings; [Tooltip("Insert the correspondending spaceshipConfig file here!")]
	public Camera MainCamera;
	[SerializeField] float FOVSmooth;
	[Space]
	[Header("Input settings")]
	[SerializeField] KeyCode speedUp;
	[SerializeField] KeyCode speedDown;
	[SerializeField] KeyCode rollLeft;
	[SerializeField] KeyCode rollRight;
	[Space]
	[SerializeField] float pitchSensitivity;
	[SerializeField] float yawSensitivity;

	//internal variables

	float rotX;
	float rotY;

	Rigidbody myRB;
	float currentSpeed;




	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		#region Movement
		rotX = Input.GetAxis("MouseX");
		rotY = Input.GetAxis("MouseY");

		if (rotX * Settings.yawSpeed > yawSensitivity || -rotX * Settings.yawSpeed > yawSensitivity)
		{
			transform.Rotate(0, rotX * Settings.yawSpeed, 0);
		}
		if (rotY * Settings.pitchSpeed > pitchSensitivity || -rotY * Settings.pitchSpeed > pitchSensitivity)
		{
			transform.Rotate(-rotY * Settings.pitchSpeed, 0, 0);
		}

		if (Input.GetKey(rollLeft))
		{
			transform.Rotate(0, 0, Settings.rollSpeed);
		}
		if (Input.GetKey(rollRight))
		{
			transform.Rotate(0, 0, -Settings.rollSpeed);
		}

		if (Input.GetKey(speedUp) && currentSpeed < Settings.maxSpeed)
		{
			currentSpeed += Settings.accelerationSpeed;
		}
		if (Input.GetKey(speedDown) && currentSpeed > 0)
		{
			currentSpeed -= Settings.brakeSpeed;
		}
		else if (currentSpeed < 0) currentSpeed = 0;

		myRB.velocity = (transform.forward * currentSpeed);

		Debug.Log("Current speed is: " + currentSpeed);

		#endregion

		#region Camera Effects


		if (currentSpeed > Settings.maxSpeed / 1)
		{
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 85, Time.deltaTime * FOVSmooth);
		}
		else if (currentSpeed > Settings.maxSpeed / 5 && currentSpeed < Settings.maxSpeed / 1)
		{
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 70, Time.deltaTime * FOVSmooth);
		}
		else MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 60, Time.deltaTime * FOVSmooth);
		

		#endregion
	}
}
