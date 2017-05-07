using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedLoop : MonoBehaviour {
	//if there is n slave gears, then generate the GameObject contained this script for n times.
	//and let this sccript know the slave loop it has to trace.

	public List<GameObject> head_speed_dir;// the direction of rotation

	public List<GameObject> objWithSlave;
	public int slave;

	List<GameObject> lhead_withSlave;

	int lposi_nega;

	void Start () 
	{
		head_speed_dir = new List<GameObject>();

		//get the coresponding head_withSlave List!!!
		//lhaed_withSlave =


	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//need a clear function?

		objWithSlave = new List<GameObject>();

		objWithSlave.AddRange( GameObject.FindGameObjectsWithTag ("hasSlave"));
		//print ("objWithSlave [0].name: " + objWithSlave [0].name);
		if (objWithSlave.Count == 1) 
		{
			slave = objWithSlave [0].GetComponent<SingleGear0> ().whichSlave;
			if (!lhead_withSlave.Contains (objWithSlave [0])) 
			{
				lhead_withSlave.Add (objWithSlave [0]);
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
			for (int i = 0; i < head_speed_dir.Count; i++) 
			{
				lposi_nega = lhead_withSlave [i].GetComponent<SingleGear0> ().posi_nega;

				//j 为collide with's amounts
				for (int j = 0; j < lhead_withSlave[i].GetComponent<thisCollideWith>().gear_collidewithThis.Count; j++)
				{
					lhead_withSlave [i].GetComponent<thisCollideWith> ().gear_collidewithThis [j].GetComponent<SingleGear0> ().posi_nega = -lposi_nega; 
			    }
			}

		}

	}
}
