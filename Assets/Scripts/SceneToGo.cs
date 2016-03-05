using UnityEngine;
using System.Collections;

public class SceneToGo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void selectScene(string sceneName){
		Time.timeScale = 1;
		GameUtils.score = 0;
		PlayerPrefs.SetString ("whichScene", sceneName);
		PlayerPrefs.Save ();
		Application.LoadLevel ("loadingScene");

	}
	// Update is called once per frame
	void Update () {
	
	}
}
