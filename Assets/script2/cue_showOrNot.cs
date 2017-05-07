using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue_showOrNot : MonoBehaviour {


	Renderer cue;
	void Start () 
	{
		cue = gameObject.GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void showUp()
	{
		if (gameObject.transform.parent.name == "w_buildCue") {
			bool lisW_buildCueEnable = GameObject.Find ("w_buildCue").GetComponent<line_w2> ().isW_buildCueEnable;

			if (lisW_buildCueEnable) {
				cue.enabled = true;
			}
		}

		if (gameObject.transform.parent.name == "w2_buildCue") {
			bool lisW1_buildCueEnable = GameObject.Find ("w2_buildCue").GetComponent<line_w3> ().isW1_buildCueEnable;

			if (lisW1_buildCueEnable) {
				cue.enabled = true;
			}
//			print ("showup happened");
		}
	}

	void dissapear()
	{
		cue.enabled = false;
	}
}
