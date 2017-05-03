using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_w2 : MonoBehaviour {

	SpriteRenderer sp_line_w2;
	public bool isW_buildCueEnable;

	void Start () 
	{
		sp_line_w2 = this.gameObject.GetComponent<SpriteRenderer> ();	

		isW_buildCueEnable = false;
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
		sp_line_w2.enabled = true;

		isW_buildCueEnable = true;
	}

	void hide()
	{
		//Debug.Log ("hide!");
		sp_line_w2.enabled = false;

		isW_buildCueEnable = false;
	}
}
