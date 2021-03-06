﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {	

	public List<GameObject> g = new List<GameObject> ();
	//PlayerSpeed
	public float movementSpeed = 60;
	public float maxSpeed = 5;
	//Dash SetUp
	public Vector3 dashDirection;
	public float timeBetweenDashs = 0.5f;
	private float dashTimer;
	public float dashTime = 1f;
	public float dashSpeed = 1f;
	public float dashStopSpeed = 0.1f;
	public float dashForce = 10;
	public bool canDash = true;
	//Player
	public Rigidbody rigidBody;
	public XboxController controller;

	//Shooting
	public Transform bulletSpawPosition;
	public GameObject bulletPrefab;
	private float shootingTimer;
	public float timeBetweenShots = 0.02f;
	//Grenades
	public Transform grenadeSpawnPosition;
	public GameObject grenadePrefab;
	public float grenadeTimer;
	public float timeBetweenGrenades = 0.02f;


	public Vector3 previousRotationDirextion = Vector3.forward;       

	//private float currentDashTime;



	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody = GetComponent<Rigidbody> ();

		//currentDashTime = dashTime;
	}
	void Update(){
		RotatePlayer ();
		FireGun ();
		//DashPlayer();
		ThrowGrenade();
	}

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

	// Update is used for physics
	void FixedUpdate () {
		MovePlayer ();
	}

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
	private void StopDash(){
		dashSpeed = 1;
	}

	private void ResetDash(){
		canDash = true;	
	}

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



//	private void DashPlayer(){
//
//		float leftTrigger = XCI.GetAxis (XboxAxis.LeftTrigger, controller);
//		if  (XboxAxis.LeftTrigger = true){
//			GetComponent<Rigidbody> ().AddForce (transform.forward * dashForce, ForceMode.Impulse);
//
//		}

//		float leftTrigger = XCI.GetAxis (XboxAxis.LeftTrigger, controller);
//
//		//if (XCI.GetAxis (XboxAxis.LeftTrigger) = ) {
//			currentDashTime = 0.0f;
//		//}
//		if (currentDashTime < dashTime){
//			dashDirection = new Vector3 (0, 0, dashSpeed);
//			currentDashTime += dashStopSpeed;
//		}//else{
//		//	dashDirection = Vector3.zero;	
//		//}
}