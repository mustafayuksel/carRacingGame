using UnityEngine;
using System.Collections.Generic;

public class TruckUtils : VehicleUtils {



	public List<SkillIndex> canUse = new List<SkillIndex> ();
	public ISkill s;
	public float mineSetupFreq;
	public GameObject player;
	public CarUtils cu;
	private float reverseTime;
	void Start () {
		reverseTime = 2f;
		state = CarState.Idle;
		currentSpeed = Random.Range (minSpeed, maxSpeed);
		player = GameObject.FindWithTag ("Player");
		if (player) {
						cu = (CarUtils)player.GetComponent ("CarUtils");
				}
	}
	
	// Update is called once per frame
	void Update () {
		if (cu.paused) {
			this.GetComponent<AudioSource> ().enabled = false;
		} else {
			this.GetComponent<AudioSource> ().enabled = true;
		}
		if (!isAlive () && !cu.paused) {
			this.gameObject.explode();
		}
		if (!cu.paused) {
			this.transform.Translate (0f, 0f, -this.currentSpeed, Space.World);
			useSkill ();
			reverse ();
		}
	}
	void reverse()
	{
		float currentRotation = this.transform.rotation.eulerAngles.y;
		if (currentRotation > 181f || currentRotation < 179f) {
			reverseTime -= Time.deltaTime;
		} else {
			reverseTime = 2f;
		}
		if (reverseTime < 0f) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
			this.transform.rotation = Quaternion.Euler (new Vector3 (0f, 180f, 0f));
			reverseTime = 2f;
		}
	}
	void useSkill()
	{
		float use = Random.Range (0f, 1f);
		if (use < mineSetupFreq) {
			ISkill s = GameUtils.getSkill(canUse[Random.Range(0, canUse.Count)]);
			if(player)
			{
			if(!(Vector3.Distance(this.gameObject.transform.position,player.gameObject.transform.position) < 20f))
			{
			s.use(this.gameObject,this.tag);
			}
			}
				}
	}
}
