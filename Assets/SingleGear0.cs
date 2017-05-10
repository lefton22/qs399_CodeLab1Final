using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGear0 : MonoBehaviour {


	public int whichSlave;

    public float speed; // this gear's current speed, no matter if this gear has a slave
    public float powerSlave1;
	GameObject lw2;


	//float speeded; // the speed that has an effect to this wheel (no matter 1 or 2,3,4.. wheels have effect on this wheel)

	public int inWhichBranch;

	public bool isColiided;
	List<GameObject> lgear_collidewithThis ;
	public bool isRotate;

	float thisRadius;
	float ratio;

	public int posi_nega;



	void Start () 
	{

		//whichSlave = 1; //in inspector now
		powerSlave1 = 0f;
		lw2 = GameObject.Find ("w2");

		isColiided = false;

		isRotate = false;

//		if (whichSlave == 1) 
//		{
//			gameObject.tag = "has_slave";
//		}

		thisRadius = gameObject.GetComponent<CircleCollider2D> ().radius;

	    
		posi_nega = 0;
	}
	

	void Update () 
	{


		if (whichSlave == 1) 
		{
			gameObject.tag = "hasSlave";
		}
		if (whichSlave == 0) 
		{
			gameObject.tag = "wheel";
		}

		//transform.Rotate (0, 0, Time.deltaTime * powerSlave1); // 现在假设在这个轮子里的是slave1
			//print ("no slave in " + gameObject);
		if (whichSlave == 1) 
		{
			speed = 20f;
			posi_nega = 1;
			//transform.Rotate (0, 0, Time.deltaTime * speed); // supposed that all the speed is 20f now
		}

		if (whichSlave == 0)
		{

			List<GameObject> lhead_withSlave = new List<GameObject> (GameObject.Find("eachGear_Manager").GetComponent<headLoop>().head_withSlave);
//			int index =lgear_collidewithThis.IndexOf (gameObject);
			if (!lhead_withSlave.Contains (gameObject)) 
			{
				isRotate = false;
			} 
						if (lhead_withSlave.Contains (gameObject)) 
			{
				isRotate = true;
				//print ("isRoate true");
			}

			if (isRotate) 
			{
				lgear_collidewithThis = new List<GameObject> (gameObject.GetComponent<thisCollideWith>().gear_collidewithThis);



				if (lgear_collidewithThis.Count == 0) 
				{
					speed = 0f;
//					transform.Rotate (0, 0, Time.deltaTime * speed); 
					//print (gameObject + ": collide with 0 gears at the same time");
				}
				if (lgear_collidewithThis.Count == 1) 
				{
					ratio = lgear_collidewithThis [0].GetComponent<SingleGear0> ().thisRadius / thisRadius;

					speed = - lgear_collidewithThis [0].GetComponent<SingleGear0> ().speed * ratio;
					//print (gameObject + ": collide with 1 gears at the same time");
				}//
				if (lgear_collidewithThis.Count == 2) 
				{
					float speed1 = lgear_collidewithThis [0].GetComponent<SingleGear0> ().speed;
					float speed2 = lgear_collidewithThis [1].GetComponent<SingleGear0> ().speed;

					bool bothgreaterthanZero = false;
					bool bothsmallerthanZero = false;

					if (speed1 > 0 && speed2 > 0) 
					{
						bothgreaterthanZero = true;
					}
					if (speed1 < 0 && speed2 < 0) 
					{
						bothsmallerthanZero = true;
					}
					if (bothgreaterthanZero || bothsmallerthanZero) 
					{
						ratio = lgear_collidewithThis [0].GetComponent<SingleGear0> ().thisRadius / thisRadius;

						speed = -lgear_collidewithThis [0].GetComponent<SingleGear0> ().speed * ratio;
						//print (gameObject + ": collide with 2 gears at the same time");
					}

					//if stick here, give some visual effect
				}
				if (lgear_collidewithThis.Count == 3) 
				{
						int index_a = lhead_withSlave .IndexOf(lgear_collidewithThis[0]);
						int index_b = lhead_withSlave .IndexOf(lgear_collidewithThis[1]);
						int index_c = lhead_withSlave .IndexOf(lgear_collidewithThis[2]);

					int minint = Mathf.Min (index_a, index_b, index_c);


					ratio = lgear_collidewithThis [0].GetComponent<SingleGear0> ().thisRadius / thisRadius;

					speed = - lhead_withSlave [minint].GetComponent<SingleGear0> ().speed * ratio;
					//print (gameObject + ": collide with 3 gears at the same time, and min: " + minint);
				}


			}

			if (!isRotate) 
			{
				speed = 0;
			}

		}
		transform.Rotate (0, 0, Time.deltaTime * speed); 



		// deliver the posi or negative speed information

//		if (speed > 0) 
//		{
//			Time_Manager.gearsPosi = Time_Manager.gearsPosi + 1;
//		}
	}


	void rotateLa()
	{
		isRotate = true;;
	}

	void ouiCollide ()
	{
		//isColiided = true;
	}

	void exitCollide () //clearAllStatement
	{
//		if (gameObject.GetComponent<thisCollideWith> ().isNpcExit) 
//		{
		//print("exitCollide");
			isRotate = false;

			gameObject.GetComponent<thisCollideWith> ().isNpcExit = false;

			lgear_collidewithThis = new List<GameObject> (gameObject.GetComponent<thisCollideWith> ().gear_collidewithThis);
			if (lgear_collidewithThis.Count == 0) 
	    	{
				//isColiided = false;

				//lgear_collidewithThis.RemoveAll ();
				inWhichBranch = 0;
				//print ("quite collision and zero. clearAllStatement");
			}
//		}


//		if (lgear_collidewithThis.Count == 1) 
//		{
//			//isColiided = false;
//
//			//lgear_collidewithThis.RemoveAll ();
//
//			print ("quite collision and one. ");
//		}
	}

//	void clearAllStatement()
//	{
//		print ("clearAllStatement");
//	}

	void speedZero()
	{
		speed = 0f;
		//					transform.Rotate (0, 0, Time.deltaTime * speed); 
		//print (gameObject + ": collide with 0 gears at the same time");

	}

}
