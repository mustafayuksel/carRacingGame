using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MultiLanguageImageSliding : MonoBehaviour {
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;


	// Use this for initialization
	void Start () {
		if (Application.systemLanguage.ToString () == "Turkish") {

			text4.text = "Alpler";
			text5.text = "Sahİl yolu";
			text6.text = "Bölüm seç";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
