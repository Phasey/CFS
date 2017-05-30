using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	//
	public GameObject doorToOpen;
	//
	public bool canOpen;
	//
	public float doorTimer = 2;
	//
	public float timeBeforeDoorOpens = 10f;



	//--------------------------------------------------------------------------------------
	//	Start()
	// 			Runs during initialisation
	// Param:
	//			None.
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start () {		
		doorToOpen.SetActive (true);
	}

	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs every frame
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (Time.time - doorTimer > timeBeforeDoorOpens) {
			doorToOpen.SetActive (false);
		}
	}
}

