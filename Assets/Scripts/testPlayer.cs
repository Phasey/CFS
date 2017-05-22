using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testPlayer : MonoBehaviour {

	private float timer;
	public float timeBetweenAttacks = 0.2f;
	public GameObject bulletPrefab;
	public float bulletSpeed = 5f;

	public void Attack(Vector3 attackLocation){

		if (Time.time - timer > timeBetweenAttacks) {
			GameObject GO = Instantiate (bulletPrefab, transform.position, Quaternion.identity)as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce ((attackLocation - transform.position) * bulletSpeed, ForceMode.Impulse);
			Destroy (GO, 3f);
			timer = Time.time;
		}

	}

	NavMeshAgent agent;
	void Start(){
		agent = GetComponent<NavMeshAgent>();
		timer = Time.time;
	}





	public void MovePlayer(Vector3 newPosition){
		agent.SetDestination (newPosition);
	}
}