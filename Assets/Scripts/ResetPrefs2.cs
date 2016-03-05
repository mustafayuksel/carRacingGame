using UnityEngine;
using System.Collections;

public class ResetPrefs2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PreferencesManager pm = new PreferencesManager ();
		if (PlayerPrefs.GetInt ("inited", 0) == 0) {
			pm.reset ();
			pm.init ();
			PlayerPrefs.SetInt ("inited", 1);
			PlayerPrefs.Save ();


		} 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
