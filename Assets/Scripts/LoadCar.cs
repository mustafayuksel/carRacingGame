using UnityEngine;
using System.Collections;

public class LoadCar : MonoBehaviour {

	// Use this for initialization
	public GameObject respawn;
	void Awake()
	{
	
	}
	void Start () {

		string name = PlayerPrefs.GetString ("SelectedCarName", "buggy");
		GameObject car = Resources.Load<GameObject> (name);
	
		GameObject go = Instantiate (car, new Vector3(respawn.transform.position.x,respawn.transform.position.y,respawn.transform.position.z), car.transform.rotation) as GameObject;
		CameraFollow cf = (CameraFollow)GameObject.Find("Main Camera").GetComponent ("CameraFollow");
		cf.distance = 15;
		cf.lift = 10;
		cf.target = go.transform;
	/*	GameObject t = GameObject.Find ("Texts");
		t.SendMessage ("makeActive", SendMessageOptions.RequireReceiver);  */
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
