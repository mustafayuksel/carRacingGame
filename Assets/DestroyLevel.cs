using UnityEngine;
using System.Collections;

public class DestroyLevel : MonoBehaviour {

	// Use this for initialization
	bool flag;
	void Start () {
		flag = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (flag) {
			this.gameObject.transform.parent.gameObject.SetActive (false);
			flag = false;
		}
			
	}
	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player") {
			flag = true;
		}

	}

}
