using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_w3 : MonoBehaviour {

	SpriteRenderer sp_line_w3;

	public bool isW1_buildCueEnable;

	void Start () 
	{
		sp_line_w3 = this.gameObject.GetComponent<SpriteRenderer> ();	

		isW1_buildCueEnable = false;
	}


	void Update () 
	{
		Vector3 mouseV3_2 = Input.mousePosition;

		mouseV3_2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseV3_2.z = 0f;
		transform.position =  mouseV3_2;

	}

	void appear()
	{
		//Debug.Log ("hide!");
		sp_line_w3.enabled = true;

		isW1_buildCueEnable = true;
	}

	void hide()
	{
		//Debug.Log ("hide!");
		sp_line_w3.enabled = false;

		isW1_buildCueEnable = false;
	}
}
