using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour {

	static public float totalTime; //the "time" resources of the world

	float changeTime; // all elements which would change the time would put here

	float startTime;

	public static int gearsPosi;
	public static int gearsNega;

	void Start () 
	{
		startTime = 500f; // initial time resource

		changeTime = 0f;

		totalTime = startTime;
	}
	

	void Update () 
	{
		//print (Time.time);

		gearsPosi = 0;
		gearsNega = 0;
	//search gears which have the positive speed
		for (int i = 0; i < GameObject.Find ("eachGear_Manager").GetComponent<headLoop> ().head_withSlave.Count; i++) 
		{
			GameObject oo = GameObject.Find ("eachGear_Manager").GetComponent<headLoop> ().head_withSlave[i];

			if (oo.GetComponent<SingleGear0> ().speed > 0) 
			{
				gearsPosi =   gearsPosi + 1;
			}

			if (oo.GetComponent<SingleGear0> ().speed < 0) 
			{
				gearsNega = gearsNega + 1;
			}
		}
//		print ("  gearsPosi: " +   gearsPosi + ", gearsNega: "+ gearsNega );

		changeTime = gearsNega * 1 + gearsPosi * (-1); // 1 is the value that which gears consume

		totalTime =  totalTime -  1/* reduce one unit per second*/ + changeTime ;



	}

	void npcMeetnpc()
	{
		//print ("npc and npc meet and add 50 unit times.");
		totalTime = totalTime + 50f;
	}
}
