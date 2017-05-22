using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	public float speed = 20;
	public float rollWeight = 2;
	public float pitchWeight = 2;

	public float thrust = 5;

	public float maxThrust = 100;
	public float minThrust = 10;

	public GameObject bulletPrefab;
	public float bulletSpeed = 20;
	public Transform bulletSpawnPoint;
	public Transform bulletSpawnPoint1;
	public GameObject ship;



	//Stored info for where the ship starts
	public Quaternion startingRotation;
	public Vector3 startingPosition;

	void start(){
		startingPosition = transform.position;
		startingRotation = transform.rotation;
	}


	
	// Update is called once per frame
	void Update () {

		MovePlayer ();
		CheckPlayerPosition (transform.position.y, -50f, 50f);
		CheckPlayerPosition (transform.position.x, -500f, 500f);
		CheckPlayerPosition (transform.position.z, -500f, 500f);

		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, ship.transform.rotation) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (ship.transform.forward*bulletSpeed, ForceMode.Impulse);
			}

		if (Input.GetKeyDown (KeyCode.Mouse1)){
			GameObject GO1 = Instantiate (bulletPrefab, bulletSpawnPoint1.position, ship.transform.rotation) as GameObject;
			GO1.GetComponent<Rigidbody> ().AddForce (ship.transform.forward*bulletSpeed, ForceMode.Impulse);
		}

//		if (Input.GetKey (KeyCode.LeftShift)) {
//			
//		}

	}


	private void CheckPlayerPosition(float positionToCheck, float minValue, float maxValue ){

		if (positionToCheck < minValue || positionToCheck > maxValue) {
			ResetPlayer();
		}
//
//		//If the player passes thes  areas (-300, 300) it respawns
//		if (transform.position.y < -4 || transform.position.y > 300) {
//			ResetPlayer ();
//		}
//
//		if (transform.position.x < -300 || transform.position.x > 300) {
//			ResetPlayer ();
//		}
//
//		if (transform.position.z < -300 || transform.position.z > 300) {
//			ResetPlayer ();
//
//		}
	}

	private void MovePlayer(){
		
		float roll = -rollWeight*Input.GetAxis("Horizontal");
		float pitch = pitchWeight*Input.GetAxis("Vertical");
		Vector3 Rotation = new Vector3 (pitch, 0, roll);

		transform.Rotate (Rotation); 


		if (Input.GetButton ("Jump")) {
			speed = speed + thrust;

			if (speed > maxThrust) {
				speed = maxThrust;
			}

		} else {
			speed = speed - thrust;

			if (speed < minThrust) {
				speed = minThrust;
			}
		}
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	private void ResetPlayer() {

		transform.position = startingPosition;
		transform.rotation = startingRotation;
	}

	void OnCollisionEnter(){
		ResetPlayer ();

		//resets everything on the player
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
