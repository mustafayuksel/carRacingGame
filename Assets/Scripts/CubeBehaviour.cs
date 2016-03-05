using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {


	Level currentLevel;
	//GameObject player;
	public GameObject world;
	public float generateDistance;
	public float destroyDistance;
	public float dDistance;
	GameObject [] oldWorld;
	GameObject www;
	void Awake()
	{
		//player = GameObject.FindWithTag("Player");
		}
	void OnTriggerEnter(Collider c)
	{

	
			if (c.tag == "Player") {
				GenerateTraffic gt = GameObject.Find ("worldLoader").GetComponent<GenerateTraffic> ();
			GameObject oldworld = this.gameObject.transform.parent.gameObject;

				float oldz = oldworld.transform.position.z -2000;
				for (int i=0; i < 3; i++) {
					if (gt.worldList [i].activeInHierarchy == false) {
						gt.worldList [i].transform.position = new Vector3 (-337, -240, oldz);
						gt.worldList [i].SetActive (true);
						
						break;
					}
				}
			}

		


	  /*
		currentLevel = GameUtils.currentLevel;
		if (c.tag == "Player") {
			oldWorld = GameObject.FindGameObjectsWithTag ("World");
			foreach (GameObject world in oldWorld) {
	
				if (Vector3.Distance (c.transform.position, world.transform.position) < dDistance) {
					www = world;

				}
				loadNewWorld (www);
		

				//Destroy(this.gameObject);
			}
		}  */

	}
	void Update()
	{ 
		//if (player && (this.transform.position.z - player.transform.position.z > destroyDistance)) {
			//Destroy(www.gameObject);
		
				//}
	}
	void loadNewWorld(GameObject oldWorld)
	{
		world.tag = "World";
		float oldz = oldWorld.transform.position.z - generateDistance;
		/*
		GenerateTraffic [] generators = world.GetComponents<GenerateTraffic> ();
		for (int i=0; i < generators.Length; i++) {
			if(generators[i].what.name == "ram3500")
			{
				generators[i].trafficDensity = currentLevel._truckDensity;
				
			}
			else if(generators[i].what.name == "Speeder")
			{
				generators[i].trafficDensity = currentLevel._speederDensity;
			}
			else if(generators[i].what.name == "Ramp")
			{
				generators[i].trafficDensity = currentLevel._rampDensity;
			}
			else if(generators[i].what.name == "Box")
			{
				generators[i].trafficDensity = currentLevel._boxDensity;
			}
			else if(generators[i].what.name == "ShieldTruck")
			{
				generators[i].trafficDensity = currentLevel._shieldTruckDensity;
			}
			else if(generators[i].what.name =="Bomber")
			{
				generators[i].trafficDensity = currentLevel._bomberDensity;
			}
			else if(generators[i].what.name =="Tank")
			{
				generators[i].trafficDensity = currentLevel._tankDensity;
			}
			else if(generators[i].what.name =="Trap")
			{
				generators[i].trafficDensity = currentLevel._trapDensity;
			}
			else if(generators[i].what.name =="gas")
			{
				generators[i].trafficDensity = currentLevel._oilDensity;
			}
			*/


		//}
   // Destroy (oldWorld.gameObject);
		
		GenerateTraffic gt = GameObject.FindWithTag ("Player").GetComponent<GenerateTraffic> ();
		for (int i=0; i < 3; i++) {
			if(gt.worldList[i].activeInHierarchy == false)
			{
				gt.worldList[i].transform.position = new Vector3(-337,-240,oldz);
				gt.worldList[i].SetActive(true);
				break;
			}
		}
	//	Instantiate (world, new Vector3 (-337, -240, oldz), Quaternion.identity);
		
	}
}
