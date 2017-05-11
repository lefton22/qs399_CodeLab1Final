using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_line : MonoBehaviour {

	SpriteRenderer sr_lnpc;

	void Start () 
	{

		sr_lnpc = gameObject.GetComponent<SpriteRenderer> ();
		sr_lnpc.enabled = false;
	}
	

	void Update () 
	{
		Vector3 mouseV3_2 = Input.mousePosition;

		mouseV3_2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseV3_2.z = 0f;
		transform.position =  mouseV3_2;
	}

	void showNPC()
	{
		sr_lnpc.enabled = true;
	}

	void hideNPC()
	{
		sr_lnpc.enabled = false;
//		print ("move away!");
//		gameObject.transform.position = new Vector3 (999f, 999f, 999f);
	}


}
