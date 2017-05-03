using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inherit : MonoBehaviour { // this script is for how to inherit the speed from the "last wheel"

	public float speed_inherit;  // 继承的上一个“该”继承的速度,速度只归这里管, 因为这个需要实时更新


	GameObject collider;
	public List<GameObject> colliders;

	GameObject lwheel_n;
	int lwhichSlave;

	//bool isSameDir;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		lwheel_n = GameObject.Find ("placewheels").GetComponent<placewheels>().wheel_n;
		lwhichSlave = lwheel_n .GetComponent<eachGear>().whichSlave;// which slave?

//// collider =0
		if (colliders.Count == 0 && lwhichSlave == 0) 
		{
			speed_inherit = 0f; 
			print (gameObject + " 0 colliders, 0 slaves");
		}

		if (colliders.Count == 0 && lwhichSlave == 1) 
		{
			speed_inherit = 30f; 
			print (gameObject +" 0 colliders, 1 slaves");
		}

////coliider =1
		if (colliders.Count == 1 && lwhichSlave == 0) //如果和其他轮子有碰撞，则继承
		{
			//speed_inherit = colliders[0].GetComponent<newhappen> ().powerSlave; 

			print (gameObject + " colliders = 1, slave 0 ");
		
			if (lwhichSlave == 0) 
			{
				speed_inherit = 0f;
			}

			if (lwhichSlave == 1)
			{
				speed_inherit = -30f;
			}
		}
		if (colliders.Count == 1 && lwhichSlave == 1) //如果和其他轮子有碰撞，则继承
		{
			//speed_inherit = colliders[0].GetComponent<newhappen> ().powerSlave; 

			print (gameObject + " colliders = 1, slave 1");

			speed_inherit = 0f;

		}

//// collider >1
		if (colliders.Count > 1) //如果和其他轮子有碰撞，则继承
		{
			//speed_inherit = colliders[0].GetComponent<newhappen> ().powerSlave; 

			isSameDir ();

			print (gameObject +" colliders > 1");

			if (!isSameDir()) // diff dir, 
			{
				speed_inherit = 0f; // id it need to fall?
				print (gameObject +" colliders > 1, colliders' dirs are diff");
			}

			if (isSameDir()) // same dir
			{
				speed_inherit = 30f;
				print (gameObject +"c olliders > 1, colliders' dirs are same");
			}

		}

		transform.Rotate (0, 0, Time.deltaTime * speed_inherit); 
	}


	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "wheel") 
		{
			collider = other.gameObject;

			if (colliders.Contains (collider)) 
			{
			} 
			else 
			{
				colliders.Add (collider);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{


		if (other.tag == "wheel") 
		{
			GameObject gear_exit = other.gameObject;

			if (colliders.Contains (gear_exit)) 
			{
				colliders.Remove (gear_exit);
			}

		}
	}

	bool isSameDir()
	{

		for (int i = 0; i < colliders.Count; i++) 
		{
			float neighborsSlavePower = colliders[i].GetComponent<eachGear> ().whichSlave; 
			if (neighborsSlavePower != 30f) { //30 maybe changed, it should be the current "should speed".
				return false;
			}
		}
		return true;
	}
}
