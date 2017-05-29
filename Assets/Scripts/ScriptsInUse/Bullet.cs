using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Bullet : MonoBehaviour {
	
	//public GameObject whatIsThis;

	public float damage = 20;

	void Update() {
		
	}

	void OnTriggerEnter(Collider other){

		//whatIsThis =other.gameObject;
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy> ().TakeDamage (damage);
			Destroy (this.gameObject);
		}
	}	

}