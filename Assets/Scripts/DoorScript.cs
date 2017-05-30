using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	//The Game Object of the Door.
	public GameObject doorToOpen;

	//A bool to say if the Door can be opened or not.
	public bool canOpen;

	//A float that stores the time before the door can be unlocked.
	public float doorTimer = 2;

	//Once the Timer reaches this time the Door opens.
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

