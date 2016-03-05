using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GiveMoney : MonoBehaviour {
	public Text moneyText;
	public Text buttonText;
	public Button videoButton;
	public bool isGiven;
	// Use this for initialization
	void Start () {
		isGiven = false;
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("62702");
		} else {
			Debug.Log("Platform not supported");
		}
		if (Application.systemLanguage.ToString () == "Turkish") {
			buttonText.text = "5000 Para kazanmak için " +
				"\nvideoyu tamamla";
		}
		videoButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Advertisement.isReady () &&!(isGiven)) {
			videoButton.gameObject.SetActive (true);


		}
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+"";
	}
	public void give()
	{
	
			Advertisement.Show(null, new ShowOptions {
				pause = true,
				resultCallback = result => {
					Debug.Log(result.ToString());
				}
			});

		isGiven = true;
		int moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 0);
		moneyAmount += 5000;
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		PlayerPrefs.Save ();
	}

}
