using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcollideWithNpc : MonoBehaviour {

	Collider2D thisCo;
	Collider2D thisParentCo;

	SpriteRenderer sr_npc;

	public bool isBeingBuild;


	void Start () 
	{
//		thisCo = gameObject.GetComponent<BoxCollider2D> ();
//		thisParentCo = transform.parent.transform.parent.GetComponent<CircleCollider2D> ();
//		Physics2D.IgnoreCollision (thisCo, thisParentCo, true);

		sr_npc = gameObject.GetComponent<SpriteRenderer> ();

		isBeingBuild = true;
	}
	
	// Update is called once per frame
	void Update () 
	{

//		RaycastHit2D[] hits; 
//		Vector2 v2_this = new Vector2 (gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
//		//print (v2_this);
//		hits = Physics2D.CircleCastAll (v2_this, 0.1f, Vector2.zero);
//		for (int i = 0; i < hits.Length; i++) 
//		{ 
//			print (i +": " + hits[i].collider.gameObject.name);
//			if (hits [i].collider.gameObject.tag == "npc") 
//			{
//				print ("npc and npc meet.");
//			}
//		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		print (other.name+ " collides with NPC.");
		if (other.tag == "npc") 
		{
//			print (other.name + "npc and npc meet.");

			GameObject.Find ("TimeManager").SendMessage ("npcMeetnpc");
			//sr_npc.color = Color.white;

			GameObject.Find ("Canvas").SendMessage ("twonpcmeet");

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//		print (other.name+ " collides with NPC.");
		if (other.tag == "npc") 
		{
//			print ("other .tag == npc");
//			if (other.name == "npc2") 
//			{
//				//Color color1 = new Color (72f,159f,163f);
//				sr_npc.color = new Color (72f,159f,163f);
//
//				print ("other .name == npc2");
//			}
//
//			if (other.name == "npc") 
//			{
//				//Color color1 = new Color (72f,159f,163f);
//				sr_npc.color = Color.cyan;
//				print ("other .name == npc");
//			}
		}
	}
}
