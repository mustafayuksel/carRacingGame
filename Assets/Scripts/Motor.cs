using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	// Use this for initialization
	public float hp;
	private Vector3 forceDirection;
	void Start () {
		hp = 82;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W))
						this.GetComponent<Rigidbody>().AddForce (new Vector3 (0f, 0f, -hp));

		if (Input.GetKey (KeyCode.A))
						this.transform.Rotate (new Vector3 (0f, -1f, 0f));

		if (Input.GetKey (KeyCode.D))
						this.transform.Rotate (new Vector3(0f,1f,0f));
	}
}
