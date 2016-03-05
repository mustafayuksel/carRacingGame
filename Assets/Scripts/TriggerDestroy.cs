using UnityEngine;
using System.Collections;

public class TriggerDestroy : MonoBehaviour {

	// Use this for initialization
	bool destroy;
	void Start () {
		destroy = false;
	}
	
	// Update is called once per frame
	void Update () {
			if (destroy) {
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider c)
	{
		destroy = true;
	}
}
