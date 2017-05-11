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

	Vector3 v3_intersectPoint;

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
			print (gameObject.name +" touch: " + ltouch.name);

			Vector3 v3_other = ltouch.transform.position;
			Vector3 v3_parent = transform.parent.parent.transform.position;
			Vector3 dist_two = v3_other - v3_parent;

		//	float radius = transform.parent.parent.GetComponent<CircleCollider2D> ().radius;
			float radius = ltouch.transform.GetComponent<CircleCollider2D> ().radius;


//			if (ltouch.transform.GetComponent<CircleCollider2D> ().radius == 0.95f)
//			{
//				print ("= w1");
				v3_intersectPoint = v3_parent + dist_two.normalized /* * radius*/ ; //0.55, 0.6 是齿轮的边边宽度
//			}
//			if (ltouch.transform.GetComponent<CircleCollider2D> ().radius == 2f)
//			{
//				print ("= w2");
//				v3_intersectPoint = v3_parent + dist_two.normalized * radius/2f ; //0.55, 0.6 是齿轮的边边宽度
//			}

			Vector3 v3_inGear = v3_intersectPoint + (v3_other - v3_intersectPoint).normalized * 0.6f/2f ; //(0.6f/2f)是半径之差除以2 ???

//			print("npc move to another gear.");
			print ("v3_other: " + v3_other);
			print ("v3_intersectPoint: " + v3_intersectPoint);
			print ("v3_inGear: " + v3_inGear);

			transform.DOMove (v3_inGear, 0.5f, false);


		}
	}
}
