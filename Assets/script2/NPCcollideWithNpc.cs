using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcollideWithNpc : MonoBehaviour {

	Collider2D thisCo;
	Collider2D thisParentCo;

	void Start () 
	{
		thisCo = gameObject.GetComponent<BoxCollider2D> ();
		thisParentCo = transform.parent.GetComponent<CircleCollider2D> ();
		Physics2D.IgnoreCollision (thisCo, thisParentCo, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//print ("collides with NPC.");
		if (other.tag == "npc") 
		{
			print ("npc meet.");
		}
	}
}
