using UnityEngine;
using System.Collections;

public class OilBehaviour : MonoBehaviour {


	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player") {

			CarUtils cu = (CarUtils)c.GetComponent("CarUtils");
			cu.fuel.Capacity += 1000;
			this.gameObject.GetComponent<DestroyTimer>().lifeTime = 2f;

			this.gameObject.SetActive(false);
			//Destroy(this.gameObject);
				}
		}
}
