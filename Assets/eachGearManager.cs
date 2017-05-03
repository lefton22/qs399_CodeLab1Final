using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eachGearManager : MonoBehaviour {

	public static int max_inWhichBranch; // how many times the branch created?
	public static bool isFirstWheel;

	public static int currentBranchInt;
	public static int currentIndexinHeadList;
////========// all variables are old version's 

	public static bool canIbuild; //detect if this gears' inside collider collides with other gear's inside collider.


	void Start () 
	{
		max_inWhichBranch = 1;
		isFirstWheel = true;
		currentBranchInt = 1;
	////========// all variables are old version's 
		/// 
		canIbuild = true; 


	}

	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
