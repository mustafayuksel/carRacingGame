using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Car : MonoBehaviour {
	
	public int topSpeed;
	public int fuel;
	public int fuelLevel;
	public int brake;
	public string name;
	public Engine engine;
	//public Fuel fuelTank;
	public bool isLocked;
	private int moneyAmount;
	public int price;
	public int engineLevel;



	void Start()
	{
		/*int carSavedBefore = PlayerPrefs.GetInt (name + "SavedBefore", 0);
		if (carSavedBefore == 0) {
			PlayerPrefs.SetInt (name + "Price", 0);
			PlayerPrefs.SetInt (name + "Brake", brake);
			PlayerPrefs.SetInt (name + "TopSpeed", topSpeed);
			PlayerPrefs.SetInt (name + "Fuel", fuel);
			PlayerPrefs.SetInt (name + "SavedBefore", 1);
			PlayerPrefs.Save ();
		} else {
			brake = PlayerPrefs.GetInt(name + "Brake",1);
			topSpeed = PlayerPrefs.GetInt(name + "TopSpeed",1);
			fuel = PlayerPrefs.GetInt(name + "Fuel",1);
		}  */
	topSpeed = PlayerPrefs.GetInt(name + "MinSpeed",1);
		fuel = PlayerPrefs.GetInt (name + "MinFuel", 1);
	brake = PlayerPrefs.GetInt (name + "BrakeLevel", 1);
		price = PlayerPrefs.GetInt (name + "Price", 1);
		fuelLevel = PlayerPrefs.GetInt (name + "FuelLevel", 1);
		//fuelTank = new Fuel (fuel,PlayerPrefs.GetInt(name + "FuelLevel",1));
		int locked = PlayerPrefs.GetInt (name + "Locked", 1);
		if (locked == 1) {
						isLocked = true;
				} else {
			isLocked = false;
				}
				
	}
	public void increaseEngineLevel()
	{
	    engineLevel = PlayerPrefs.GetInt (name + "MotorLevel", 1);
		
		int enginePrice = 10000;
	    moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 1);
		Debug.Log(PlayerPrefs.GetInt(name + "MotorLevel",1));
		PlayerPrefs.Save ();
		if (moneyAmount - enginePrice > 0 && engineLevel < 5) {
			engineLevel++;
			moneyAmount -= 10000;
			//engine = new Engine (engine._level + 1);
			save ();

				}

	}
	public void increaseFuelLevel()
	{

		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 1);
		if (moneyAmount - 10000 > 0 && fuelLevel < 5) {
			moneyAmount -= 10000;

			fuelLevel++;
			saveFuel();
		}
		
	}
	public void increaseBrakeLevel()
	{
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 1);
		int brakeLevel = PlayerPrefs.GetInt (name + "BrakeLevel", 1);
				if (brakeLevel < 5 && moneyAmount >= 10000) {

			brakeLevel++;
						PlayerPrefs.SetInt (name + "BrakeLevel", brakeLevel);
			moneyAmount -= 10000;
			PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
						PlayerPrefs.Save ();

						
				}
		}
	public void saveFuel()
	{
		float fuelAmount = (float)PlayerPrefs.GetInt (name + "MinFuel", 1);
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		PlayerPrefs.SetInt (name + "FuelLevel", fuelLevel);
		Debug.Log ("saveful" + fuelAmount);
		PlayerPrefs.SetInt(name + "MinFuel", (int)(fuelAmount * 1.1f));
		PlayerPrefs.Save ();
		}
	public void save()
	{
		float speed = (float)PlayerPrefs.GetInt (name + "MinSpeed", 1);
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		PlayerPrefs.SetInt (name + "MotorLevel", engineLevel);
		PlayerPrefs.SetInt (name + "MinSpeed", (int)(speed * 1.1f));
		PlayerPrefs.Save ();
	}
}
