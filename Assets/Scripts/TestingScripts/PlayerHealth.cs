using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	//The number of Health points the player has in total and currently.
	public int startingHealth = 100;
	public int  currentHealth;

	//Referances the UI elements of the Slider and Image as healthSlider and damageImage.
	public Slider healthSlider;
	public Image damageImage;

	//The speed that the damage image is shown on screen for
	public float flashSpeed = 5f;

	//The colour of flash that the damage image shows.
	public Color flashColour = new Color(1f,0f,0f,0.1f);

	//states the Script is assigned to playerMovement.
	PlayerController playerMovement;

	//A bool that says if the player is dead or not.
	bool isDead;

	//A bool that says if the player is being damaged.
	bool damaged;

	//--------------------------------------------------------------------------------------
	//	Awake()
	// 			Runs before the Start function.
	//			grabs the player controller script and uses information for it.
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Awake () {
		playerMovement = GetComponent <PlayerController> ();
		currentHealth = startingHealth;
	}
	
	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs every frame
	//			If the player is being damaged the damage image shows else nothing happens.
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		if (damaged == true) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}


	//--------------------------------------------------------------------------------------
	//	TakeDamage()
	// 			If Plaer is being damaged lose the damage given, Health slider goes down equal amount
	//			If player is dead health = 0
	// Param:
	//		int amount - is the amount of damage given upon the player.
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void TakeDamage (int amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	//--------------------------------------------------------------------------------------
	//	Death()
	// 			If the players health is 0 = isDead. If so player movemnet is disabled.
	// Param:
	//		None.
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	private void Death(){
		isDead = true;
		playerMovement.enabled = false;
	}
}