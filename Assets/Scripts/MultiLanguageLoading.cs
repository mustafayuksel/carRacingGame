using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiLanguageLoading : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		if (Application.systemLanguage.ToString () == "Turkish") {
			text.text = "Yüklenİyor...";

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
