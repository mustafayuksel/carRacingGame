using UnityEngine;
using System.Collections.Generic;

public class MineBehaviour : MonoBehaviour {

	// Use this for initialization
	int healthDecreaseAmount;
	List<string> canHarm;
	void Start () {
		canHarm = new List<string> ();
		canHarm.Add ("Deadly");
		canHarm.Add ("Player");
		canHarm.Add ("Truck");
		canHarm.Add ("ShieldTruck");
		canHarm.Add ("Bomber");
		canHarm.Add ("Tank");
		healthDecreaseAmount = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c)
	{
			if (canHarm.Contains (c.tag)) {
			ObjectUtils ou = new ObjectUtilsFactory(c.gameObject).produce();
			ou.health-=healthDecreaseAmount;
			this.gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
			this.gameObject.explode();
				}
		}

}
