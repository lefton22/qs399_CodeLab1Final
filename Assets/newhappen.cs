using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newhappen : MonoBehaviour { //每生成一个轮子时告诉轮子各种参数的逻辑脚本， 只在有“新动作（build, remove, move）”时更新

	GameObject  lwheel_n;
	int lwhichSlave;

    List<GameObject> lgear_collides;

	public float powerSlave;

	bool ldoHaveSlave;

	public string newWheelName;

	void Awake () 
	{
		lgear_collides = new List<GameObject>() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//print ("lwheel_n: " + lwheel_n);

		//lgear_collides = lwheel_n.GetComponent<eachGear> ().power_source_gears;

	}

	void buildHappen()
	{
		//print ("buildHappen");
		lwheel_n =  GameObject.Find ("placewheels").GetComponent<placewheels> ().wheel_n;

		lwhichSlave = lwheel_n.GetComponent<eachGear> ().whichSlave;
		//print ("which slave: " + lslave);
//		lgear_collides = lwheel_n.GetComponent<SingleGear0> ().gear_collides;//?
		//ldoHaveSlave = lwheel_n.GetComponent<eachGear> ().doHaveSlave;

		newWheelName = lwheel_n.name;

		//print ("lslave: " + lwhichSlave);
		//print ("newWeelName: " + newWeelName);
		//print(lwheel_n +"'s slave:"+ lwhichSlave);
		//print (lwheel_n +"'s lgear_collides.Count: " +lgear_collides.Count);

		for (int i = 0; i < lgear_collides.Count; i++) 
		{
			//Debug.Log (lwheel_n + " how many neighbors: "  + i + " : " + lgear_collides [i]);
		}



		if (lwhichSlave == 1) // this wheel has a slave who is no.1 slave
		{
			print("there is 1 slave");

			if (lgear_collides.Count == 0) 
			{
				powerSlave = 30f;
			}
			if (lgear_collides.Count > 0 ) // have collision
			{
				for (int i = 0; i < lgear_collides.Count; i++) 
				{
//					if (lgear_collides[i]. )
//					{
//						
//				////to juge if the dir is oppposite, then ..., if it's not opposite, then...
//			    	}
				}
			}
				
		}

		if (lwhichSlave == 0) //this wheel has no slave
		{
			// 加一个碰撞组是否包含下面那个i编号的轮子
			//print("no slave there");

			if (lgear_collides.Count == 0) //no coliision, no slave
			{
				powerSlave = 0f;
				//print (gameObject + "0");

				//print ("no slave beside and colliders = 0");
		
			}

			if (lgear_collides.Count > 0 ) // have collision
			{
				
				//print ("no slave beside and colliders > 0");


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
