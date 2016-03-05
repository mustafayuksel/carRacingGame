using UnityEngine;
using System.Collections.Generic;

public class KillNearSkill : ISkill {

	// Use this for initialization
	List<string> canHarm;
	int level;
	public KillNearSkill(int _level)
	{
		level = _level;
		this.skillName = "killNear";
		this.icon = (Texture2D)Resources.Load ("killnearicon2");
		this.isConsumed = false;
		this.lifeTime = 5f;
	
		canHarm = new List<string> ();
		canHarm.Add ("Deadly");
		canHarm.Add ("Truck");
		canHarm.Add ("Mine");
		canHarm.Add ("ShieldTruck");
		canHarm.Add ("Bomber");
		canHarm.Add ("Tank");
		if (level == 1) {
						lifeTime = 2f;
				} else if (level == 2) {
						lifeTime = 4f;
				} else if (level == 6) {
						lifeTime = 6f;
				} else if (level == 4) {
						lifeTime = 8f;
				} else {
			lifeTime = 10f;
				}
	}
	public override void use(GameObject go,string mark)
	{
		this.lifeTime -= Time.deltaTime;
		if (this.lifeTime < 0) 
		        {
			this.isConsumed = true;
				}
			CarUtils cu = (CarUtils)go.GetComponent ("CarUtils");
		//cu.state = CarState.Speed4x;
		cu.boostCoolDown = 5f;
			List<GameObject> willExplode = new List<GameObject> ();
		foreach (string s in canHarm) {
				GameObject [] allDeadly = GameObject.FindGameObjectsWithTag(s);
				willExplode.AddRange(allDeadly);
				}
		foreach (GameObject kill in willExplode) {
			if(Vector3.Distance(kill.transform.position,go.transform.position) < 20f)
			{
				kill.explode();
				GameUtils.addBombBonus(1000,Color.red);
			}
		}
	}
}
