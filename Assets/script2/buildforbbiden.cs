using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildforbbiden : MonoBehaviour {

	public List<GameObject> gearsIgnored;

	GameObject lcue;

	void Start () 
	{
		if (gameObject.name == "w_buildCue") 
		{
			lcue = GameObject.Find ("cue");
		}
		if (gameObject.name == "w2_buildCue") 
		{
			lcue = GameObject.Find ("cue2");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
//	    gearsIgnored = new List<GameObject>();
//
//		gearsIgnored.AddRange(GameObject.FindGameObjectsWithTag("wheel"));
//		gearsIgnored.AddRange(GameObject.FindGameObjectsWithTag("hasSlave"));
//
//		for (int i = 0; i < gearsIgnored.Count; i++) 
//		{
//			CircleCollider2D gearCircle2d = gearsIgnored [i].GetComponent<CircleCollider2D> ();
//			CircleCollider2D thisCircle2d = gameObject.GetComponent<CircleCollider2D> ();
//			Physics2D.IgnoreCollision (gearCircle2d, thisCircle2d);
//
//		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print ( gameObject + " triggers " + other.name);
		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			print ("collides with other insideCollision");
			eachGearManager.canIbuild = false;
			print ("eachGearManager.canIbuild = false;");

			lcue.SendMessage ("showUp");

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			eachGearManager.canIbuild = true;
			print ("eachGearManager.canIbuild = true;");

			lcue.SendMessage ("dissapear");

		}
	}
}
