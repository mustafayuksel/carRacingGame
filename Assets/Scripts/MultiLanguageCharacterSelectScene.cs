using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiLanguageCharacterSelectScene : MonoBehaviour {
	public Text text1;
	public Text text2;
	public Text text3;
	public Text text4;
	public Text text5;
	public Text text6;
	public Text text7;
	public Text text8;
	public Text text9;
	// Use this for initialization
	void Start () {
		if (Application.systemLanguage.ToString () == "Turkish") {
			text1.text = "Galerİ";
			text2.text = "Garaj";
			text3.text = "Cephane";
			text4.text = "Kilidi Aç";
			text5.text = "Bu özelliği açmak için yeterli paran yok";
			text6.text = "Hız";
			text7.text = "Fren";
			text8.text = "Yakıt";
			text9.text = "Oyna";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.systemLanguage.ToString () == "Turkish") {
			text1.text = "Galerİ";
			text2.text = "Garaj";
			text3.text = "Cephane";
			text4.text = "Kilidi Aç";
			text5.text = "Bu özelliği açmak için yeterli paran yok";
			text6.text = "Hız";
			text7.text = "Fren";
			text8.text = "Yakıt";
			text9.text = "Oyna";
		}
	}
}
