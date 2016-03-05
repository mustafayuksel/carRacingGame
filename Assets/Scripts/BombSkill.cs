using UnityEngine;
using System.Collections.Generic;

public class BombSkill : ISkill {

	// Use this for initialization
	int level;
	int damage;
	int life;
	public BombSkill(int _level)
	{
		level = _level;
		this.icon = (Texture2D)Resources.Load ("bombicon");
		this.skillName = "Bomb";
		this.lifeTime = 0;
		this.isConsumed = false;
		if (level == 1) {
						damage = 100;
						life = 100;
				} else if (level == 2) {
						damage = 100;
						life = 200;
				} else if (level == 3) {
						damage = 200;
						life = 200;
				} else if (level == 4) {
						damage = 200;
						life = 300;
				} else {
			damage = 300;
			life = 300;
				}
	}
	public override void use(GameObject go,string mark)
	{
		GameObject bomb = Resources.Load<GameObject>("Sphere");
		bomb.GetComponent<AudioSource> ().enabled = true;
		GenerateTraffic gt = GameObject.Find ("worldLoader").GetComponent<GenerateTraffic> ();
		gt.bomb.transform.position = new Vector3 
			(go.transform.position.x, go.transform.position.y - 1f,
			 go.transform.position.z - 3);
		gt.bomb.SetActive (true);
		gt.bomb.GetComponent<DestroyTimer> ().lifeTime = 2f;
		GameObject inst = gt.bomb;
		/*	MonoBehaviour.Instantiate (bomb, new Vector3 
		              (go.transform.position.x, go.transform.position.y - 1f,
		              go.transform.position.z - 3), Quaternion.identity) as GameObject; */
		Bomb bmb = (Bomb)inst.GetComponent("Bomb");
		bmb.mark = mark;
		bmb.damage = this.damage;
		bmb.health = this.life;
		isConsumed = true; 



	}
}
