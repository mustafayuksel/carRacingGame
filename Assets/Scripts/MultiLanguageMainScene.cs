using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiLanguageMainScene : MonoBehaviour {
	public Text startText;
	public Text settingsText;
	public Text tutorialText;
	public Text quitText;
	// Use this for initialization
	void Start () {
		if (Application.systemLanguage.ToString () == "Turkish") {
			startText.text = "Oyna";
			settingsText.text = "Ses/Açık";
			tutorialText.text = "Nasıl Oynarım";
			quitText.text = "Çık";


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
