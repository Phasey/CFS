using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawing : MonoBehaviour {

	public List<Transform> spawnPositionList = new List<Transform> ();
	public List<GameObject> spawnRobotList = new List<GameObject> ();
	public GameObject robotPrefab;


	public float timeBetweenSpawns = 5f;
	public float spawningTimer;


	

	void Update () {
		SpawnEnemies ();
	}

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
