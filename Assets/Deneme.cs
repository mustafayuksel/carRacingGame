using UnityEngine;
using System.Collections;

public class Deneme : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//this.rigidbody.AddForce (Vector3.up * 1000f);

		if (Input.GetKey (KeyCode.A)) {
			this.transform.Translate(-0.3f,0f,0f);
				}
		if (Input.GetKey (KeyCode.D)) {
			this.transform.Translate(0.3f,0f,0f);
		}  
			//this.transform.Translate(Input.acceleration.x,0f,0f);
		if (this.transform.position.x > 10) {
			this.transform.position = new Vector3(10f,this.transform.position.y,this.transform.position.z);
				}
		if (this.transform.position.x < -10) {
			this.transform.position = new Vector3(-10f,this.transform.position.y,this.transform.position.z);
		}
		//this.transform.rotation = Quaternion.Euler (0f, 180f, 0f);
		

	}
}
