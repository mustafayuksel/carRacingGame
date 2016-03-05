using UnityEngine;
using System.Collections;

public class ShieldSkill : ISkill {

	// Use this for initialization
	int healthIncreaseAmount = 100;
	int level;
	//bool isUsing;
	ObjectUtils ou;
	public ShieldSkill(int _level)
	{
		//isUsing = false;
		level = _level;
		this.isConsumed = false;
		this.skillName = "Shield";
		this.lifeTime = 0f;
		this.icon = (Texture2D)Resources.Load ("pharmacy3");
		if (level == 1) {
			healthIncreaseAmount = 100;
			//lifeTime = 10;
				}
		else if(level == 2)
		{
			healthIncreaseAmount = 200;
			//lifeTime = 20;
		}
		else if(level == 3)
		{
			healthIncreaseAmount = 300;
			//7lifeTime = 20;
		}
		else if(level == 4)
		{
			healthIncreaseAmount = 400;
			//lifeTime = 30;
		}
		else
		{
			healthIncreaseAmount = 500;
			//lifeTime = 30;
		}
	}
	public override void use(GameObject go,string mark)
	{
		ou = new ObjectUtilsFactory (go).produce ();
		ou.health += healthIncreaseAmount;
		/*GameObject go1 = (GameObject)Resources.Load("ShieldSound");
		MonoBehaviour.Instantiate(go1,new Vector3(0f,0f,0f),Quaternion.identity); */
		/*
		if (!isUsing) {
					
				}  */
		//isUsing = true;
		//this.lifeTime -= Time.deltaTime;
	  /*
		if (lifeTime <= 0) {
			ou.health = ou.originalHealth;  */
			this.isConsumed = true;
				}
		//this.isConsumed = true;
	}

