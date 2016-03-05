using UnityEngine;

public class ObjectUtilsFactory {

	public GameObject gameObj;

	public ObjectUtilsFactory(GameObject gobj)
	{
		gameObj = gobj;
		}
	public ObjectUtils produce()
	{  
		switch (gameObj.tag) {
		case "Mine":
			return (ObjectUtils)gameObj.GetComponent("ObjectUtils");
		case "Truck":
			return (ObjectUtils)gameObj.GetComponent("TruckUtils");
		case "Player":
			return (ObjectUtils)gameObj.GetComponent("CarUtils");
		case "ShieldTruck":
			return (ObjectUtils)gameObj.GetComponent("TruckUtils");
		case "Bomber":
			return (ObjectUtils)gameObj.GetComponent("TruckUtils");
		case "Tank":
			return (ObjectUtils)gameObj.GetComponent("TruckUtils");
		default:
			return null;
				}


}
}
