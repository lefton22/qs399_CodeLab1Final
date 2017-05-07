using System.Collections;
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
	bool isFollowMouse;
	GameObject caWheel;

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (mouseAll.caniDrag) 
			{
				RaycastHit2D[] hits; 
				hits = Physics2D.RaycastAll (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

				for (int i = 0; i < hits.Length; i++) 
				{
					if (hits [i].collider != null) 
					{
						if (hits [i].collider.gameObject.tag == "wheel" || hits [i].collider.gameObject.tag == "hasSlave") 
						{
							Debug.Log ("Target Position: " + i + ": " + hits [i].collider.gameObject.transform.position);
							isFollowMouse = true;
							caWheel = hits [i].collider.gameObject;
//							hits [i].transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
//								Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);

						}
					}
				}
			}
		}


		if (isFollowMouse) 
		{
			print ("isFollow");
			caWheel.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);


		}
	}
}
