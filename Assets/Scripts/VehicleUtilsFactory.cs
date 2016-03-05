using UnityEngine;


public class VehicleUtilsFactory  {

	public GameObject vehicle;
	public VehicleUtilsFactory(GameObject go)
	{
		vehicle = go;
	}
	public VehicleUtils produce()
	{
		if (vehicle.tag == "Player") 
		{
			CarUtils cu = (CarUtils)vehicle.GetComponent("CarUtils");
			return cu;
		}
		else if(vehicle.tag == "Truck")
		{
			TruckUtils tu = (TruckUtils)vehicle.GetComponent("TruckUtils");
			return tu;
		}
		else if(vehicle.tag == "Bomber")
		{
			TruckUtils tu = (TruckUtils)vehicle.GetComponent("TruckUtils");
			return tu;
		}
		else if(vehicle.tag == "ShieldTruck")
		{
			TruckUtils tu = (TruckUtils)vehicle.GetComponent("TruckUtils");
			return tu;
		}
		else if(vehicle.tag == "Tank")
		{
			TruckUtils tu = (TruckUtils)vehicle.GetComponent("TruckUtils");
			return tu;
		}
		return null;
	}
}
