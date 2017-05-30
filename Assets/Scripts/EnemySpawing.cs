using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawing : MonoBehaviour {

	//Gives a List of popsitions that the Enemies can spawn at.
	public List<Transform> spawnPositionList = new List<Transform> ();

	//A List of different robots that can be spawned.
	public List<GameObject> spawnRobotList = new List<GameObject> ();


	//The Game Object of the Enemy robot.
	public GameObject robotPrefab;

	//the time inbetween spawning and not spawning.
	public float timeBetweenSpawns = 5f;

	//the Timer for spawning
	public float spawningTimer;


	//--------------------------------------------------------------------------------------
	//	Update()
	// 			Runs every frame
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	void Update () {
		SpawnEnemies ();
	}

	//--------------------------------------------------------------------------------------
	//	SpawnEnemies()
	// 					Finds the given positions and robots.
	//					When the time is greater than the spawn times, It spawns a random robot at a random position.
	// Param:
	//		None
	// Return:
	//		Void
	//--------------------------------------------------------------------------------------
	public void SpawnEnemies(){
		Transform spawnPositionToUse = null;
		GameObject robotToSpawn = null;
		if (Time.time - spawningTimer > timeBetweenSpawns) {
			spawnPositionToUse = spawnPositionList [Random.Range (0, spawnPositionList.Count)];
			robotToSpawn = spawnRobotList [Random.Range (0, spawnRobotList.Count)];
			Instantiate (robotPrefab, spawnPositionToUse.transform.position, Quaternion.identity);
			spawningTimer = Time.time;
		}
	}
}
