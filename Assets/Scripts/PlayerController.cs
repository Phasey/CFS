using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {	


	//How fast the player can move and the speed it can move at 1 time.
	public float movementSpeed = 60;
	public float maxSpeed = 5;

	//This gives the position/Direction of where the dash will go. - The time it takes to dash and the speed of which it does so.
	public Vector3 dashDirection;
	public float timeBetweenDashs = 0.5f;
	private float dashTimer;
	public float dashTime = 1f;
	public float dashSpeed = 1f;
	public float dashStopSpeed = 0.1f;
	public float dashForce = 10;
	public bool canDash = true;

	//Finds the Rigidbody and XboxController within the whole program naming it as rigidBody and controller within this script.
	public Rigidbody rigidBody;
	public XboxController controller;

	//Shooting/where the obj spawns/the obj itself/ a timer for the 
	public Transform bulletSpawPosition;
	public GameObject bulletPrefab;
	private float shootingTimer;
	public float timeBetweenShots = 0.02f;
	//Grenades
	public Transform grenadeSpawnPosition;
	public GameObject grenadePrefab;
	public float grenadeTimer;
	public float timeBetweenGrenades = 0.02f;

	//keeps the directioin in which the player was facing and stores it as forward.
	public Vector3 previousRotationDirextion = Vector3.forward;       


	//--------------------------------------------------------------------------------------
	//	Start()
	// 			Runs during initialisation
	// Param:
	//			None.
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs every frame, Calls RotatePlayer FireGun and ThrowGrenade

	// Param:
	//		None
	// Return:
	//		Void
	//---------------------------------------------------------------------------- ----------
	void Update(){
		RotatePlayer ();
		FireGun ();
		ThrowGrenade();
	}

	//--------------------------------------------------------------------------------------
	//	RotatePlayer()
	// 			checks to see if the right thumbstick is not being used, if not keeps shooting in the same direction.
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------	
	private void RotatePlayer(){
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);
		Vector3 directionVector = new Vector3 (rotateAxisX, 0 ,rotateAxisZ);

		//checks to see if the right thumbstick is not being used, if not keeps shooting in the same 
		//direction

		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirextion;
		}
		directionVector = directionVector.normalized;
		previousRotationDirextion = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);
	}

	//--------------------------------------------------------------------------------------
	//	FixedUpdate()
	// 			Runs every frame for Physics
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void FixedUpdate () {
		MovePlayer ();
	}

	//--------------------------------------------------------------------------------------
	//	MovePlayer()
	// 			Gives the controlls to the player.
	//			Allows the player to gain speed(dash) if LT is pressed. once complete in returns to normal speed.
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	private void MovePlayer(){

		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		float dash = XCI.GetAxis (XboxAxis.LeftTrigger, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rigidBody.AddForce(movement * movementSpeed * dashSpeed);
		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;	
		}
		if(XCI.GetAxis(XboxAxis.LeftTrigger) >0.01f){

			if (canDash) {
				canDash = false;
				dashSpeed = 10;
				Invoke ("StopDash", dashTime);
				Invoke ("ResetDash", dashTime + timeBetweenDashs);
			}
		}
	}

	//--------------------------------------------------------------------------------------
	//	StopDash()
	// 			reverts the player to normal speed 
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------	
	private void StopDash(){
		dashSpeed = 1;
	}


//--------------------------------------------------------------------------------------
	//	ResetDash()
	// 			Allows the player to use dash
	// Param:
	//		None
	// Return:
	//		Void
//--------------------------------------------------------------------------------------	
	private void ResetDash(){
		canDash = true;	
	}

//--------------------------------------------------------------------------------------
	//	FireGun()
	// 			When pressed if the timer allows it (timer is > than between shots) than it will shoot in said direction
	// Param:
	//		None
	// Return:
	//		Void
//--------------------------------------------------------------------------------------	
	private void FireGun(){
		if (XCI.GetAxis(XboxAxis.RightTrigger) > 0.15f){
			if (Time.time - shootingTimer > timeBetweenShots) {
				GameObject GO = Instantiate (bulletPrefab, bulletSpawPosition.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce(transform.forward * 20, ForceMode.Impulse);
				Destroy(GO, 3);
				shootingTimer = Time.time;
			}
		}
	}


//--------------------------------------------------------------------------------------
	//	ThrowGrenade()
	// 			When pressed if the timer allows it (timer is > than between throws) than throw grenade in said direction			
	// Param:
	//		None
	// Return:
	//		Void
//--------------------------------------------------------------------------------------
	private void ThrowGrenade(){
		if (XCI.GetButtonDown(XboxButton.RightBumper)){
			if (Time.time - grenadeTimer > timeBetweenGrenades) {
				GameObject GO = Instantiate (grenadePrefab, grenadeSpawnPosition.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce(transform.forward * 80, ForceMode.Impulse);
				Destroy (GO, 3);
				grenadeTimer = Time.time;
			}
		}
	}
}