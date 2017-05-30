using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public float detectionRange=12;
	public GameObject player;
	public NavMeshAgent navAgent;

	public enum enemyState {patrolling, chasing, shooting, searching};
	public enemyState currentState = enemyState.patrolling;

	public List<Transform> patrolNodes = new List<Transform>();
	public int nodePointer;








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
//
	void Update(){
		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			navAgent.destination = player.transform.position;
		}
//		if (currentState == enemyState.chasing) {
//			Chasing ();
//		} else if (currentState == enemyState.patrolling) {
//			Patrolling ();
//		} else if (currentState == enemyState.shooting) {
//			Shooting ();
//		} else if (currentState == enemyState.searching) {
//			Searching ();
//		}
//	}
	}
}