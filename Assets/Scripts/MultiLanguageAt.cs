using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiLanguageAt : MonoBehaviour {
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;
	public Text text8;
	public Text text9;
	public Text text10;
	public Text text11;
	public Text text12;
	public Text text13;
	public Text text14;
	// Use this for initialization
	void Start () {
		if (Application.systemLanguage.ToString () == "Turkish") {
			text1.text = "Skor:";
			text2.text = "Yol:";
			text3.text = "Devam Et";
			text4.text = "Garaj";
			text5.text = "Ana ekran";
			text6.text = "Yol";
			text7.text = "Skor";
			text8.text = "Skor";
			text9.text = "Ana ekran";
			text10.text = "Yeniden Oyna";
			text11.text = "Garaj";
			text12.text = "Durduruldu";
			text13.text = "Hız";
			text14.text = "Yakıt";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
