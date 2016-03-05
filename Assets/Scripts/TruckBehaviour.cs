using UnityEngine;
using System.Collections;

public class TruckBehaviour : MonoBehaviour {

	public float speed;
	public float mineSetupFrequency;
	// Use this for initialization
	void Start () {
		speed = Random.Range (0.3f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (0, 0, -speed);
		setUpMine ();
	
	}
	void setUpMine()
	{
		float mineSetupValue = Random.Range (0f, 1f);
		if (mineSetupValue < mineSetupFrequency) {
			GameObject mine = Resources.Load<GameObject>("Mine");
			Instantiate(mine,new Vector3(this.transform.position.x,
			                             this.transform.position.y,
			                             this.transform.position.z + 10),this.transform.rotation);
				}
		}
}
