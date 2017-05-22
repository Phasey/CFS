using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public float detectionRange=12;
	public GameObject player;
	public NavMeshAgent navAgent;

	public float health = 6;

	public void TakeDamage(float damage){

		health = health - damage;

		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	void start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		navAgent = GetComponent<NavMeshAgent> ();
	}

	void Update(){
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			navAgent.destination = player.transform.position;
		}
	}





//	public Transform startNode;
//	public Transform endNode;
//	private	NavMeshAgent NMA;
//
//
//	void Start(){
//
//		NMA = GetComponent<NavMeshAgent> ();
//		NMA.destination = startNode.position;
//	}
//
//	void Update (){
//		if (Vector3.Distance (transform.position, startNode.position) < 2){
//			NMA.destination = endNode.position;
//
//		}
//		if (Vector3.Distance (transform.position, endNode.position) < 2){
//			NMA.destination = startNode.position;
//
//		}
//	}
//
}