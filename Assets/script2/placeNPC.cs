﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeNPC : MonoBehaviour {


	bool isPickNPC;
	bool isPickNPC2;

	bool isClick2;
	bool isClick2_2;

	GameObject lnpc_line;

	public bool isEmpty;
	public bool isEmpty2;

	int num_npc_n2 = 0;
	int num_npc2_n2 = 0;

	void Start () 
	{
		isEmpty = false;
	}
	

	void Update () 
	{
		if (isPickNPC) 
		{
			isClick2 = false;

			if (Input.GetMouseButtonDown (0)  && !isClick2) 
			{
//				if (eachGearManager.canIbuild == true) 
//				{
					//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
					Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					mouseV3.z = 0;
					
					GameObject.Find ("npc_line").SendMessage ("hideNPC");
//					GameObject.Find ("npc_line").SendMessage ("moveAway");
						
					GameObject.Find ("npc_line").transform.position = new Vector3 (999f, 999f, 999f);
			 		GameObject.Find ("npc_line").GetComponent<BoxCollider2D> ().enabled = false;
					print ("move away!");

					//Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

					////initiate a wheel from refab

					GameObject npc_n2 = Instantiate (Resources.Load ("npc"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
					//mouseV3 is the place which it will be born. 
					
					//num_npc_n2 = num_npc_n2 + 1;

					npc_n2.name = "npc";
					mouseAll.caniDrag = true;
					//print ("mouseAll.caniDrag : " +mouseAll.caniDrag );

					//lnpc_line.SendMessage ("hide");

				    isEmpty = true; 
					
					isClick2 = true;

				    isPickNPC = false;
					print ("npc fall on ground.");



//			  }				    
			}
		}

		if (isPickNPC2) 
		{
			isClick2_2 = false;

			if (Input.GetMouseButtonDown (0)  && !isClick2_2) 
			{
				//				if (eachGearManager.canIbuild == true) 
				//				{
				//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
				Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouseV3.z = 0;

				GameObject.Find ("npc_line").SendMessage ("hideNPC");
				//					GameObject.Find ("npc_line").SendMessage ("moveAway");

				GameObject.Find ("npc_line").transform.position = new Vector3 (999f, 999f, 999f);
				GameObject.Find ("npc_line").GetComponent<BoxCollider2D> ().enabled = false;
				print ("move away!");

				//Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

				////initiate a wheel from refab

				GameObject npc2_n2 = Instantiate (Resources.Load ("npc2"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
				//mouseV3 is the place which it will be born. 
				//num_npc2_n2 = num_npc2_n2 + 1;

				npc2_n2.name = "npc2";
				mouseAll.caniDrag = true;
				//print ("mouseAll.caniDrag : " +mouseAll.caniDrag );

				//lnpc_line.SendMessage ("hide");

				isEmpty2 = true; 

				isClick2_2 = true;

				isPickNPC2 = false;
				print ("npc2 fall on ground.");
				//			  }

			}

		}
			
	}

	public void putNPC()
	{
		print ("place a npc");
		isPickNPC = true;
		isEmpty = false; 

		//eachGearManager.canIbuild = false;

		GameObject.Find ("npc_line").SendMessage ("showNPC");



	}

	public void putNPC2()
	{
		print ("place a npc2");
		isPickNPC2 = true;
		isEmpty2 = false; 

		//eachGearManager.canIbuild = false;

		GameObject.Find ("npc_line").SendMessage ("showNPC");

	}
}
