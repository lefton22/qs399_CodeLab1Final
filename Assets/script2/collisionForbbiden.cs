using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionForbbiden : MonoBehaviour 
{
	//when build, remove, this object will be called. 

	Renderer render;

	bool iswhenmove;

	bool canDrop;

	//float  clickTime;

	void Start () 
	{
		render = gameObject.GetComponent<SpriteRenderer> ();
		canDrop = true;
	}
	

	void Update () 
	{
		if (iswhenmove) 
		{
			render.enabled = true;
			gameObject.transform.position =
				new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
				Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);



			if (Time.time - dragAndDrop.clickTime > 0.3f) 
			{
				if (Input.GetMouseButtonDown (1)  && canDrop) 
				{
					iswhenmove = false;
					render.enabled = false;
					dragAndDrop.isFollowMouse = false;
					transform.position = new Vector3 (999f, 999f,0);

					dragAndDrop.caWheel.SetActive (true);
					setPlaceouse ();
					print ("set active in forbbiden.");

					//mouseAll.caniDrag = true; // it will make a bug.
				}
			}
		}
		//gameObject.GetComponent<CircleCollider2D> ().radius = 1;
	}

	void whenBuild()
	{
		print ("whenBuild();");
	}

	void whenMove()
	{
		iswhenmove = true;
		//clickTime = Time.time;

		print ("whenMove();");

	}

	void setPlaceouse()
	{
		dragAndDrop.caWheel.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 
			Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "wheel" || other.tag =="hasSlave")
		{
		canDrop = false;
		GameObject.Find ("forbbid_col").GetComponent<SpriteRenderer> ().enabled = true; // the child "forbbid_col" appear
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			canDrop = true;
			GameObject.Find ("forbbid_col").GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

}
