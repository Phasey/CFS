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

	//When program starts the camera sets its positition
	void Start(){
		offset = transform.position - target.position;
	}
	//The Vector3.Lerp makes the camera gradually and slowly follow the player so it isn't a rough follow.
	void FixedUpdate() {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);			
	}
}
