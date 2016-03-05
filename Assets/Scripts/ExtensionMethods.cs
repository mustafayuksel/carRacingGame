using UnityEngine;
using System.Collections;

public static class ExtensionMethods  {

	public static void explode(this GameObject gameobject)
	{
		GenerateTraffic gt = GameObject.Find ("worldLoader").GetComponent<GenerateTraffic> ();
		for (int i=0; i < gt.poolNumber; i++) {
			if(gt.bombEffectsList[i].activeInHierarchy == false)
			{
				gt.bombEffectsList[i].transform.position = gameobject.transform.position;
				gt.bombEffectsList[i].SetActive(true);
				gt.bombEffectsList[i].GetComponent<DestroyTimer>().lifeTime = 1f;
				break;
			
				
			}
		}
		for (int i=0; i < gt.poolNumber; i++) {
			if(gt.bombSoundList[i].activeInHierarchy == false)
			{
	
				gt.bombSoundList[i].transform.position = gameobject.transform.position;
				gt.bombSoundList[i].SetActive(true);
				gt.bombSoundList[i].GetComponent<DestroyTimer>().lifeTime = 1f;
				break;
				
			}
		}

		//GameObject bombs = (GameObject)Resources.Load("BombSound");

		//MonoBehaviour.Instantiate(bombs,gameobject.transform.position,gameobject.transform.rotation);
		gameobject.SetActive (false);
	}
	public static void destroyByTime(this GameObject gameobject,ref float lifeTime)
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0) {
			MonoBehaviour.Destroy(gameobject);
				}
	}
}
