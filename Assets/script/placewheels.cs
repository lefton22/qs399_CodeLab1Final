﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placewheels : MonoBehaviour {

	int whichWHeel;
	bool isClick;
	bool isClick2;
	bool isFollowCilck;
	GameObject lline_w2;
	GameObject lline_w3;

    public GameObject wheel_n;
	GameObject lwhatwouldhappen;
	int num_wheels2 =0;


	void Start () 
	{
		whichWHeel = 0;
		isClick = true;
		isFollowCilck = false;

		lline_w2 = GameObject.Find ("w_buildCue");
		lline_w3 = GameObject.Find ("w2_buildCue");

		lwhatwouldhappen = GameObject.Find ("whatwouldhappen");


	}
	

	void Update () 
	{
		//Debug.Log ("isClick: "+ isClick);

////if click the button1, w2 will follow the mouse until click agian and place w2 to a new place.
		if (whichWHeel == 1)
		{
			buildW2 ();
//			isClick = false;
//////w2 follow my mouse!
//
//////and then click to place the wheel
//			if (Input.GetMouseButtonDown (0) && !isClick)
//			{
//				if (eachGearManager.canIbuild == true)
//				{
//					//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
//					Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//					mouseV3.z = 0;
//					Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);
//
//					////initiate a wheel from refab
//
//					wheel_n = Instantiate (Resources.Load ("w2"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
//					//mouseV3 is the place which it will be born. 
//
//					num_wheels2 = num_wheels2 + 1;
//
//					wheel_n.name = "w2" + num_wheels2;
//
//
//					isClick = true;
//					whichWHeel = 0;
//					lline_w2.SendMessage ("hide");
//
//					lwhatwouldhappen.SendMessage ("buildHappen");
//
//					//Debug.Log ("what's new wheel: " + wheel_n);
//				}
//			}
		}

		if (whichWHeel == 2)
		{
			isClick2 = false;

			if (Input.GetMouseButtonDown (0)  && !isClick2) 
			{
				if (eachGearManager.canIbuild == true) {
					//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
					Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					mouseV3.z = 0;
					//Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

					////initiate a wheel from refab

					GameObject wheel_n2 = Instantiate (Resources.Load ("w1"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
					//mouseV3 is the place which it will be born. 

					mouseAll.caniDrag = true;
					//print ("mouseAll.caniDrag : " +mouseAll.caniDrag );

					isClick2 = true;
					whichWHeel = 0;
					lline_w3.SendMessage ("hide");


					//Debug.Log ("what's new wheel: " + wheel_n2);

				}
			}

		}

	}

	public void pickupW2()
	{
		whichWHeel = 1;
		print ("run pickupW2();" +"whichWHeel: " + whichWHeel);

		lline_w2.SendMessage ("appear");
		//gameObject.GetComponent<mouseAll> ().ca
		mouseAll.caniDrag = false;
	}

	public void pickupW3()
	{
		whichWHeel = 2;
		print ("run pickupW3();" +"whichWHeel: " + whichWHeel);

		lline_w3.SendMessage ("appear");
		mouseAll.caniDrag = false;
	}

	void buildW2()
	{
		isClick = false;
		////w2 follow my mouse!

		////and then click to place the wheel
		if (Input.GetMouseButtonDown (0) && !isClick)
		{
//			print ("click mouse");
			if (eachGearManager.canIbuild == true)
			{
				//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
				Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouseV3.z = 0;
//				Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

				////initiate a wheel from refab

				wheel_n = Instantiate (Resources.Load ("w2"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
				//mouseV3 is the place which it will be born. 

				num_wheels2 = num_wheels2 + 1;

				wheel_n.name = "w2" + num_wheels2;

				mouseAll.caniDrag = true;
				//print ("mouseAll.caniDrag : " +mouseAll.caniDrag );


				isClick = true;
				whichWHeel = 0;
				lline_w2.SendMessage ("hide");

				lwhatwouldhappen.SendMessage ("buildHappen");


				//Debug.Log ("what's new wheel: " + wheel_n);
			}
		}
	}

//	public void pickupW1()
//	{
//		whichWHeel = 3;
//		print ("run pickupW3();" +"whichWHeel: " + whichWHeel);
//
//		lline_w3.SendMessage ("appear");
//	}
}
