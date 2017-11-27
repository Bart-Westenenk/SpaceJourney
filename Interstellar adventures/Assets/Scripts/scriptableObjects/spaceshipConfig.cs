using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceShipConfig", menuName = "Configuration/spaceshipConfig")]
public class spaceshipConfig : ScriptableObject {

	[Tooltip("What should be the maximum speed the spaceship could reach?")]
	public float maxSpeed;
	[Space]
	[Tooltip("How fast should it go to maxspeed?")]
	public float accelerationSpeed;
	[Space]
	[Tooltip("How fast should the speed go down?")]
	public float brakeSpeed;
	[Space]
	[Tooltip("How fast should the player be able to pitch?")]
	public float pitchSpeed;
	[Space]
	[Tooltip("How fast should the player be able to pitch?")]
	public float rollSpeed;
	[Space]
	[Tooltip("How fast should the player be able to Jaw left and right")]
	public float yawSpeed; 

}
