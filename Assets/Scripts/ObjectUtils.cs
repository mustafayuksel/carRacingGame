using UnityEngine;
using System.Collections;

public class ObjectUtils : MonoBehaviour {


	public int health;
	public int originalHealth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isAlive ()) {
			this.gameObject.explode();
				}
	}
	public bool isAlive()
	{
		return (this.health > 0);
	}

}
