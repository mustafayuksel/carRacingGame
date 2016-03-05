using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void sceneLoad(string name){
		Application.LoadLevel (name);


	}
	// Update is called once per frame
	void Update () {
	
	}
}
