using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public float detectionRange=12;
	public GameObject player;
	public NavMeshAgent navAgent;

	public float health = 100;

	public void TakeDamage(float damage){
		health = health - damage;
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}


	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		navAgent = GetComponent<NavMeshAgent> ();
	}

	void Update(){
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			navAgent.destination = player.transform.position;
		}
	}
}