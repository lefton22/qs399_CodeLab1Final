using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eachGear : MonoBehaviour {
	//this script will attacth to each gear that generate

	float lpowerSlave;


	void Start () 
	{
		lpowerSlave = GameObject.Find ("whatwouldhappen").GetComponent<newhappen> ().powerSlave;

		//how about the amounts of the teeth?
		//ho
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, 0, Time.deltaTime * lpowerSlave); 
	}
}
