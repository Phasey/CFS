using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float damage = 2;

	void OnTriggerEnter(Collider other){

		Debug.Log (other.tag);
		if (other.tag == "Enemy") {
			other.GetComponent<Enemy> ().TakeDamage (damage);
			Destroy (this.gameObject);
		}
	}	
}
