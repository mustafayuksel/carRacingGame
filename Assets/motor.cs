using UnityEngine;
using System.Collections;

public class motor : MonoBehaviour {

	public float horsePower = 82f;
	// Use this for initialization
	void Start () {
		horsePower = 82f;
	}
	
	// Update is called once per frame
	void Update () {
	   if (Input.GetKey (KeyCode.W)) 
		{
			this.GetComponent<Rigidbody>().AddForce(new Vector3(0f,0f,horsePower));
		}
	}
}
