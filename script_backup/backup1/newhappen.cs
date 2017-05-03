using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newhappen : MonoBehaviour {

	GameObject  lwheel_n;
	int lwhichSlave;

    List<GameObject> lgear_collides;

	public float powerSlave;

	bool ldoHaveSlave;

	public string newWheelName;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//print ("lwheel_n: " + lwheel_n);

	}

	void buildHappen()
	{
		//print ("buildHappen");
		lwheel_n =  GameObject.Find ("placewheels").GetComponent<placewheels> ().wheel_n;

		lwhichSlave = lwheel_n.GetComponent<SingleGear0> ().whichSlave;
		//print ("which slave: " + lslave);
		lgear_collides = lwheel_n.GetComponent<SingleGear0> ().gear_collides;
		ldoHaveSlave = lwheel_n.GetComponent<SingleGear0> ().doHaveSlave;

		newWheelName = lwheel_n.name;

		//print ("lslave: " + lwhichSlave);
		//print ("newWeelName: " + newWeelName);
		print(lwheel_n +"'s slave:"+ lwhichSlave);

		if (lwhichSlave == 1) // "1" means have a slave
		{
			print("there is 1 slave");

			if (lgear_collides.Count == 0) 
			{
				powerSlave = 30f;
			}
			if (lgear_collides.Count > 0 ) // have collision
			{
				////to juge if the dir is oppposite, then ..., if it's not opposite, then...
			}
				
		}

		if (lwhichSlave == 0) 
		{
			// 加一个碰撞组是否包含下面那个i编号的轮子
			print("no slave there");
			if (lgear_collides.Count == 0) //no coliision, no slave
			{
				powerSlave = 0f;
				//print (gameObject + "0");

				for (int i = 0; i < lgear_collides.Count; i++) 
				{

						Debug.Log ("lonely wheels, but its list is" + i + ": " + lgear_collides [i]);
				}
			}

			if (lgear_collides.Count > 0 ) // have collision
			{
				print ("no slave beside and colliders >0");

//				for (int i = 0; i < lgear_collides.Count; i++) 
//				{
//					int lwhihchslave;
//					lwhihchslave = lgear_collides[i].GetComponent<SingleGear0> ().whichSlave;
//
//					if (lwhihchslave == 1)
//					{
//						ldoHaveSlave = true;
//
//					}
//
//					if (ldoHaveSlave) {
//						powerSlave = - lgear_collides [i].GetComponent<SingleGear0> ().powerSlave1;
//					} else 
//					{
//						powerSlave = 0f;
//					}
//				}
			}
		}

	}

	void moveHappen()
	{
		
	}

	void deleteHappen()
	{
		
	}
}
