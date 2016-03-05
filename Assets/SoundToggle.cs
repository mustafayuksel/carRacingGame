using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour {

	// Use this for initialization
	public bool canSet;
	public Text soundButtonText;
	void Start () {
		int soundEnable = PlayerPrefs.GetInt ("SoundSettings",1);
		if (soundEnable == 1) {
			if(canSet)
			{
				if(Application.systemLanguage.ToString()!="Turkish"){
			soundButtonText.text = "Sound/On";
				}
				else{

					soundButtonText.text = "Ses/Açık";

				}
			}
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().enabled = true;
		} else {
			if(canSet)
			{
				if(Application.systemLanguage.ToString()!="Turkish"){
					soundButtonText.text = "Sound/Off";
				}
				else{

					soundButtonText.text = "Ses/Kapalı";

				}
			}
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().enabled = false;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (canSet) {
			int soundSettings = PlayerPrefs.GetInt ("SoundSettings", 1);
			if (soundSettings == 1) {
				GameObject.Find ("Main Camera").GetComponent<AudioSource> ().enabled = true;
			} else {
				GameObject.Find ("Main Camera").GetComponent<AudioSource> ().enabled = false;
			}
		}
	}
	public void toggleButton()
	{
		
		if (canSet) {
			if(Application.systemLanguage.ToString()!="Turkish"){
			if (soundButtonText.text == "Sound/On") {
				soundButtonText.text = "Sound/Off";
				PlayerPrefs.SetInt ("SoundSettings", 0);
				PlayerPrefs.Save ();
			} else {
				soundButtonText.text = "Sound/On";
				PlayerPrefs.SetInt ("SoundSettings", 1);
				PlayerPrefs.Save ();
			}
			}
			else{
				if (soundButtonText.text == "Ses/Açık") {
					soundButtonText.text = "Ses/Kapalı";
					PlayerPrefs.SetInt ("SoundSettings", 0);
					PlayerPrefs.Save ();
				} else {
					soundButtonText.text = "Ses/Açık";
					PlayerPrefs.SetInt ("SoundSettings", 1);
					PlayerPrefs.Save ();
				}


			}
		}
	}
	public void LoadGame()
	{
		if (canSet) {
			GameObject.Find("Advertisement").GetComponent<BannerAdvertisement>().bannerView.Destroy();
			PlayerPrefs.SetString("whichScene", "characterSelect");
			PlayerPrefs.Save();
			Application.LoadLevel("loadingScene");
		}
	}
}
