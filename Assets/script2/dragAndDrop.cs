﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour
{

//	public GameObject thisO;
//
//	Vector3 dist;
//	float posX;
//	float posY;
//
//	void OnMouseDown()
//	{
//
//		print ("drag");
//		dist = Camera.main.WorldToScreenPoint (transform.position);
//		posX = Input.mousePosition.x - dist.x;
//		posY = Input.mousePosition.y - dist.y;
//
//	}
//
//	void OnMouseDrag()
//	{
//		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
//		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
//		transform.position = worldPos;
//		print ("put");
//	}
//
//
	public static bool isFollowMouse;
	public static GameObject caWheel;

	public static float clickTime;

	void Update()
	{


		if (Input.GetMouseButtonDown (1)) 
		{
			if (mouseAll.caniDrag && !isFollowMouse) 
			{
				RaycastHit2D[] hits; 
				hits = Physics2D.RaycastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

				for (int i = 0; i < hits.Length; i++) 
				{
					if (hits [i].collider != null) 
					{
						if (hits [i].collider.gameObject.tag == "wheel" || hits [i].collider.gameObject.tag == "hasSlave") 
						{
							//Debug.Log ("Target Position: " + i + ": " + hits [i].collider.gameObject.transform.position);
							isFollowMouse = true;
							caWheel = hits [i].collider.gameObject;

							clickTime = Time.time;
//							hits [i].transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
//								Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);

						}
					}
				}
			}
		}


		if (isFollowMouse) 
		{
			//print ("isFollow");
			caWheel.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);//follow he mouse
			
			GameObject.Find ("forbbid").SendMessage("whenMove");

			caWheel.transform.position = new Vector3 (caWheel.transform.position.x, caWheel.transform.position.y, 10f);//移到天边，先// no use
			//caWheel.SetActive (false);

			mouseAll.caniDrag = false;

//			if (Time.time - clickTime > 0.3f ) 
//			{
//				if (Input.GetMouseButtonDown (0)) 
//				{
//					isFollowMouse = false;
//					//print ("isFollowMouse false: " + isFollowMouse);
//					//caWheel.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				}
////				if (!isFollowMouse) 
////				{
////					caWheel.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
////				}
//			}

		}

	}

	void showAgain()
	{
		
	}
}
