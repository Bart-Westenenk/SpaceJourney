using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Target;
	public Transform lookAt;
	[Space]
	[SerializeField] float posSmooth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * posSmooth);

		Vector3 direction = (lookAt.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.LookRotation(direction);

		transform.rotation = targetRotation;
	}
}
