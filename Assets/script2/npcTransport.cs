using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcTransport : MonoBehaviour {

	public GameObject touch;

	float meetTime;

	void Start () 
	{
		meetTime = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//print (Time.time);
		if (Time.time - meetTime > 2f) 
		{//if is frozen time
			if (touch != null)
			{
				Debug.DrawLine (touch.transform.position, gameObject.transform.position, Color.cyan);
				Vector3 v3_other = touch.transform.position;
				Vector3 v3_this = transform.position;

				Vector3 dist_two = v3_other - v3_this;

				Vector2 v2_other = new Vector2 (v3_other.x, v3_other.y);
				Vector2 v2_this = new Vector2 (v3_this.x, v3_this.y);
				Vector2 v2_dist_two = v2_this - v2_other;

				Vector2 dir = v2_this - v2_other;
				RaycastHit2D[] hits;
				hits = Physics2D.LinecastAll (v2_this, v2_other);
				for (int i = 0; i < hits.Length; i++)
				{
					if (hits [i].collider != null) 
					{
						//print (gameObject.name + "'s  hit.point: " + i + ": " + hits[i].collider.name);
						if (hits [i].collider.gameObject.tag == "npc")
						{
							print ("npc into the line.");	
							meetTime = Time.time;
							hits [i].collider.gameObject.SendMessage ("moveToOther");
						}
					}
				}
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "wheel" || other.tag == "hasSlave") 
		{
			touch = other.gameObject;
		}
	}
}
