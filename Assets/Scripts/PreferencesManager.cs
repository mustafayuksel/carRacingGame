using UnityEngine;
using System.Collections;

public class PreferencesManager{

	public string selectedCarName;
	public int moneyAmount;
	public string selectedLevelName;
	public int buggyPrice;
	public int sedanPrice;
	public int crazyVanPrice;
	public int crazySUVPrice;
	public int flatBedPrice;
	public int buggyMotorLevel;
	public int buggyFuelLevel;
	public int buggyBrakeLevel;
	public int sedanMotorLevel;
	public int sedanFuelLevel;
	public int sedanBrakeLevel;
	public int crazyVanMotorLevel;
	public int crazyVanFuelLevel;
	public int crazyVanBrakeLevel;
	public int flatMotorLevel;
	public int flatFuelLevel;
	public int flatBrakeLevel;
	public int crazySUVMotorLevel;
	public int crazySUVFuelLevel;
	public int crazySUVBrakeLevel;
	public int bombSkillLevel;
	public int killAllSkillLevel;
	public int killNearSkillLevel;
	public int shieldSkillLevel;
	public int buggyMinSpeed;
	public int sedanMinSpeed;
	public int crazySUVMinSpeed;
	public int flatBedMinSpeed;
	public int buggyMinFuel;
	public int sedanMinFuel;
	public int crazySUVMinFuel;
	public int flatBedMinFuel;
	public int ramMotorLevel;
	public int ramFuelLevel;
	public int ramBrakeLevel;
	public int ramPrice;
	public int nissanPrice;
	public int nissanMinSpeed;
	public int nissanMotorLevel;
	public int nissanBrakeLevel;
	public int nissanFuelLevel;
	public int nissanMinFuel;


	public int busPrice;
	public int busMinSpeed;
	public int busMotorLevel;
	public int busBrakeLevel;
	public int busFuelLevel;
	public int busMinFuel;

	public int tankExploderPrice;
	public int tankExploderMinSpeed;
	public int tankExploderMotorLevel;
	public int tankExploderBrakeLevel;
	public int tankExploderFuelLevel;
	public int tankExploderMinFuel;

	public int exploderPrice;
	public int exploderMinSpeed;
	public int exploderMotorLevel;
	public int exploderBrakeLevel;
	public int exploderFuelLevel;
	public int exploderMinFuel;


	public int crazyVanMinSpeed;
	public int crazyVanMinFuel;
	public string whichSceneToGo;
	public void init()
	{
		PlayerPrefs.SetInt ("L1meters", 0);
		PlayerPrefs.SetInt ("L2meters", 0);
		PlayerPrefs.SetInt ("L3meters", 0);
		PlayerPrefs.SetInt ("L4meters", 0);
		PlayerPrefs.SetInt ("L5meters", 0);
		whichSceneToGo = "characterSelect";
		selectedCarName = "Null";
		moneyAmount = 0;
		selectedLevelName = "L2";
		buggyPrice = 0;
		sedanPrice = 1000;
		crazyVanPrice = 2000;
		crazySUVPrice = 4000;
		flatBedPrice = 8000;
		ramPrice = 16000;
		nissanPrice = 10000;
		busPrice = 20000;
		tankExploderPrice = 30000;
		exploderPrice = 40000;

		crazyVanMinSpeed = 80;
		crazyVanMinFuel = 100;

		nissanMotorLevel = 1;
		nissanFuelLevel = 1;
		nissanBrakeLevel = 1;
		nissanMinSpeed = 100;
		nissanMinFuel = 200;

		busMotorLevel = 1;
		busFuelLevel = 1;
		busBrakeLevel = 1;
		busMinSpeed = 60;
		busMinFuel = 300;


		tankExploderMotorLevel = 1;
		tankExploderFuelLevel = 1;
		tankExploderBrakeLevel = 1;
		tankExploderMinSpeed = 30;
		tankExploderMinFuel = 500;

		exploderMotorLevel = 1;
		exploderFuelLevel = 1;
		exploderBrakeLevel = 1;
		exploderMinSpeed = 200;
		exploderMinFuel = 500;




		buggyMotorLevel = 1;
		buggyFuelLevel = 1;
			buggyBrakeLevel = 1;
		sedanMotorLevel = 1;
		sedanFuelLevel = 1;
		sedanBrakeLevel = 1;
		crazyVanMotorLevel = 1;
		crazyVanFuelLevel = 1;
		crazyVanBrakeLevel = 1;
		flatMotorLevel = 1;
		flatFuelLevel = 1;
		flatBrakeLevel = 1;
		crazySUVMotorLevel = 1;
		crazySUVFuelLevel = 1;
		crazySUVBrakeLevel = 1;
		bombSkillLevel = 1;
		killAllSkillLevel = 1;
		killNearSkillLevel = 1;
		shieldSkillLevel = 1;

		selectedCarName = PlayerPrefs.GetString ("SelectedCarName", "Null");
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 0);
		selectedLevelName = PlayerPrefs.GetString ("SelectedLevelName", "L2");
		buggyPrice = PlayerPrefs.GetInt ("buggyPrice",0);
		crazyVanPrice = PlayerPrefs.GetInt ("crazyVanPrice",2000);
		crazySUVPrice = PlayerPrefs.GetInt ("crazySUVPrice",8000);
		buggyMotorLevel = PlayerPrefs.GetInt ("buggyMotorLevel",1);
		buggyFuelLevel = PlayerPrefs.GetInt ("buggyFuelLevel",1);
		buggyBrakeLevel = PlayerPrefs.GetInt ("buggyBrakeLevel",1);



		crazyVanMotorLevel = PlayerPrefs.GetInt ("crazyVanMotorLevel",1);
		crazyVanFuelLevel = PlayerPrefs.GetInt ("crazyVanFuelLevel",1);
		crazyVanBrakeLevel = PlayerPrefs.GetInt ("crazyVanBrakeLevel",1);
		crazySUVMotorLevel = PlayerPrefs.GetInt ("crazySUVMotorLevel",1);
		crazySUVFuelLevel = PlayerPrefs.GetInt ("crazySUVFuelLevel",1);
		crazySUVBrakeLevel = PlayerPrefs.GetInt ("crazySUVBrakeLevel",1);
		bombSkillLevel = PlayerPrefs.GetInt ("bombSkillLevel",1);
		killAllSkillLevel = PlayerPrefs.GetInt ("killAllSkillLevel",1);
		killNearSkillLevel = PlayerPrefs.GetInt ("killNearSkillLevel",1);
		shieldSkillLevel = PlayerPrefs.GetInt ("shieldSkillLevel",1);
	    buggyMinSpeed =	PlayerPrefs.GetInt ("buggyMinSpeed", 90);
	    crazySUVMinSpeed = PlayerPrefs.GetInt ("crazySUVMinSpeed", 100);
		crazyVanMinSpeed =  PlayerPrefs.GetInt ("crazyVanMinSpeed", 80);
		buggyMinFuel = PlayerPrefs.GetInt ("buggyMinFuel", 120);
	    crazySUVMinFuel =	PlayerPrefs.GetInt ("crazySUVMinFuel", 150);
		//fgchjvjkb
		PlayerPrefs.SetString ("whichScene", whichSceneToGo);
		PlayerPrefs.SetInt ("buggyFuelCapacity", 60);
		PlayerPrefs.SetInt ("crazySUVFuelCapacity", 100);
		PlayerPrefs.SetString ("SelectedCarName", selectedCarName);
		PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		PlayerPrefs.SetString ("SelectedLevelName", selectedLevelName);
		PlayerPrefs.SetInt ("buggyPrice",buggyPrice);
		PlayerPrefs.SetInt ("crazyVanPrice",crazyVanPrice);
		PlayerPrefs.SetInt ("crazySUVPrice",crazySUVPrice);
		PlayerPrefs.SetInt ("buggyMotorLevel",buggyMotorLevel);
		PlayerPrefs.SetInt ("buggyFuelLevel",buggyFuelLevel);
		PlayerPrefs.SetInt ("buggyBrakeLevel",buggyBrakeLevel);
		PlayerPrefs.SetInt ("crazyVanMotorLevel",crazyVanMotorLevel);
		PlayerPrefs.SetInt ("crazyVanFuelLevel",crazyVanFuelLevel);
		PlayerPrefs.SetInt ("crazyVanBrakeLevel",crazyVanBrakeLevel);
		PlayerPrefs.SetInt ("crazySUVMotorLevel",crazySUVMotorLevel);
		PlayerPrefs.SetInt ("crazySUVFuelLevel",crazySUVFuelLevel);
		PlayerPrefs.SetInt ("crazySUVBrakeLevel",crazySUVBrakeLevel);
		PlayerPrefs.SetInt ("bombSkillLevel",bombSkillLevel);
		PlayerPrefs.SetInt ("killAllSkillLevel",killAllSkillLevel);
		PlayerPrefs.SetInt ("killNearSkillLevel",killNearSkillLevel);
		PlayerPrefs.SetInt ("shieldSkillLevel",shieldSkillLevel);
		PlayerPrefs.SetInt ("maxSpeed", 240);
		PlayerPrefs.SetInt ("maxFuel", 1000);
		PlayerPrefs.SetInt ("maxBrake", 5);
		PlayerPrefs.SetInt ("buggyMinSpeed", buggyMinSpeed);
		PlayerPrefs.SetInt ("sedanMinSpeed", sedanMinSpeed);
		PlayerPrefs.SetInt ("crazySUVMinSpeed", crazySUVMinSpeed);
		PlayerPrefs.SetInt ("crazyVanMinSpeed", 90);
		PlayerPrefs.SetInt ("buggyMinFuel", buggyMinFuel);
		PlayerPrefs.SetInt ("crazySUVMinFuel", crazySUVMinFuel);
		PlayerPrefs.SetInt ("busMinFuel", 300);
		PlayerPrefs.SetInt ("flatMinFuel", flatBedMinFuel);
		PlayerPrefs.SetInt ("buggyLocked", 0);
		PlayerPrefs.SetInt ("crazySUVLocked", 1);
		PlayerPrefs.SetInt ("brakeMin", 1);
		PlayerPrefs.SetInt ("crazyVanLocked", 1);
		PlayerPrefs.SetInt ("nissanLocked", 1);
		PlayerPrefs.SetInt ("busLocked", 1);
		PlayerPrefs.SetInt ("tankExploderLocked", 1);
		PlayerPrefs.SetInt ("exploderLocked", 1);

		PlayerPrefs.SetInt ("nissanPrice", nissanPrice);
		PlayerPrefs.SetInt ("busPrice", busPrice);
		PlayerPrefs.SetInt ("tankExploderPrice", tankExploderPrice);
		PlayerPrefs.SetInt ("crazyVanPrice", crazyVanPrice);
		PlayerPrefs.SetInt ("exploderPrice", exploderPrice);

		PlayerPrefs.SetInt ("nissanMotorLevel", nissanMotorLevel);
		PlayerPrefs.SetInt ("busMotorLevel", busMotorLevel);
		PlayerPrefs.SetInt ("tankExploderMotorLevel", tankExploderMotorLevel);
		PlayerPrefs.SetInt ("crazyVanMotorLevel", crazyVanMotorLevel);
		PlayerPrefs.SetInt ("exploderMotorLevel", exploderMotorLevel);

		PlayerPrefs.SetInt ("nissanFuelLevel", nissanFuelLevel);
		PlayerPrefs.SetInt ("busFuelLevel", busFuelLevel);
		PlayerPrefs.SetInt ("tankExploderFuelLevel", tankExploderFuelLevel);
		PlayerPrefs.SetInt ("crazyVanFuelLevel", crazyVanFuelLevel);
		PlayerPrefs.SetInt ("exploderFuelLevel", exploderFuelLevel);

		PlayerPrefs.SetInt ("nissanBrakeLevel", nissanBrakeLevel);
		PlayerPrefs.SetInt ("busBrakeLevel", busBrakeLevel);
		PlayerPrefs.SetInt ("tankExploderBrakeLevel", tankExploderBrakeLevel);
		PlayerPrefs.SetInt ("crazyVanBrakeLevel", crazyVanBrakeLevel);
		PlayerPrefs.SetInt ("exploderBrakeLevel", exploderBrakeLevel);


		PlayerPrefs.SetInt ("nissanMinSpeed", nissanMinSpeed);
		PlayerPrefs.SetInt ("busMinSpeed", busMinSpeed);
		PlayerPrefs.SetInt ("tankExploderMinSpeed", tankExploderMinSpeed);
		PlayerPrefs.SetInt ("crazyVanMinSpeed", crazyVanMinSpeed);
		PlayerPrefs.SetInt ("exploderMinSpeed", exploderMinSpeed);

		PlayerPrefs.SetInt ("nissanMinFuel", nissanMinFuel);
		PlayerPrefs.SetInt ("busMinFuel", busMinFuel);
		PlayerPrefs.SetInt ("tankExploderMinFuel", tankExploderMinFuel);
		PlayerPrefs.SetInt ("crazyVanMinFuel", crazyVanMinFuel);
		PlayerPrefs.SetInt ("exploderMinFuel", exploderMinFuel);



	




	
		PlayerPrefs.Save ();

	}
	public void reset()
	{
		PlayerPrefs.DeleteAll ();
		}

}
