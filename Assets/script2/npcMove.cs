using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class npcMove : MonoBehaviour {
	//when they meet with another gear, they go onto another gear.


	Collider2D thisCo;
	Collider2D thisParentCo;

	bool isGotoOtherGear;

	GameObject ltouch;

	Vector3 v3_other;
	Vector3 v3_parent;

	Vector3 dist_two;
	Vector2 v2_other;
	Vector2 v2_parent;
	Vector2 v2_dist_two;

	public float meetTime;

	void Start () 
	{
//		thisCo = gameObject.GetComponent<BoxCollider2D> ();
//		thisParentCo = transform.parent.transform.parent.GetComponent<CircleCollider2D> ();
//		Physics2D.IgnoreCollision (thisCo, thisParentCo, true);

		isGotoOtherGear = false;


	}

	// Update is called once per frame
	void Update () 
	{


////		if (isGotoOtherGear && touch != null)  
////		{
////			gameObject.transform.SetParent (touch.transform);
////			gameObject.GetComponent<BoxCollider2D>().enabled = false;
////
////			float thisRadius = 1.31f;
////			if (transform.position.x > thisRadius) 
////			{
////				//transform.DOMove (touch.transform.position, 3f, false);
////				print ("> 1.31f, " + "transform.localPosition.x: " +transform.localPosition.x/*"Mathf.Abs: " + Mathf.Abs (transform.position.x - thisRadius)*/);
////
////				float speed = 0.4f;
////				float step = speed * Time.deltaTime;
////				transform.position = Vector3.MoveTowards (transform.position, touch.transform.position, step);
////
////				//transform.position = Vector3.Lerp (transform.position, touch.transform.position, 0.2f);
////
////
////			}
////			if (transform.localPosition.x < thisRadius /*Mathf.Abs (transform.localPosition.x - thisRadius) < 0.1f */) 
////			{
////				isGotoOtherGear = false;
////
////				print ("change bool" );
////			}
////
////
////		 
////
////		}
//		int layer_mask = LayerMask.GetMask("wheel");
//
//		Debug.DrawLine (touch.transform.position, gameObject.transform.parent.transform.position, Color.cyan);
//		Vector3 v3_other = touch.transform.position;
//		Vector3 v3_parent = transform.parent.transform.position;
//
//		Vector3 dist_two = v3_other - v3_parent;
//
//		Vector2 v2_other = new Vector2 (v3_other.x, v3_other.y);
//		Vector2 v2_parent = new Vector2 (v3_parent.x, v3_parent.y);
//		Vector2 v2_dist_two = v2_parent - v2_other ;
//
//		Vector2 dir = v2_parent - v2_other;
//		RaycastHit2D[] hits;
//		hits = Physics2D.RaycastAll (v2_parent, dir);
//		for (int i = 0; i < hits.Length; i++) 
//		{
//			if (hits [i].collider != null) {
//				//print (gameObject.name + "'s  hit.point: " + i + ": " + hits[i].collider.name);
//
//			}
//		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
//			Vector3 dir_npc_wheel = gameObject.transform.transform.position - other.transform.position;
//			RaycastHit2D hit = Physics2D.Raycast(transform.position, - dir_npc_wheel);
//			Debug.DrawLine (gameObject.transform.position, other.transform.position, Color.cyan);
//			print ("hit point: " +hit.point);
									
//			touch =  other.gameObject;
//
//			////move logic
//			Vector3 v3_other = other.transform.position;
//			Vector3 v3_parent = transform.parent.transform.position;
//
//			Vector3 dist_two = v3_other - v3_parent;
//
//			Vector2 v2_other = new Vector2 (v3_other.x, v3_other.y);
//			Vector2 v2_parent = new Vector2 (v3_parent.x, v3_parent.y);
//			Vector2 v2_dist_two = v2_parent - v2_other ;

		////move logic, don't delete!!!!

//			float radius = transform.parent.GetComponent<CircleCollider2D>().radius;
//			Vector3 v3_intersectPoint = v3_parent + dist_two .normalized * radius/2f ; //0.55 是齿轮的边边宽度
//
//			Vector3 v3_inGear = v3_intersectPoint + (v3_other - v3_intersectPoint).normalized * (0.6f/2f); //(0.6f/2f)是半径之差除以2
//
//			print ("v3_intersectPoint: " + v3_intersectPoint);
//			print ("v3_inGear: " + v3_inGear);
//
//			transform.DOMove (v3_inGear, 0.5f, false);
//			//transform.position = v3_inGear;
//			transform.SetParent (other.gameObject.transform);
//
//			print ("NPC： " +gameObject + " collides with a wheel.");

		////move logic

		}


	}

	void moveToOther()
	{
		ltouch = transform.parent.parent.GetComponent<npcTransport>().touch;
		if (ltouch == null) 
		{
			print ("touch = null");
		}
		if (ltouch != null) 
		{
			//print ("touch: " + ltouch.name);

			Vector3 v3_other = ltouch.transform.position;
			Vector3 v3_parent = transform.parent.parent.transform.position;
			Vector3 dist_two = v3_other - v3_parent;


			float radius = transform.parent.parent.GetComponent<CircleCollider2D> ().radius;
			Vector3 v3_intersectPoint = v3_parent + dist_two.normalized * radius / 2f; //0.55 是齿轮的边边宽度

			Vector3 v3_inGear = v3_intersectPoint + (v3_other - v3_intersectPoint).normalized * (0.6f / 2f); //(0.6f/2f)是半径之差除以2

//			print("npc move to another gear.");
			//print ("v3_intersectPoint: " + v3_intersectPoint);
			//print ("v3_inGear: " + v3_inGear);

			transform.DOMove (v3_inGear, 0.5f, false);


			//transform.position = v3_inGear;
			//meetTime = Time.time;

			//gameObject.transform.SetParent (ltouch.transform);

			//print ("NPC： " + gameObject.name + " collides with a wheel: " + ltouch.name + "  and move");
		}
	}
}
