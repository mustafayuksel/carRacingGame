using UnityEngine;
using System.Collections.Generic;

public class KillAllSkill : ISkill {

	// Use this for initialization
	int level;
	int radius;
	GameObject player;
	public KillAllSkill(int _level)
	{
		level = _level;
		this.isConsumed = false;
		this.icon = (Texture2D)Resources.Load ("star73");
		this.lifeTime = 0;
		this.skillName = "KillAll";
		if (level == 1) {
						radius = 100;
				} else if (level == 2) {
						radius = 200;
				} else if (level == 3) {
						radius = 300;
				} else if (level == 4) {
						radius = 500;
				} else {
			radius =1000;
				}
		player = GameObject.FindWithTag ("Player");
	}
	public override void use(GameObject gob,string mark)
	{
		List<string> canHarm = new List<string> ();
		//canHarm.Add ("Deadly");
		canHarm.Add ("Mine");
		canHarm.Add ("Truck");
		//canHarm.Add ("ShieldTruck");
		//canHarm.Add ("Bomber");
		//canHarm.Add ("Tank");
		List<GameObject> allDeadly = new List<GameObject> ();
		foreach (string s in canHarm) 
		{
			GameObject [] temp = GameObject.FindGameObjectsWithTag(s);
			Debug.Log (temp);
			allDeadly.AddRange(temp);
		}
		foreach (GameObject go in allDeadly) {

			if(Vector3.Distance(player.transform.position,go.transform.position) < radius)
			{
				go.explode();
			}

		}
		GameUtils.addKillAllBonus ();
		isConsumed = true;
		}
}
