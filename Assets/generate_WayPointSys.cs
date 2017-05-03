using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_WayPointSys : MonoBehaviour {

	GameObject nov_wayPointSys;
	Vector3 zero_v3;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		zero_v3 = new Vector3 (0,0,0);
	}

	void generateWayPointSys() // create new waypointsys from "eachGear"
	{
		nov_wayPointSys = Instantiate(Resources.Load("WayPointSys"), zero_v3, Quaternion.identity) as GameObject;
		print ("new wayPointSys 生成！");
	}
}
