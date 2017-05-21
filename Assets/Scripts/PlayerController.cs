using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;



public class PlayerController : MonoBehaviour {
	//movement
	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	//body rotation
	public GameObject GoodRobot;
	public float goodRobotRotateSpeed = 2;

	//Controls
	public KeyCode forwardKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;





}

