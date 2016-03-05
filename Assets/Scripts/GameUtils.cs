using UnityEngine;
using System.Collections.Generic;

public static class GameUtils{

	private static GameObject destText;
	public static int score;
	public static int destination;
	public static Level currentLevel;
    static int currentLevelNumber;
	//static AnimateFlyingText af;
	public static float[] directions;
	public static void initialize()
	{
	   // resetPrefs ();
		currentLevelNumber = getCurrentLevelNumber ();
		currentLevel = new LevelManager ().allLevels [currentLevelNumber-1];
		//TextMesh tm = (TextMesh)levelText.GetComponent ("TextMesh");
		//tm.text = "Level " + currentLevel._levelNumber;
		destination = 0;
		directions = new float[] {6f,2f,-2f,-6f};

	}
	public static void update(float speed)
	{
//		GameObject destText = GameObject.FindWithTag ("ShowDestination");
//		destText.GetComponent<GUIText>().text = "Destination " + (int)(10000 - destination);
//		GameObject speedt = GameObject.Find("ShowSpeed");
	//	speedt.GetComponent<GUIText>().text = "Speed " + (int)(speed * 50);
		//destination -= speed;
		if (destination < 0) 
		{
			//score = 0;
			//levelUp();
		}

	}
	static int getCurrentLevelNumber()
	{
		int currentLevelNumber = PlayerPrefs.GetInt ("levelKey", 1);
		return currentLevelNumber;
	}
	static void setNextLevelNumber()
	{
		if (currentLevel._levelNumber == 21) 
		{
			PlayerPrefs.SetInt ("levelKey", 1);
				}
		else
		{
	
			PlayerPrefs.SetInt ("levelKey", ++currentLevel._levelNumber);
		}
	
		PlayerPrefs.Save ();
	}
	public static void writeScore()
	{
		/*
		GameObject text = GameObject.Find ("Empty");
		text.GetComponent<GUIText>().color = new Color (((float) (score)) / 100000,1f - ((float) (score))/500000, 0);
		text.GetComponent<GUIText>().text = "Score " +score;  */
	}
	public static void addBombBonus(int amount,Color c)
	{
		GameObject at = Resources.Load<GameObject>("BonusText");
		MonoBehaviour.Instantiate(at,new Vector3(0.5f,0.5f,0),Quaternion.identity);
		score += amount;
	}
	public static void addKillAllBonus()
	{
		GameObject at = Resources.Load<GameObject>("RedBonusText");
		MonoBehaviour.Instantiate(at,new Vector3(0.5f,0.5f,0),Quaternion.identity);
		score += 1000;
	}
	public static void addFlyingBonus(CarState state)
	{
		if (state == CarState.BeginToFly) 
		{
			score += 100;
			//GameObject go = Resources.Load<GameObject>("FlyingBonusText");
			//GameObject instance = MonoBehaviour.Instantiate(go,new Vector3(0.5f,0.5f,0f),Quaternion.identity) as GameObject;
		//	af = (AnimateFlyingText)instance.GetComponent("AnimateFlyingText");
		}
		else if(state == CarState.Flying)
		{
			score+= 100;
			//af.state = CarState.Flying;
		}
		else if(state == CarState.Landed)
		{
			//af.state = CarState.Landed;

		}

	}
	public static void constructLevel()
	{
		int currentLevelNumber = getCurrentLevelNumber ();
		LevelManager lm = new LevelManager ();
		currentLevel = lm.allLevels[currentLevelNumber - 1];
		GameObject go = GameObject.Find ("LevelText");
		TextMesh tm = (TextMesh)go.GetComponent ("TextMesh");
		tm.text = "Level " + currentLevel._levelNumber;
	}
	public static void addBonus(int amount)
	{
		GameObject at = Resources.Load<GameObject>("RedBonusText");
		MonoBehaviour.Instantiate(at,new Vector3(0.5f,0.5f,0),Quaternion.identity);
		score += amount;
	}
	public static ISkill getSkill(SkillIndex s)
	{
		switch (s) 
		{
		case SkillIndex.TntSkill:
			return new TntSkill();  
		case SkillIndex.ShieldSkill:
			return new ShieldSkill(PlayerPrefs.GetInt("shieldSkillLevel"));
		case SkillIndex.KillAllSkill:
			return new KillAllSkill(PlayerPrefs.GetInt("killAllSkillLevel"));
		default:
			return null;
		}

	}
	public static void levelUp()
	{
		setNextLevelNumber ();
		Application.LoadLevel ("carRaceMain");
	}
	public static void resetPrefs()
	{
		PlayerPrefs.DeleteAll ();
	}
}
