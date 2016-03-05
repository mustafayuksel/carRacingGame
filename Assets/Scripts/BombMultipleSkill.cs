using UnityEngine;
using System.Collections;

public class BombMultipleSkill : ISkill {

	// Use this for initialization
	int bombCount = 3;
	public BombMultipleSkill()
	{

		this.icon = (Texture2D)Resources.Load ("bomb3icon");
		this.skillName = "Bomb3";
		this.lifeTime = 0;
		isConsumed = false;
	}
	public override void use(GameObject gobj,string mark)
	{
		GameObject bomb = Resources.Load<GameObject>("Sphere");
        GameObject inst = MonoBehaviour.Instantiate (bomb, new Vector3 (gobj.transform.position.x, 
		                                 gobj.transform.position.y + 1f,
		                       gobj.transform.position.z - 10), Quaternion.identity) as GameObject;
		Bomb bmb = (Bomb)inst.GetComponent("Bomb");
		bmb.mark = mark;
		bombCount--;
		if (bombCount <= 0) {
			isConsumed = true;
		}
	}
}
