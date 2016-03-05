using UnityEngine;
using System.Collections;

public class AnimateFlyingText : MonoBehaviour {

	// Use this for initialization
	float bonusPoints = 0;
	bool isLanded = false;
	float lifeTime = 1f;
	float startPos = 0;
	public CarState state;
	void Start () {
		isLanded = false;
	}
	
	// Update is called once per frame
	void Update () {

				if (!isLanded) {
						bonusPoints += 100;
						GetComponent<GUIText>().text = "+" + bonusPoints;
				}
				
		if(isLanded)
		{
			startPos += 15;
			GetComponent<GUIText>().pixelOffset = new Vector2(GetComponent<GUIText>().pixelOffset.x,startPos);
			lifeTime -= Time.deltaTime;
			if(lifeTime < 0)
			{
				Destroy(this.gameObject);
			}  
		}
				
						
				

	}
	void triggerAnimation()
	{
		isLanded = true;
		}
}
