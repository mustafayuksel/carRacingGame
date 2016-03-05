using UnityEngine;
using System.Collections.Generic;

public class SpeederBehaviour : MonoBehaviour {

	// Use this for initialization
	List<string> allTags;
	void Start () {
		allTags = new List<string> ();
		allTags.Add ("Player");
	}
	void OnTriggerEnter(Collider c)
	{
		if (allTags.Contains (c.tag)) 
		{
			CarUtils vu = (CarUtils)c.GetComponent("CarUtils");
			vu.boostCoolDown = 5f;
		//	vu.currentSpeed *= 2;
		 //vu.speedCoolDown = 2f;

		}
	}
}
