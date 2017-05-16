using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {

	public int damage = 20;
		
	void Start () {
		Destroy (this.gameObject, 1f);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Got'em");

	}

}	

