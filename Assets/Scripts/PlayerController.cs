using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
	

	public List<GameObject> g = new List<GameObject> ();
	//
	public float movementSpeed = 60;
	public float maxSpeed = 5;
	//
	public Vector3 dashDirection;
	public float timeBetweenDashs = 0.5f;
	private float dashTimer;
	public float dashTime = 1f;
	public float dashSpeed = 1f;
	public float dashStopSpeed = 0.1f;
	//
	public float dashForce = 10;
	public bool canDash = true;
	//
	public Rigidbody rigidBody;
	public XboxController controller;
	//
	//Shooting
	public Transform bulletSpawPosition;
	public GameObject bulletPrefab;
	private float shootingTimer;
	public float timeBetweenShots = 0.02f;
	//
	public Transform grenadeSpawnPosition;
	public GameObject grenadePrefab;
	public float grenadeTimer;
	public float timeBetweenGrenades = 0.02f;

	//
	public Vector3 previousRotationDirextion = Vector3.forward;       

	//private float currentDashTime;

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
	// 			Runs every frame
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update(){
		RotatePlayer ();
		FireGun ();
		//DashPlayer();
		ThrowGrenade();
	}

	//
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

	//
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
				//Set Dash Timer to Time.time
				//dashTimer = Time.time;

				canDash = false;
				dashSpeed = 10;
				Invoke ("StopDash", dashTime);
				Invoke ("ResetDash", dashTime + timeBetweenDashs);
			}
		}

//		if (Time.time - dashTimer < timeBetweenDashs) {
//			
//		} else {
//			canDash = false;
//			dashSpeed = 1;
//		}
		
	}


	//
	private void StopDash(){
		dashSpeed = 1;
	}


	//
	private void ResetDash(){
		canDash = true;	
	}

	//
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


	//
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