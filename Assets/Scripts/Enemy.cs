using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	// The distance in which a Enemy will notice you and start chasing the player.
	public float detectionRange=12;

	//The Game Object that is the Player.
	public GameObject player;

	//The NavMesh Agent which is assigned to the Enemy.
	public NavMeshAgent navAgent;

	//What amount of health is stored for the Enemy.
	public float health = 100;

	//--------------------------------------------------------------------------------------
	//	TakeDamage()
	// 			Determinds if the Enemy takes damage and how much they take. If Health = 0 
	//   		obj is destroyed
	// Param:
	//		Holds the float damage. 
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void TakeDamage(float damage){
		health = health - damage;
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	//--------------------------------------------------------------------------------------
	//	Start()
	// 			Runs during initialisation
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		navAgent = GetComponent<NavMeshAgent> ();
	}

	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs every frame
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update(){
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			navAgent.destination = player.transform.position;
		}
	}
}