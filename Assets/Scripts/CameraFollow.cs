using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public int distance;
	public int lift;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
				if(GUI.Button(new Rect(100,100,100,100),"Play Again"))
				{
					Application.LoadLevel("CarRaceMain");
				}
		
			return;
				}
		this.transform.position = target.position + new Vector3 (0, lift, distance);
		this.transform.LookAt (target);
	}
}
