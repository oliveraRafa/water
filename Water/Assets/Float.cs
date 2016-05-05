using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {

 public float waterLevel;
 public float floatHeight;
 public float bounceDamp;﻿
 public Vector3 buoyancyCentreOffset;
 
 private float forceFactor;
 private Vector3 actionPoint;
 private Vector3 uplift;
 private WaveController waveScript;
 
 private Vector3 WavesCentreOffset;
 private bool invertMove;

 void Start() {
	//Get the waveControllerScript
	GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
	waveScript = gameController.GetComponent<WaveController>();
 }
 
 void Update () {
 
	moveObject(buoyancyCentreOffset.x, buoyancyCentreOffset.z);
  
  WavesCentreOffset = new Vector3(buoyancyCentreOffset.x, buoyancyCentreOffset.y, buoyancyCentreOffset.z);
  actionPoint = transform.position + transform.TransformDirection(WavesCentreOffset);
  forceFactor = 1f - ((actionPoint.y - waterLevel+waveScript.GetWaveYPos(actionPoint.x, actionPoint.z)) / floatHeight);
  
  if (forceFactor > 0f) 
  {
   uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * bounceDamp);
   GetComponent<Rigidbody>().AddForceAtPosition(uplift, actionPoint);
  }
 }
 
 void moveObject(float posX,float posZ){
 	// if (buoyancyCentreOffset.x <= -0.001)
		// invertMove = true;
	// if (buoyancyCentreOffset.x >= 0.001)
		// invertMove = false;
		
	// if (invertMove)	
		// buoyancyCentreOffset.x = buoyancyCentreOffset.x + 0.00001f;
	// else
		// buoyancyCentreOffset.x = buoyancyCentreOffset.x - 0.00001f;
	//buoyancyCentreOffset.x = waveScript.GetWaveYPos(posX, posZ);
 }
}﻿