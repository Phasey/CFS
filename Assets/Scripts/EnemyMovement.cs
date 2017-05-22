using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//public class EnemyMovement : MonoBehaviour {
//
//
//	Transform player;
//	NavMeshAgent nav;
//	public float MoveSpeed = 4;
//	public float MaxDist = 10;
//	public float MinDist = 5;
//
////	void Awake (){
////
////		player = GameObject.FindGameObjectWithTag ("Player").transform;
////		nav = GetComponent <NavMeshAgent> ();
////
////	}
//
//	void Update () {
//		//nav.SetDestination (player.position);
//		transform.LookAt(player);
//		if (Vector3.Distance(transform.position,player.position) > MinDist){
//			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
//		}
//
//		if (Vector3.Distance (transform.position, player.position) < MaxDist) {
//		}
//	}
//}
