using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlanetPlayerController : MonoBehaviour {

	//inspector variables
	[Header("Utility settings")]
	public float speed;

	//internal variables
	CharacterController CC;

	Vector3 direction;
	Vector3 movement;

	float fb;
	float lr;

	// Use this for initialization
	void Start () {
		CC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		fb = Input.GetAxisRaw("forwardBackwardWalking");
		lr = Input.GetAxisRaw("leftRightWalking");

		direction = new Vector3(lr, 0, fb);
		direction = transform.rotation * direction;
		
		movement = direction * (Time.deltaTime * speed);

		CC.Move(movement);
	}
}
