using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class quit : MonoBehaviour {
	
	// Use this for initialization
	public Button quitButton;
	void Start () {
			quitButton.onClick.AddListener (() => {
			Application.Quit();

		});
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
