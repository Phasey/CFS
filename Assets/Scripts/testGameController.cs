using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameController : MonoBehaviour {

	public GameObject movementMarker;
	public GameObject player;

	public LayerMask raycastLayerMask;


	void Update(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distanceOfRay = 100;
		if (Physics.Raycast (ray, out hit, distanceOfRay, raycastLayerMask)) {




			movementMarker.transform.position = hit.point;
			if (Input.GetMouseButton (0)) {
				if (hit.transform.tag == "Ground") {
					movementMarker.transform.position = hit.point;

					player.GetComponent<testPlayer> ().MovePlayer (hit.point);

				}
			} else if (Input.GetMouseButton (1)) {
				if (hit.transform.tag == "Enemy") {
					Debug.DrawLine (player.transform.position, hit.transform.position, Color.yellow, 0.1f);
					player.GetComponent<testPlayer> ().Attack (hit.transform.position);
				}
			}

		}
	}
}