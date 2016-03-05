using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour {


	// Use this for initialization
	private bool currentProvider;
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player") {
			GenerateTraffic gt = GameObject.Find("worldLoader").GetComponent<GenerateTraffic>();

			CarUtils cc = (CarUtils)c.GetComponent("CarUtils");
			//GameObject go = Resources.Load<GameObject>("BoxAnimation");
			gt.transform.position = this.transform.position;
			for(int i=0; i < 3; i++)
			{
				if(gt.boxAnimationList[i].activeInHierarchy == false)
				{
					gt.boxAnimationList[i].transform.position = this.transform.position;
					gt.boxAnimationList[i].SetActive(true);
					this.gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					break;
				}	
			}
			//Instantiate(go,this.transform.position,this.transform.rotation);
			if(cc.currentSkill.skillName == "Empty")
			{
				gt.skillProvider.transform.position = new Vector3(0.5f,0.5f,0f);
				gt.skillProvider.SetActive(true);
				gt.skillProvider.GetComponent<SkillProviderBehaviour>().Initialize();
			//GameObject skillProvider = Resources.Load<GameObject>("SkillProvider");
			//Instantiate(skillProvider,new Vector3(0.5f,0.5f,0f),Quaternion.identity);
			}
		
			this.gameObject.SetActive(false);

				}
		}
}
