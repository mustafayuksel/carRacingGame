using UnityEngine;
using System.Collections.Generic;

public class SkillProviderBehaviour : MonoBehaviour {


	List<ISkill> allSkills;
	public float selectTime;
	private bool flag;
	ISkill selected;
	GameObject car;
	public bool blinking;
	public bool blinkState;

	float blinkTime = 0.5f;
	CarUtils cc;

	// Use this for initialization
	public void Initialize()
	{
		selectTime = 2f;
		blinkTime = 0.5f;
		blinking = false;
		blinkState = false;
		allSkills = new List<ISkill> ();
		//allSkills.Add(new TntSkill());
		//allSkills.Add (new BombMultipleSkill ());
		allSkills.Add(new ShieldSkill(PlayerPrefs.GetInt("shieldSkillLevel")));
		allSkills.Add(new KillAllSkill(PlayerPrefs.GetInt("killAllSkillLevel")));
		car = GameObject.FindWithTag ("Player");
		cc = (CarUtils)car.GetComponent ("CarUtils");
	}
	void Start () {

		blinking = false;
		blinkState = false;
		allSkills = new List<ISkill> ();
		//allSkills.Add(new TntSkill());
		//allSkills.Add (new BombMultipleSkill ());
		allSkills.Add(new ShieldSkill(PlayerPrefs.GetInt("shieldSkillLevel")));
		allSkills.Add(new KillAllSkill(PlayerPrefs.GetInt("killAllSkillLevel")));
		car = GameObject.FindWithTag ("Player");
		cc = (CarUtils)car.GetComponent ("CarUtils");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
	{

		selectTime -= Time.deltaTime;
		flag = !flag;
		if (selectTime > 0) {
		
			cc.currentSkill.skillName = "Selecting";
			selected = allSkills [Random.Range (0, 2)];
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 32, Screen.height * 4 / 6, 64, 64), selected.icon);


		} else {
			this.GetComponent<AudioSource>().enabled = true;

		
				GUI.DrawTexture (new Rect ((Screen.width / 2) - 32, Screen.height * 4 / 6, 64, 64), selected.icon);
					cc.currentSkill.skillName = selected.skillName;
					cc.currentSkill = selected;
				}
			
		
		}
	void blink()
	{

		blinkTime -= Time.deltaTime;
		if (blinkTime < 0) {
			blinkState = !blinkState;
		
			blinkTime = 0.5f;
		}
		if (blinkState) {
			GUI.DrawTexture(new Rect((Screen.width / 2) - 32,Screen.height * 5 / 6,64,64),null);
		} else {
			GUI.DrawTexture(new Rect((Screen.width / 2) - 32,Screen.height * 5 / 6,64,64),selected.icon);
		}
	}

}
