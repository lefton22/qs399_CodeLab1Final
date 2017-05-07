using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beMyNpc : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "npc") 
		{
			other.transform.SetParent (gameObject.transform);
		}
	}
}
