using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {


	//movement
	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	//body rotation
	public GameObject GoodRobot;
	public float goodRobotRotateSpeed = 2;

	//Controls
	public KeyCode forwardKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (forwardKey)) {
			transform.position += transform.forward * movementSpeed;

		}
		if (Input.GetKey (backwardsKey)) {
			transform.position += transform.forward * -movementSpeed;
		}
		if (Input.GetKey (rotateRightKey)) {
			transform.Rotate (Vector3.up * rotateSpeed);

		}
		if (Input.GetKey (rotateLeftKey)){
			transform.Rotate (Vector3.up * -rotateSpeed);
		}

	}

	void FixedUpdate (){



	}
}

