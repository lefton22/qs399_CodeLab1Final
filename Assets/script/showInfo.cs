﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showInfo : MonoBehaviour {


	public Text timeOfW1;

	rotate lrotate; 
	float ltimeHere_w1; 
	GameObject lw1;

	follow_rotate lfollow_rotate; 
	float ltimeHere_w2; 
	GameObject lw2;

	float ltimeHere_w3; 
	GameObject lw3;

	List<float> timeHeres;
	List<GameObject> allWheels;

	string whathappened;

	void Start () 
	{
		//lrotate = new rotate ();

		lw1 = GameObject.Find ("w1");
		lrotate = lw1.GetComponent<rotate>();

		lw2 = GameObject.Find ("w2");
		lfollow_rotate = lw2.GetComponent<follow_rotate>();

		lw3 = GameObject.Find ("w3");

		allWheels = new List<GameObject>();
		allWheels.AddRange(GameObject.FindGameObjectsWithTag("wheel"));

//		allWheels [7] = GameObject.Find ("w" + 2.ToString);
		//Debug.Log ("finding: " + allWheels [7]);
//		for (int i = 0; i < 100; i++) 
//		{
//			
//		}
	}

	void Update () 
	{
		
		//float w2 = GameObject.Find ("w2").GetComponent<follow_rotate> ().timeHere;  // get the varieble in that object's script!!!
		//float w3 = GameObject.Find ("w3").GetComponent<follow_rotate> ().timeHere; 

//		string json = GameObject.Find ("readJSON").GetComponent<readJSON> ().jsonString;

		//// get the time of W1 and w2 and shows them to the screen
//		ltimeHere_w1 = lrotate.timeHere;
//		ltimeHere_w2 = lfollow_rotate.timeHere;
		 //Debug.Log ("t1: "+ ltimeHere_w1);
		//t1 = lrotate.timeHere.ToString();

	//	timeOfW1.text = "Time in W1: " + ltimeHere_w1 + 
		//"\n" +  "Time in W2: " + w2 ;



		timeOfW1.text = "total time: " + Time_Manager.totalTime.ToString() + "   "+ whathappened;
	}

	void addnpc1()
	{
		whathappened = "add monster 1! consume your 50 time";
	}
	void addnpc2()
	{
		whathappened = "add monster 2! consume your 100 time";
	}

	void twonpcmeet()
	{
		whathappened = "two monsters meet .. but,  you have more 200 time";
	}

	void addgear2()
	{
		whathappened = "build a gear, its number is.. 1, and consume your 150 time.";
	}

	void end()
	{
		whathappened = "It should be *Game Over* now, pls press the PLAY button for twice.";
	}
}
