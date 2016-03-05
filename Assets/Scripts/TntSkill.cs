using UnityEngine;
using System.Collections;

public class TntSkill : ISkill {

	// Use this for initialization

	public TntSkill()
	{
		this.skillName = "tnt";
		this.icon = (Texture2D)Resources.Load ("tnticon");
		this.lifeTime = 0f;
		this.isConsumed = false;
	}
	public override void use(GameObject gobj,string mark)
	{
		GenerateTraffic gt = GameObject.Find ("worldLoader").GetComponent<GenerateTraffic> ();
		for (int i=0; i < gt.poolNumber; i++) {
			if(gt.tntList[i].activeInHierarchy == false)
			{
			gt.tntList[i].transform.position =	new Vector3 (gobj.transform.position.x,
				             gobj.transform.position.y,
				                                                gobj.transform.position.z + 15);
				gt.tntList[i].SetActive(true);
			gt.tntList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
				gt.tntList[i].gameObject.GetComponent<ObjectUtils>().health = 1;
				break;
			}
		}
		/*
		GameObject mine = Resources.Load<GameObject>("Mine");
	    GameObject instance = MonoBehaviour.Instantiate (mine, new Vector3 (gobj.transform.position.x,
		                        gobj.transform.position.y,
		                    gobj.transform.position.z + 10), Quaternion.identity) as GameObject;
		MineBehaviour mb = (MineBehaviour)instance.GetComponent ("MineBehaviour"); */
	
		this.isConsumed = true;
	}
}
