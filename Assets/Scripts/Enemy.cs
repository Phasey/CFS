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



	private void Patrolling(){
		navAgent.destination = patrolNodes [nodePointer].position;
		if (Vector3.Distance (transform.position, patrolNodes [nodePointer].position) < 1f) {
			nodePointer++;

			if (nodePointer > patrolNodes.Count) {
				nodePointer = 0;
			}
		}

		if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
			currentState = enemyState.chasing;
		}
	}

	private void Chasing(){
		navAgent.destination = player.transform.position;

	}
	private void Shooting(){

	}

	private void Searching(){

	}





	public float health = 100;

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
		//if (Vector3.Distance (transform.position, player.transform.position) < detectionRange) {
		//	navAgent.destination = player.transform.position;
		//}
		if (currentState == enemyState.chasing) {
			Chasing ();
		} else if (currentState == enemyState.patrolling) {
			Patrolling ();
		} else if (currentState == enemyState.shooting) {
			Shooting ();
		} else if (currentState == enemyState.searching) {
			Searching ();
		}
	}

}