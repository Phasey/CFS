using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Bullet : MonoBehaviour {
	
	//Damage is how much the enemys loose on their health slowly killing them.
	public float damage = 20;

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// 			Trigger detection. this detects when a bullet passes through it.
	// 
	// Param:
	//			Collider other - The collider of any objects that pass into this trigger.
	// Return:
	//		void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		//whatIsThis =other.gameObject;
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy> ().TakeDamage (damage);
			//Destroy (this.gameObject);
		}
	}	

}