using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headLoop : MonoBehaviour {

	//public int slave;
	public  List<GameObject> head_withSlave;

	GameObject lw2;
	public List<GameObject> lgear_collidewithThis ;
	int maxBranch;

	//public List<GameObject> displayHeadList ;

	public List<GameObject> objWithSlave;
	public int slave;

	void Start () 
	{
		//slave = 1;
		head_withSlave = new List<GameObject> ();

		//suppose that there is a wheel with a slave exsiting at the begining of the game
//		lw2 = GameObject.Find("w2");
//		head_withSlave.Add (lw2);
		//print ("when strating game: head_withSlave:" + head_withSlave[0].name);
	}
	

	void Update () 
	{
		if (head_withSlave.Count > 0) 
		{
			head_withSlave.Clear() ;
		}
		//displayHeadList = new List<GameObject>(head_withSlave); // for showing in inspector

		//find slave and make it be the first elment of that heaad list
		//if there is more two slaves in the scene, copy a new manager GameObject from this GameObject.
		objWithSlave = new List<GameObject>();

		objWithSlave.AddRange( GameObject.FindGameObjectsWithTag ("hasSlave"));
		//print ("objWithSlave [0].name: " + objWithSlave [0].name);
		if (objWithSlave.Count == 1) 
		{
			slave = objWithSlave [0].GetComponent<SingleGear0> ().whichSlave;
			if (!head_withSlave.Contains (objWithSlave [0])) 
			{
				head_withSlave.Add (objWithSlave [0]);
				//print ("Tag 'hasSlave'.");
			}
		}
		if (objWithSlave.Count == 2) 
		{
			slave = objWithSlave [0].GetComponent<SingleGear0> ().whichSlave;

			//need to copy this GameObject!!
		}

		if (slave == 1) 
		{
			for (int j = 0; j < head_withSlave.Count; j++) 
			{
				if (head_withSlave.Count == 1) {
					maxBranch = 1;
					head_withSlave [0].GetComponent<SingleGear0> ().inWhichBranch = 1;
				}


				lgear_collidewithThis = new List<GameObject> (head_withSlave [j].GetComponent<thisCollideWith> ().gear_collidewithThis);

				//put each of the 3 gears into the head list

//			if (head_withSlave [j].GetComponent<thisCollideWith> ().gear_collidewithThis.Count == 0) 
//			{
//				print (gameObject.name + " : collides.count = 0.");
//			}



				if (head_withSlave [j].GetComponent<thisCollideWith> ().gear_collidewithThis.Count == 1) {
					if (head_withSlave.Contains (lgear_collidewithThis [0])) {
					} else {
						//add to the head list
						head_withSlave.Add (lgear_collidewithThis [0]); 

						//assign a branch number
						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;
						lgear_collidewithThis [0].GetComponent<SingleGear0> ().inWhichBranch = caBranch;

						lgear_collidewithThis [0].SendMessage ("rotateLa");

					} 
//				if (!head_withSlave.Contains (lgear_collidewithThis [0]))// how to delete those statements when gears exiting? 
//				{
//					print("not contain");
//				}
				}

				if (head_withSlave [j].GetComponent<thisCollideWith> ().gear_collidewithThis.Count == 2) {
					if (head_withSlave.Contains (lgear_collidewithThis [0])) {
					} else {		
						head_withSlave.Add (lgear_collidewithThis [0]);

						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;
						lgear_collidewithThis [0].GetComponent<SingleGear0> ().inWhichBranch = caBranch;

						lgear_collidewithThis [0].SendMessage ("rotateLa");
					}
					if (head_withSlave.Contains (lgear_collidewithThis [1])) {
					} else {
						head_withSlave.Add (lgear_collidewithThis [1]);

						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;
						lgear_collidewithThis [1].GetComponent<SingleGear0> ().inWhichBranch = caBranch;

						lgear_collidewithThis [1].SendMessage ("rotateLa");

					}
				}

				if (head_withSlave [j].GetComponent<thisCollideWith> ().gear_collidewithThis.Count == 3) {
					if (head_withSlave.Contains (lgear_collidewithThis [0])) {
					} else {					
						head_withSlave.Add (lgear_collidewithThis [0]);

						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;
						lgear_collidewithThis [0].GetComponent<SingleGear0> ().inWhichBranch = caBranch;

						lgear_collidewithThis [0].SendMessage ("rotateLa");
					}
					if (head_withSlave.Contains (lgear_collidewithThis [1])) {
					} else {
						head_withSlave.Add (lgear_collidewithThis [1]);

						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;
						lgear_collidewithThis [1].GetComponent<SingleGear0> ().inWhichBranch = caBranch;

						lgear_collidewithThis [1].SendMessage ("rotateLa");

					}
					if (head_withSlave.Contains (lgear_collidewithThis [2])) {
					} else {
						head_withSlave.Add (lgear_collidewithThis [2]);

						int caBranch = head_withSlave [j].GetComponent<SingleGear0> ().inWhichBranch;

						maxBranch = maxBranch + 1;
						lgear_collidewithThis [2].GetComponent<SingleGear0> ().inWhichBranch = maxBranch;

						lgear_collidewithThis [2].SendMessage ("rotateLa");

					}
				}


//				for (int i = 0; i < head_withSlave.Count; i++) 
//				{
//					print ("head_withSlave.Count: " +i +", head_withSlave[i]: " + head_withSlave[i].name);
//				}
				//print ("j: " + j  + thisO [0].name +", head_withSlave.Count:  " +head_withSlave.Count);
				//




			}
		}
	}



}
