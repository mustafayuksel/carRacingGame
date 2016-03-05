using UnityEngine;
using System.Collections.Generic;

public class Bomb : MonoBehaviour {

	// Use this for initialization
	public int damage;
	public float speed;
	public int health;
	List<string> harmfulTagList;
	List<string> selfDestructTagList;
	public string mark;
	RaycastHit hit;
	void Start () {
		harmfulTagList = new List<string> ();
		selfDestructTagList = new List<string> ();
		speed = 5f;
		damage = 100;
		harmfulTagList.Add ("Mine");
		harmfulTagList.Add ("Truck");
		harmfulTagList.Add ("Player");
		harmfulTagList.Add ("ShieldTruck");
		harmfulTagList.Add ("Bomber");
		harmfulTagList.Add ("Tank");
		selfDestructTagList.Add ("Ramp");
		selfDestructTagList.Add ("Trap");
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (0, 0, -speed);


		if(Physics.Raycast(this.transform.position,new Vector3(0f,0f,-1f),out hit,5f))
		{
			if(harmfulTagList.Contains(hit.transform.gameObject.tag))
			{
				ObjectUtils outils = new ObjectUtilsFactory (hit.transform.gameObject).produce ();
				outils.health -= damage;
				if(mark == "Player")
				{
					GameUtils.addBombBonus(1000,Color.red);
				}
				this.health -= 100;
				if(this.health <= 0)
				{
					this.gameObject.GetComponent<DestroyTimer>().lifeTime = 2f;
				this.gameObject.explode ();
				}
			}
			if (selfDestructTagList.Contains (hit.transform.gameObject.tag)) {
				this.gameObject.GetComponent<DestroyTimer>().lifeTime = 2f;
				this.gameObject.explode ();
			}
			}
		}

		
				

	/*
	void OnTriggerEnter(Collider c)
	{
				if (harmfulTagList.Contains (c.tag)) {
						ObjectUtils outils = new ObjectUtilsFactory (c.gameObject).produce ();
						outils.health -= damage;
			if(mark == "Player")
			{
				GameUtils.addBombBonus(1000,Color.red);
			}
			this.gameObject.explode ();
				}
				if (selfDestructTagList.Contains (c.tag)) {
						this.gameObject.explode ();
				}
				
		}
		*/

}
