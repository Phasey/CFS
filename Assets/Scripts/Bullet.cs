using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class Bullet : MonoBehaviour {
	
	//Damage is how much the enemys loose on their health slowly killing them.
	public float damage = 20;

	//------------------------------------------------------------------------
	//when something enters this trigger while the program is running
	//and has the Tag of Enemy
	//object is destroyed once hit.
	//------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		//whatIsThis =other.gameObject;
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy> ().TakeDamage (damage);
			//Destroy (this.gameObject);
		}
	}	

}