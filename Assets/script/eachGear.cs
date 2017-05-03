using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eachGear : MonoBehaviour {
	//this script will attacth to each gear that generate

	//2017.4.24 left: next task is add new waypoint to each branch

	//float lpowerSlave;

	public GameObject gear_collide;
	public List<GameObject> gear_collides;

	public int whichSlave;

	GameObject lwheel_n;

	float eachRealSpeed; // when rotated, use this speed

	float lshareRoSpeed; // get the public speed

	int isSlaveThere;

	GameObject lCreateSlavePath;

	GameObject lWayPointSys;

	Vector3 gear_getin_v3;

	public List<GameObject> gear_collidewithThis;

	//createWayPoint lcreateWayPoint;
	List<GameObject> lrotateGearsOnChain;

	public int inWhichBranch; // =1 represent in then main tree, =2 represent in the sencond branch, =3 represent in the thrid...

	int linWhichBranch;

	public int col_1_InWhichBranch;// when collide with a new wheels, use this int to give this gear a initiate bool

	int thisindex;
	int thatindex;

	bool isAddBranchInt;

	//static int max_inWhichBranch;// use it to identify the maximum inWhichBranch;

	GameObject lfindslave;

	//int currentBranchInt; //current inWhichBranch

	bool isThirdwithFirst;

	public List<int> inWhichBranches;

	void Start () 
	{
		//lpowerSlave = GameObject.Find ("whatwouldhappen").GetComponent<newhappen> ().powerSlave;

		isSlaveThere = 0;
		whichSlave = 1;

		if (whichSlave == 1) 
		{
			gameObject.tag = "has_slave";
		}

		//lshareRoSpeed = GameObject.Find ("publicfloat").GetComponent<publicFloat> ().shareRoSpeed;

		gear_collides = new List<GameObject> ();
		gear_collidewithThis = new List<GameObject> ();

		lCreateSlavePath = GameObject.Find ("CreateSlavePath");

		//print (lCreateSlavePath);
		//how about the amounts of the teeth?
		//ho

		lWayPointSys = GameObject.Find ("WayPointSys");

//		lgenerateWayPointSys = GameObject.Find ("generateWayPointSys");

//		lrotateGearsOnChain =  new List<GameObject> (GameObject.Find ("CreateSlavePath").GetComponent< createWayPoint> ().rotateGearsOnChain);
//
//		print("list: " + lrotateGearsOnChain.Count);

		//inWhichBranch = 0;

////  judge if inWhichBranch =1, or2,3,4???

////if it's the first wheel in the world, inWhichBranch =1
		if(eachGearManager.isFirstWheel)
		{
			inWhichBranches.Add (1);
		    inWhichBranch = 1;
		eachGearManager.isFirstWheel = false;
		}

		//isAddBranchInt = false;

		lfindslave = GameObject.Find ("findslave");

		isThirdwithFirst = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
//		lrotateGearsOnChain =  new List<GameObject> 
//			(GameObject.Find ("CreateSlavePath").GetComponent< createWayPoint> ().rotateGearsOnChain);// get the "rotateGearsOnChain" from the createWayPoint

		//print("list: " + lrotateGearsOnChain.Count);


		if (whichSlave == 1 ) //to find slave's power
		{
			eachRealSpeed = 30f;
		} 
		else 
		{
			eachRealSpeed = 0f;
		}

		if (isSlaveThere == 1) 
		{
			//eachRealSpeed = lshareRoSpeed;
		}
	

		lwheel_n = GameObject.Find ("placewheels").GetComponent<placewheels>().wheel_n;
//		lpowerSlave = lwheel_n.GetComponent<inherit> ().speed_inherit;
		//
		transform.Rotate (0, 0, Time.deltaTime * eachRealSpeed); 

		//print ("this gameObject: " + gameObject);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//print (gameObject + " collide with " + other);

//// get the gears which collides with THIS gear
		if (other.tag == "wheel" || other.tag == "has_slave") 
		{
			if (gear_collidewithThis.Contains (other.gameObject)) 
			{
			} 
			else 
			{					
				gear_collidewithThis.Add (other.gameObject);
			}				
		}
			

//// add, remove gears form the List "createWayPoint.rotateGearsOnChain"
		if (other.tag == "wheel" || other.tag  == "has_slave") 
		{
//			print (gameObject + "'s this gameObject:" + gameObject);
//			print (gameObject + "'s that gameObject:" + other.gameObject);
			gear_collide = other.gameObject;

			//GameObject new_gear = other.gameObject;
			gear_getin_v3 = new Vector3();
			gear_getin_v3 = gear_collide.transform.position;//get the original position of this gear

			//lwheel_n.GetComponent<eachGear> ().whichSlave;

			if (lrotateGearsOnChain.Contains (gear_collide)) 
			{

			} 
			else 
			{
				int situ;
				situ = 0;

				if (gear_collidewithThis.Count < 3) 
				{
					situ = 1;
				}
				if (gear_collidewithThis.Count == 3 ) 
				{
					situ = 2;
				}

				int index1 = lrotateGearsOnChain.IndexOf (gameObject);
				if (index1 == 0) 
				{
					if (gear_collidewithThis.Count == 2) 
					{
						situ = 2;
						isThirdwithFirst = true;
						print ("second gear collide with 1st gear");
					}
				}

//				if (index1 == 0) 
//				{
//					if (gear_collidewithThis.Count == 2) 
//					{
//						situ = 3;
//						print ("second  gear collide with 1st gear");
//					}
//				}

				//print ("situ: " + situ);

				switch (situ) {

				case 1: // if no branch

					if (lrotateGearsOnChain.Count == 0) {
						lrotateGearsOnChain.Add (gameObject);
						gameObject.transform.SetParent (lWayPointSys.transform);
						print ("add the 1st gear");


					}

					lrotateGearsOnChain.Add (gear_collide);
					gear_collide.transform.SetParent (lWayPointSys.transform); // add into the slave list, and then give it a parent in "createWayPoints"

					////when this is the first/second gear collide, add the first wheels into the LIST


					////没有分支的情况下，怎么读取上一个轮子的INT, 刚刚碰撞时，if这个此轮的序号小于上一个齿轮的序号，则此齿轮的序号等于上一个齿轮的序号

					thisindex = lrotateGearsOnChain.IndexOf (gameObject);
					thatindex = lrotateGearsOnChain.IndexOf (gear_collide.gameObject);

						//					print (gameObject + ":thisindex: " + thisindex);
						//					print (gameObject + ":thatindex: " + thatindex);
						//
					if (thisindex < thatindex) { //xxx问题是如果other 比它小的话，就并没有添加到总LIST里面，因为已经contain了xxx//xxxx问题是根本没读新齿轮的代码？xxxx//此段代码和上面一段conflict了？
						//print ("thisindex < thatindex");

						col_1_InWhichBranch = lrotateGearsOnChain [thisindex].GetComponent<eachGear> ().inWhichBranch;//add an update, bool thing

						lrotateGearsOnChain [thatindex].GetComponent<eachGear> ().inWhichBranch = col_1_InWhichBranch;

					}

			//// add to List inWhichBranch;
					int kkk = col_1_InWhichBranch;
					//print ("kkk:" + kkk);


					if (gear_collidewithThis.Count == 1) 
					{						//添加给新增加的
						gear_collidewithThis [0].GetComponent<eachGear> ().inWhichBranches.Add (kkk);
						print ("kkk: 0");
					}

					if (gear_collidewithThis.Count == 2) 
					{						//添加给新增加的
						gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranches.Add (kkk);
						//print ("kkk");
					}

					break;


				case 2: //if branch, if >3, forbiden!!!

						/// 直接就生成一个waypointHolder， 然后放在Wayholder里面的LISt里，变成它的child。
					print ("branch!");

//					////build a new WayPointSys from prefab
//					GameObject WayPointSys_n;
//					Vector3 zero = new Vector3 (0, 0, 0);
//					int num_WayPointSys = 0;
//					WayPointSys_n = Instantiate (Resources.Load ("WayPointSys"), zero, Quaternion.identity) as GameObject; 
//
//
//					WayPointSys_n.transform.SetParent (lfindslave.transform);
//
//					num_WayPointSys = num_WayPointSys + 1;
//					WayPointSys_n.name = "wayPointSys" + num_WayPointSys;
//
//
//					eachGearManager.currentIndexinHeadList = lrotateGearsOnChain.IndexOf (gameObject);
//					//print ("current index: " + eachGearManager.currentIndexinHeadList);
//
//					WayPointSys_n.SendMessage ("addNewSlaveList");
				



//					List<GameObject> branchSlave = new List<GameObject> (lrotateGearsOnChain);// new list of wheels which can collect with the slave wheel, copy from old existing list
//					branchSlave.Add (gear_collide);// add in branch list
//						//need a new wayPointSys?



		//// need to add logic about how to judge which branch is this wheels in, then add then into the corresponding prefab "WayPointSys"
					lrotateGearsOnChain.Add (gear_collide);
					gear_collide.transform.SetParent (lWayPointSys.transform); 

					////在相碰的两个轮子的其中一个轮子的代码上加一
//					thisindex = lrotateGearsOnChain.IndexOf (gameObject);
//					thatindex = lrotateGearsOnChain.IndexOf (gear_collide.gameObject);
//					if (thisindex < thatindex) 
//					{
//						eachGearManager.max_inWhichBranch = eachGearManager.max_inWhichBranch + 1;
//						print ("add 1 and =:" + eachGearManager.max_inWhichBranch);
//					}

					int lll;
					if (isThirdwithFirst) 
					{
						//lll = gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranch;

						lll = eachGearManager.max_inWhichBranch + 1;
						eachGearManager.max_inWhichBranch = eachGearManager.max_inWhichBranch + 1;

						gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranch = lll;

						eachGearManager.currentBranchInt = lll;



							inWhichBranches.Add (lll); //添加给母级
							//添加给新增加的
							gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranches.Add (lll);
						//print ("kkk");

						isThirdwithFirst = false;
						//print ("get [1]");
					} 

					//
					lll = gear_collidewithThis [2].GetComponent<eachGear> ().inWhichBranch;
//					print (lll);
//					lll = inWhichBranch +1;

					lll = eachGearManager.max_inWhichBranch + 1;
					eachGearManager.max_inWhichBranch = eachGearManager.max_inWhichBranch + 1;

					gear_collidewithThis [2].GetComponent<eachGear> ().inWhichBranch = lll;

//					eachGearManager.currentBranchInt = lll;
//					WayPointSys_n.SendMessage ("getBranch");



					//	print (gameObject + "'s 2: " +gear_collidewithThis [2].GetComponent<eachGear> ().inWhichBranch);



//							for (int i= 0; i < branchSlave.Count; i++) //debug
//							{
//								//print ("slave list: " + i + ": "+  branchSlave[i]);
//							}

         //// add Branch mark to the gears collide with SLAVE
					/// 
					//List linWhichBranches =  new List<GameObject> ;
					  // (gear_collidewithThis [2].GetComponent< eachGear> ().rotateGearsOnChain);

					if (inWhichBranches.Contains (lll)) 
					{
					} 
					else 
					{
						inWhichBranches.Add (lll); //添加给母级
						//添加给新增加的
						gear_collidewithThis [2].GetComponent<eachGear> ().inWhichBranches.Add (lll);
					}


				//// mark
					//int m_branch = inWhichBranch;
//					for (int i = m_branch; i > 0; i--)
//					{
						//print ("i: " +i);


						int child_Branch = inWhichBranch + 1;  // 当前的最大branch级别
						for (int k = 0; k < lrotateGearsOnChain.Count; k++) 
						{
						
						//print ("for 1: " + lrotateGearsOnChain[k].name);

						for (int j = 0; j < child_Branch ; j++) //problem: only this Branch layer. Need a whole layer, may need to "j--"
							{
							
							int ce_index;
							int ca_index;
							int llinWhichBranch = lrotateGearsOnChain [k].GetComponent<eachGear> ().inWhichBranch;
							if (lrotateGearsOnChain [k].GetComponent<eachGear> ().inWhichBranch == j) 
							{
								ce_index = lrotateGearsOnChain.IndexOf (gameObject);
								ca_index = lrotateGearsOnChain.IndexOf (lrotateGearsOnChain [k]);
								print ("=");
							
								//if xxx, 求出与上一个分支轮的序号，分支数
								//应该是与当前BRANCH组的总序号最小的那个轮子相碰的轮子中，THIS相碰组最小的那个
								//
									if (ce_index > ca_index /* && llinWhichBranch == j */)// 如果这一级的轮子INDEX大于母级轮子
										{

											print ("j: " +j + "quoi: " + lrotateGearsOnChain[k].name );
									//还需要求出与上一个母级相碰的轮子

//											////build a new WayPointSys from prefab
//											GameObject WayPointSys_n;
//											Vector3 zero = new Vector3 (0, 0, 0);
//											int num_WayPointSys = 0;
//											WayPointSys_n = Instantiate (Resources.Load ("WayPointSys"), zero, Quaternion.identity) as GameObject; 
//
//
//											WayPointSys_n.transform.SetParent (lfindslave.transform);
//
//											num_WayPointSys = num_WayPointSys + 1;
//											WayPointSys_n.name = "wayPointSys" + num_WayPointSys;

										}
//									}
							//	}
							}
							}
//						}


					}


				break;


//				case  3:
//
//					/// 直接就生成一个waypointHolder， 然后放在Wayholder里面的LISt里，变成它的child。
//					print ("second!");
//
//					////build a new WayPointSys from prefab
//					GameObject WayPointSys_n2;
//					Vector3 zero2 = new Vector3 (0, 0, 0);
//					int num_WayPointSys2 = 0;
//					WayPointSys_n2 = Instantiate (Resources.Load ("WayPointSys"), zero2, Quaternion.identity) as GameObject; 
//
//
//					WayPointSys_n2.transform.SetParent (lfindslave.transform);
//
//					num_WayPointSys2 = num_WayPointSys2 + 1;
//					WayPointSys_n2.name = "wayPointSys" + num_WayPointSys2;
//
//					//call the "addNewList()" in mana_NewBranch
//					//					mana_NewBranch lmana_NewBranch;
//					//					lmana_NewBranch = WayPointSys_n.GetComponent<mana_NewBranch> ();
//
//					eachGearManager.currentIndexinHeadList = lrotateGearsOnChain.IndexOf (gameObject);
//					//print ("current index: " + eachGearManager.currentIndexinHeadList);
//
//					WayPointSys_n2.SendMessage ("addNewSlaveList");
//
//
//					//// need to add logic about how to judge which branch is this wheels in, then add then into the corresponding prefab "WayPointSys"
//					lrotateGearsOnChain.Add (gear_collide);
//					gear_collide.transform.SetParent (lWayPointSys.transform); 
//
//					//lll = gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranch;
//
//					lll = eachGearManager.max_inWhichBranch + 1;
//					eachGearManager.max_inWhichBranch = eachGearManager.max_inWhichBranch + 1;
//
//					gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranch = lll;
//
//					eachGearManager.currentBranchInt = lll;
//
//
//
//					inWhichBranches.Add (lll); //添加给母级
//					//添加给新增加的
//					gear_collidewithThis [1].GetComponent<eachGear> ().inWhichBranches.Add (lll);
//					print ("kkk");
//
//					isThirdwithFirst = false;
//					//print ("get [1]");
//
//
//
//					break;
				}


			

			}



			for (int i= 0; i < lrotateGearsOnChain.Count; i++) 
			{
				//print ("slave list: " + i + ": "+  createWayPoint.rotateGearsOnChain[i]);
			}
				


		}
	}

	void OnTriggerExit2D(Collider2D other)
	{


		if (other.tag == "wheel"  || other.tag  == "has_slave") 
		{
			GameObject gear_exit = other.gameObject;

//			if (gear_collides.Contains (gear_exit)) 
//			{
//				gear_collides.Remove (gear_exit);
//			}
			Vector3 gear_exit_v3 = new Vector3();
			gear_exit_v3 = gear_exit.transform.position;

			Vector3 diff_exit_getin_v3 = new Vector3 ();

			diff_exit_getin_v3 = gear_exit_v3 - gear_getin_v3;// get the positio when this gear moves
			Vector3 zero = new Vector3 (0,0,0);

			//print ("diff: " +diff_exit_getin_v3);

			if (lrotateGearsOnChain.Contains (gear_exit) && diff_exit_getin_v3 != zero) // when it exists this group, to judge which one is moved their transform
			{
				print (gameObject + "remove");
				lrotateGearsOnChain.Remove (gear_exit);	

				gear_exit.transform.SetParent (null);
			}

//			float collidesSpeed = gear_exit.GetComponent<eachGear>().eachRealSpeed;
//			int collidersSlave = gear_exit.GetComponent<eachGear>().whichSlave;
//
// 
//
//			if (collidersSlave == 1) 
//			{
//				gear_collides.Remove (gear_exit);
//				print (gameObject + "邻居奴隶撤退");
//				if (gear_collides.Count <= 0) {
//					eachRealSpeed = 0f;
//					isSlaveThere = 0;
//				}
//			} 
		}
	}


}
