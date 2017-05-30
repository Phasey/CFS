using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	//target is what the camera centers around
	public Transform target;

	//How smooth the camera follws the target
	public float smoothing = 5f;

	//This is the position the camera stays in while following the player
	Vector3 offset;

	//--------------------------------------------------------------------------------------
	//	Start()
	// Runs during initialisation
	//
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------	
	void Start(){
		offset = transform.position - target.position;
	}

	//--------------------------------------------------------------------------------------
	//	FixedUpdate()
	//  Runs every frame for Physics.
	//
	// Param:
	//			
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void FixedUpdate() {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);			
	}
}