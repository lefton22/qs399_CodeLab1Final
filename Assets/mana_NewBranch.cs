using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana_NewBranch : MonoBehaviour {

	public List<GameObject> lrotateGearsOnChain;
    List<GameObject> lrotateGearsOnChain2; // a specific list for search the "correct" wheel


	public int thisListBranch;

	public List<GameObject> branchSlave ;

	void Start () 
	{
		//get inWhichList 

		//copy the old head List
	}
	

	void Update () 
	{


////if the "inWHichBranch" = n, then add to this list and setparent
		//if

//		lrotateGearsOnChain2 =  new List<GameObject> 
//			(GameObject.Find ("CreateSlavePath").GetComponent< createWayPoint> ().rotateGearsOnChain);
//
//		int real_max =eachGearManager.max_inWhichBranch +1;  // 当前的最大branch级别
//
//		for (int i = 0; i < lrotateGearsOnChain2.Count; i++) 
//		{
//			for (int j = 0; j < real_max; j++) 
//			{
//				//print ("i:" + i + "   j:" + j);
//
//				int branch = lrotateGearsOnChain2 [i].GetComponent<eachGear>().inWhichBranch;
//				if (branch == j && thisListBranch == j) 
//				{
//					
//					if (branchSlave.Contains (lrotateGearsOnChain2 [i]))
//					{
//					} 
//					else 
//					{
//						branchSlave.Add (lrotateGearsOnChain2 [i]);
//						//print ("add " + lrotateGearsOnChain2 [i] + " into " + gameObject);
//					}
//				}
//			}
//		}


	}

	void addNewSlaveList()
	{
		//get the old 
//		lrotateGearsOnChain =  new List<GameObject> 
//			(GameObject.Find ("CreateSlavePath").GetComponent< createWayPoint> ().rotateGearsOnChain);
		//remove the gears !!!!


			for (int i = 0; i < lrotateGearsOnChain.Count; i++) 
			{
			
				int index1 = lrotateGearsOnChain.IndexOf (lrotateGearsOnChain[i]);
				if (index1 > eachGearManager.currentIndexinHeadList /* && */)
				{
				
					//print (index1 + " > currentIndex" );
				//remove
				} 
	    	}

		branchSlave = new List<GameObject> (lrotateGearsOnChain);// new list of wheels which can collect with the slave wheel, copy from old existing list
		//print("addNewSlaveList" );
	
	
	}


	void getBranch()
	{
		thisListBranch = eachGearManager.currentBranchInt;
		//print ("getBranch: " + thisListBranch);
	}


}
