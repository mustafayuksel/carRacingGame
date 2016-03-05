using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class QuitGame : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
