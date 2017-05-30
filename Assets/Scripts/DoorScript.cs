using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public GameObject doorToOpen;

	public bool canOpen;
	public float doorTimer = 2;

	public float timeBeforeDoorOpens = 10f;

	void Start () {
		
		doorToOpen.SetActive (true);
	}

	void Update () {
		if (Time.time - doorTimer > timeBeforeDoorOpens) {
			doorToOpen.SetActive (false);
		}
	}
}

