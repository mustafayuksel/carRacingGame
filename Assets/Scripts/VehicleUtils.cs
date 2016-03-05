using UnityEngine;
using System.Collections.Generic;

public class VehicleUtils : ObjectUtils {

	// Use this for initialization
	public CarState state;
	public float currentSpeed;
	public float minSpeed;
	public float maxSpeed;
	public float speedCoolDown;
    public Dictionary<ISkill,float> skillsAndFreq;
	//public float acceleration;
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
  public bool isAlive()
	{
		if (health <= 0) {
			return false;
				}
		return true;
	}
}
