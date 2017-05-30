using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	//The time it waits between each attack.
	public float timeBetweenAttacks = 0.5f;

	//A int which says how much damage is done
	public int attackDamage = 20;

	//The Game Object of the Player
	GameObject player;

	//Gets the PlayerHealth Script and states it aas playerHealth
	PlayerHealth playerHealth;

	//If the player is within range of the enemies attack.
	bool playerInRange;

	// The time it takes to attack
	float timer;

	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs before the Start Function
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	//--------------------------------------------------------------------------------------
	//	OnTriggerEnter()
	// 			Runs every frame
	// Param:
	//		Collider other -if the player enters this trigger it will activate the attack
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other){
		if (other.gameObject == player) {
			playerInRange = true;
		}		
	}

	//--------------------------------------------------------------------------------------
	//	OnTriggerExit()
	// 			Runs every frame
	// Param:
	//		Collider other - if the player exits after being entered
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void OnTriggerExit (Collider other){
		if (other.gameObject == player){	
			playerInRange = false;
		}
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
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && playerInRange){
			Attack();
			if (playerHealth.currentHealth <=0){
				Debug.Log("you're dead");
			}

		}
	}

	//--------------------------------------------------------------------------------------
	//	Attack()
	// 			when timer is finished. If the players Health is greater than 0 he will be attacked
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
		void Attack(){
			timer = 0f;
			if (playerHealth.currentHealth >0){
				playerHealth.TakeDamage(attackDamage);
			}
		}
}
