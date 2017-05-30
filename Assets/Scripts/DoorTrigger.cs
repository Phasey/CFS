using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public GameObject doorToOpen;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("Yes");
			doorToOpen.SetActive (false);
			this.gameObject.SetActive (false);
		}
	}

	void OnDrawGizmos(){

		if (doorToOpen) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (transform.position, doorToOpen.transform.position);

		}
	}
	
}
