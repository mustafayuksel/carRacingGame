using UnityEngine;
using System.Collections;

public class BlinkCar : MonoBehaviour {

	// Use this for initialization
	public float totalBlinkTime;
	float blinkperiod;
	GameObject player;
	bool activeFlag;
	void Start () {
		blinkperiod = 0.3f;
		totalBlinkTime = 0f;
		activeFlag = true;
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		blink ();
	}
	void blink()
	{
		
		totalBlinkTime -= Time.deltaTime;
		blinkperiod -= Time.deltaTime;
		if (totalBlinkTime < 0f) {
			if(player)
			{
			player.gameObject.SetActive(true);
			}
				blinkperiod = 0.3f;
		}
		if (blinkperiod < 0f && totalBlinkTime > 0f) {
			
			player.gameObject.SetActive(!activeFlag);
			activeFlag = !activeFlag;
			
			blinkperiod = 0.3f;
		}
	}
}
