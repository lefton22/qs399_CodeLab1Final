using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGear0 : MonoBehaviour {

	GameObject gear_collide;
	public List<GameObject> gear_collides;

	public int whichSlave;

    float speed; // this gear's current speed, no matter if this gear has a slave
    public float powerSlave1;
	GameObject lw2;

	GameObject FirstCollidedWheel;

	int isSameDir;
	public bool doHaveSlave;

	string lnewWheelName;
	GameObject lwhatwouldhappen;

	float speeded; // the speed that has an effect to this wheel (no matter 1 or 2,3,4.. wheels have effect on this wheel)



	void Start () 
	{
		//// declaim its scale

		/// need to detect which slave in this gear
		whichSlave = 0;
		powerSlave1 = 0f;
		lw2 = GameObject.Find ("w2");
		isSameDir = 1;

		FirstCollidedWheel = null;
		doHaveSlave = false;

		lwhatwouldhappen = GameObject.Find ("whatwouldhappen");

		//print ("this gameobject's name: " + gameObject.name);
	}
	

	void Update () 
	{

		for (int i = 0; i < gear_collides.Count; i++) 
		{
			if (gameObject == lw2) 
			{
				//Debug.Log (gameObject + ": is colliding with: " + i + ": " + gear_collides [i]);
			}
		}

		string name =  lwhatwouldhappen.GetComponent<newhappen> ().newWheelName;

		if (gameObject.name == name) //if in "newhappen", the gameobject is this object，then change parameters.
		{
			//print (gameObject + " is.");

		}

		//speed = Time.deltaTime * powerSlave1;


		////一下这一部分负责控制轮子里的SLAVE是谁，以及SLAVE的速度。
		////if there is a "slave" in this gear, it rotate. two slaves in one gear is forbidden.
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
//		if (whichSlave == 1) // "1" means have a slave
//		{
//			//// need to get the no.1 slave's power
//			powerSlave1 = 30f;
//
////			transform.Rotate (0, 0, Time.deltaTime * powerSlave1);
//			//speed = Time.deltaTime * powerSlave1;
//		}

		//// if there is no slave, the speed of this gear effected by the gear or gears 
		/// (they must have the same line speed) collide with this and update,
		//// if those gears don't have the same line speed, you can't build a gear there. 
//		if (whichSlave == 0) 
//		{
//			// 加一个碰撞组是否包含下面那个i编号的轮子
//
//			if (gear_collides.Count == 0) 
//			{
//				powerSlave1 = 0f;
//
//				//print (gameObject + "0");
//			}
//			if (gear_collides.Count > 0 ) 
//			{
////				int times = 0;
////				times++;
////				if (times < 1)
////				{
////					FirstCollidedWheel = gear_collides [0];
////				}
//
//
//				for (int i = 0; i < gear_collides.Count; i++) 
//				{
//					int lwhihchslave;
//					lwhihchslave = gear_collides[i].GetComponent<SingleGear0> ().whichSlave;
//
//					if (lwhihchslave == 1)
//					{
//						doHaveSlave = true;
////					} else {
////						powerSlave1 = - gear_collides [0].GetComponent<SingleGear0> ().powerSlave1;// follow the first?
//					}
//					if (doHaveSlave) {
//						powerSlave1 = -gear_collides [i].GetComponent<SingleGear0> ().powerSlave1;
//					} else 
//					{
//						powerSlave1 = 0f;
//					}
//				}
//
//
//
////					for (int i = 0; i <= gear_collides.Count; i++) 
////					{
//						//powerSlave1 = -gear_collides [0].GetComponent<SingleGear0> ().powerSlave1;// follow the first?
//						
//
////						print (gameObject + "get slavepower successfully: " + gear_collides [0]);
////					}
//
//			}
//		}

		transform.Rotate (0, 0, Time.deltaTime * powerSlave1); // 现在假设在这个轮子里的是slave1
			//print ("no slave in " + gameObject);



			//判断与之碰撞轮子LIST里的所有轮子是不是同一转向
//		if (gear_collides.Count > 1) 
//		{
//			for (int i = 0; i < gear_collides.Count; i++) 
//			{
//				
//				float eachSpeed;
//				eachSpeed = gear_collides [i].GetComponent<SingleGear0> ().powerSlave1;
//
//				float eachSpeed_0 = gear_collides [0].GetComponent<SingleGear0> ().powerSlave1;
//
//				if (eachSpeed_0 > 0) 
//				{ //若转向为正
//					print ("BIBI1-1");
//
//					Debug.Log (gameObject + "'s eachspeed " + i + ": " + eachSpeed);
//
//					if (eachSpeed_0 > 0) 
//					{
////						isSameDir = 1;				  
//					}
//					while (eachSpeed_0 < 0) 
//					{
//						isSameDir = 2;
//						print ("BIBI1-2");
//						break;
//					}
//				}
//
//
//				if (eachSpeed_0 < 0) 
//				{ //若转向为负
//					print ("BIBI2-1");
//
//
//					Debug.Log (gameObject + "'s eachspeed " + i + ": " + eachSpeed);
//
//					if (eachSpeed_0 < 0)
//					{
////						isSameDir = 1;			   
//					}
//					while (eachSpeed_0 > 0) 
//					{
//						isSameDir = 2;
//						print ("BIBI2-2");
//						break;
//					}
//				}
//
//				if (isSameDir == 1) 
//				{ // it means that they have same dirrections
//					//print (gameObject + ": same direction" + "value: " + isSameDir);
//				}
//				if (isSameDir == 2) 
//				{ // it means that they have different dirrections
//					//print (gameObject + ": different direction" + "value: " + isSameDir);
//				}
//			}
//		}





//			if 
//			transform.Rotate (0, 0, Time.deltaTime * powerSlave1);



			

		//// and when it stop? 
	}

	//// get the gears collide with this gear
	 	void OnTriggerEnter2D(Collider2D other)
	{
		//print (gameObject + " collide with " + other);



		if (other.tag == "wheel") 
		{
			gear_collide = other.gameObject;

			if (gear_collides.Contains (gear_collide)) 
			{
			} 
			else 
			{
				gear_collides.Add (gear_collide);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		

		if (other.tag == "wheel") 
		{
			GameObject gear_exit = other.gameObject;

			if (gear_collides.Contains (gear_exit)) 
			{
				gear_collides.Remove (gear_exit);
			}

		}
	}


}
