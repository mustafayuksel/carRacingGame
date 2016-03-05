using UnityEngine;
using System.Collections.Generic;

public class TrapBehaviour : MonoBehaviour {

	public List<string> tagList;
	void OnTriggerEnter(Collider c)
	{
		if (tagList.Contains (c.tag)) {
			CarUtils cu = (CarUtils)c.GetComponent("CarUtils");
			cu.health = 0;
		//	c.gameObject.explode();
				}
	}
}
