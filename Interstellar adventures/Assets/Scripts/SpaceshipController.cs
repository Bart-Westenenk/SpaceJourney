using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

	// inspector / public  variables
	public float speed;
	public float brakeSpeed;
	public float rollSpeed;
	[Space]
	public Camera MainCamera;
	public float camSmooth;
	[Space]
	public KeyCode accelerateKey;
	public KeyCode brakeKey;
	public KeyCode rightKey;
	public KeyCode leftKey;

	// internal variables
	private float currentSpeed;
	private Vector3 currentVelocity;

	private Rigidbody myRB;


	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (currentSpeed > 15)
		{
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 80, Time.deltaTime * camSmooth);
		}
		if (currentSpeed < 15)
		{
			MainCamera.fieldOfView = Mathf.Lerp(MainCamera.fieldOfView, 60, Time.deltaTime * camSmooth);
		}


		if (Input.GetKey(leftKey))
		{
			/*
			transform.RotateAroundLocal(transform.forward, rollSpeed);
			transform.RotateAround(transform.forward, rollSpeed);
			*/
			transform.Rotate(transform.forward * (rollSpeed * currentSpeed));
		}

		if (Input.GetKey(rightKey))
		{
			/*
			transform.RotateAroundLocal(transform.forward, -rollSpeed);
			transform.RotateAround(transform.forward, -rollSpeed);
			*/
			transform.Rotate(transform.forward * (-rollSpeed * currentSpeed));
		}

	}

	void FixedUpdate()
	{
		if(Input.GetKey(accelerateKey))
		{
			currentSpeed = speed;
		}
		else if(Input.GetKey(brakeKey))
		{
			if (currentSpeed != 0 || currentSpeed > 0)
			{
				currentSpeed -= brakeSpeed;
			}
		}
		Mathf.Clamp(currentSpeed, 0, Mathf.Infinity);

		myRB.velocity = transform.forward * currentSpeed;

		Debug.Log("The current speed is:" + currentSpeed);
		currentVelocity = myRB.velocity;
	}
}
