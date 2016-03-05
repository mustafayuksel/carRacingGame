using UnityEngine;
using System.Collections;

public class MakeInvisible : MonoBehaviour {

	// Use this for initialization

	void Start () {
		transform.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c)
	{
		}
}
