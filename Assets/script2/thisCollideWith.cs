using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisCollideWith : MonoBehaviour {

	public List<GameObject> gear_collidewithThis;

	List<GameObject> lhead_withSlave;

	bool lisRotate;

	public bool isNpcExit;


	void Start () 
	{
		gear_collidewithThis = new List<GameObject> ();

		//Physics2D.IgnoreLayerCollision (8, 9, true);

		isNpcExit = false;

	}
	

	void Update () 
	{
		lisRotate = gameObject.GetComponent<SingleGear0>().isRotate;

		if (gear_collidewithThis.Count > 3) 
		{
			print ("kill it");

			Destroy (gear_collidewithThis[3]);
			gear_collidewithThis.Remove (gear_collidewithThis[3]);
			//bug: 如果还与其他轮子相碰，但在其他轮子那里不是第4个，该怎么精确从列表里删除？

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			if (gear_collidewithThis.Contains (other.gameObject)) 
			{
			} 
			else 
			{					
				gear_collidewithThis.Add (other.gameObject);
			}				
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
//		Physics2D.IgnoreLayerCollision (8, 9, true);

		if (other.tag == "npc") 
		{
			print ("a gear exit collission with a npc.");
			isNpcExit = false;
		}

		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			//print ("remove 1");
				
			if (isNpcExit) 
			{
				gear_collidewithThis.Remove (other.gameObject);
				//headLoop.head_withSlave.Remove (other.gameObject);
				isNpcExit = false;
			}

			lhead_withSlave = new List<GameObject> (GameObject.Find("eachGear_Manager").GetComponent<headLoop>().head_withSlave);
			lhead_withSlave.Remove (other.gameObject);
			GameObject.Find ("eachGear_Manager").GetComponent<headLoop> ().head_withSlave = lhead_withSlave;
		//	print (gameObject + "remove 2");

		
			if (gear_collidewithThis.Count == 0) 
			{
				gameObject.SendMessage ("speedZero");
			}


			if (gear_collidewithThis.Count == 1) 
			{
				//gear_collidewithThis.Remove
				other.GetComponent<SingleGear0>().inWhichBranch =0;
			}


			//gameObject.SendMessage ("exitCollide");
		}

//		if (other.tag == "npc") 
//		{
//			print ("a gear exit collission with a npc.");
//			isNpcExit = true;
//		}
	}
}
