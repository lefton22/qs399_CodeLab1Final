using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcRotateSelf : MonoBehaviour {

	public float speed;
	float speed_npc;
	float speed_npc2;

	float neg_pos;

	void Start () 
	{
		speed_npc = 1f;
		speed_npc2 = 0.2f;
	}
	

	void Update ()
	{
		if (gameObject.transform.GetChild (0).name == "npc") // to define which npc, this place is npc, there will be another npc
		{
			speed = speed_npc;
		}
		if (gameObject.transform.GetChild (0).name == "npc2") // to define which npc, this place is npc, there will be another npc
		{
			speed = speed_npc2;
		}

		float mother_speed = gameObject.transform.parent.GetComponent<SingleGear0> ().speed;

		if (mother_speed < 0) 
		{
			neg_pos = -1f;
		}
		if (mother_speed > 0) 
		{
			neg_pos = 1f;
		}

		transform.Rotate (0,0,speed * neg_pos );
	}
}
