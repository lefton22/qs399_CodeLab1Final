using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisCollideWith : MonoBehaviour {

	public List<GameObject> gear_collidewithThis;

	List<GameObject> lhead_withSlave;

	bool lisRotate;

	public bool isNpcExit;

	float radius;

	GameObject ooo;


	void Start () 
	{
		gear_collidewithThis = new List<GameObject> ();

		Physics2D.IgnoreLayerCollision (8, 9, true);

		isNpcExit = false;

		radius = gameObject.GetComponent<CircleCollider2D> ().radius;

		//print (gameObject.transform.GetChild(0));

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
			
	////detect any npc into this gear, and to be their parent
		RaycastHit2D[] hits; 
		Vector2 v2_this = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		hits = Physics2D.CircleCastAll (v2_this, radius/2, Vector2.zero);
		for (int i = 0; i < hits.Length; i++) 
		{

			//print (gameObject.name + "    i: " + i + " " + hits[i].collider.name + " (radius: " + radius/2 +" )  ," + hits [i].collider.transform.parent);
			if (hits [i].collider.tag == "npc") 
			{
				//print (hits [i].collider.transform.parent);
//				//print ("if tag = npc," + hits [i].collider.transform.parent);

//				print (hits [i].collider.name + " has no parent");
//				hits [i].collider.transform.SetParent (gameObject.transform.GetChild (0));	
//				hits [i].collider.transform.localPosition = new Vector3 (radius/2f, 0,0);

//				ooo = hits [i].collider.gameObject;
//				setTrans ();

				if (hits [i].collider.transform.parent == gameObject.transform.GetChild(0)) 
				{ 
//					print ("do nothing");
				}

				if (hits [i].collider.gameObject.transform.parent == null ) 
				{
					GameObject rotateSelf_1 = Instantiate (Resources.Load ("rotateSelf"), gameObject.transform.position, Quaternion.identity) as GameObject;
					print ("has no parent.");
					ooo = hits [i].collider.gameObject;
					setTrans ();

					rotateSelf_1.name = "rotateSelf";
					hits [i].collider.transform.SetParent (rotateSelf_1.transform );
					rotateSelf_1.transform.SetParent (gameObject.transform);

					if (hits [i].collider.gameObject.name == "npc") 
					{
						//consume time
						GameObject.Find ("TimeManager").SendMessage ("addNPC");
					}
					if (hits [i].collider.gameObject.name == "npc2") 
					{
						//consume time
						GameObject.Find ("TimeManager").SendMessage ("addNPC2");
					}
				}

				if (hits [i].collider.transform.parent != gameObject.transform.GetChild(0) && hits [i].collider.gameObject.transform.parent != null)
				{
//					print ("npc collides with others' gear");

					//hits [i].collider.transform.SetParent(null);
					//hits [i].collider.transform.SetParent (gameObject.transform.GetChild(0).transform);


					GameObject forever_parent = hits [i].collider.transform.parent.gameObject;
//					print ("forever_parent : " + forever_parent.name);

					hits [i].collider.transform.parent.transform.SetParent (gameObject.transform);
					hits [i].collider.transform.SetParent (forever_parent.transform);
					hits [i].collider.transform.parent.transform.position = gameObject.transform.position;

				//print ("be parent.");
				}


			}
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

//		if (other.tag == "npc") 
//		{
//			//print ("a gear exit collission with a npc.");
//			isNpcExit = false;
//		}

		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			//print ("remove 1");
				
//			if (isNpcExit) 
//			{
				gear_collidewithThis.Remove (other.gameObject);
				//headLoop.head_withSlave.Remove (other.gameObject);
				isNpcExit = false;
				//print ("npc exit");
//			}

			lhead_withSlave = new List<GameObject> (GameObject.Find("eachGear_Manager").GetComponent<headLoop>().head_withSlave);
			lhead_withSlave.Remove (other.gameObject);
			GameObject.Find ("eachGear_Manager").GetComponent<headLoop> ().head_withSlave = lhead_withSlave;
			print (gameObject.name + "remove 2");

		
			if (gear_collidewithThis.Count == 0) 
			{
				gameObject.SendMessage ("speedZero");
			}


			if (gear_collidewithThis.Count == 1) 
			{
				//gear_collidewithThis.Remove
				other.GetComponent<SingleGear0>().inWhichBranch =0;
			}


			gameObject.SendMessage ("exitCollide");
		}
	
//		if (other.tag == "npc") 
//		{
//			print ("a gear exit collission with a npc.");
//			isNpcExit = true;
//		}
	}

	void setTrans()
	{

		if (ooo.transform.parent == gameObject.transform.GetChild (0)) 
		{
		}
		if (ooo.transform.parent != gameObject.transform.GetChild (0)) 
		{
			//print (ooo.name + " has no parent");
			ooo.transform.SetParent (gameObject.transform.GetChild (0));	
			ooo.transform.localPosition = new Vector3 (radius / 2f, 0, 0);
		}
	}


}
