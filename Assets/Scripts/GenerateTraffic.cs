using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections.Generic;
using GoogleMobileAds.Api;
public class GenerateTraffic : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> bombEffectsList;
	public List<GameObject> tntList;
	public List<GameObject> boxList;
	public List<GameObject> fuelBoxList;
	public List<GameObject> trapList;
	public List<GameObject> enemyList;
	public List<GameObject> rampList;
	public List<GameObject> worldList;
	public List<GameObject> bombSoundList;
	public List<GameObject> boxAnimationList;


	public GameObject skillProvider;
	public GameObject bombEffect;
	public GameObject tnt;
	public GameObject box;
	public GameObject fuelBox;
	public GameObject trap;
	public GameObject enemy;
	public GameObject ramp;
	public GameObject world;
	public GameObject bombSound;
	public GameObject boxAnimation;
	public GameObject bomb;




	public int poolNumber;

	public float tntrandomness;
	public float boxrandomness;
	public float traprandomness;
	public float enemyrandomness;
	public float ramprandomness;
	public float fuelrandomness;

	public float tntyposition;
	public float boxyposition;
	public float trapyposition;
	public float fuelyposition;
	public float enemyyposition;
	public float rampyposition;


	public float trafficDensity;
	public float minZ;
	public float maxZ;
	public float [] possibleX;
	private GameObject around;
	public GameObject what;
	public float yPosition;
	public float xRotation;
	public float yRotation;
	public float zRotation;
	public float possibleXMin;
	public float possibleXmaX;
	RectTransform popup;
	public bool gameOver;
	GameObject car;
	CarUtils utils;
	RectTransform canvas;
	Text destinationText;
	bool checkflag;
	bool flag2;
	public Text scoreType;
	public Text destinationType;
	public Text score;
	public Text destination;
	public Text speed;
	public Text speedText;
	public Text fuelText;
	public Text fuel;
	public Button gaz;
	public Button fren;
	public Button skill;
	public bool firstLevel;
	bool flag3 = false;
	bool paused = false;
	InterstitialAd interstitial;

	public float sec = 2f;
	void Start () {
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-1847727001534987/4348561755";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
			interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
			AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
			interstitial.LoadAd(request);
		skillProvider = (GameObject)Instantiate (skillProvider);
		skillProvider.SetActive (false);
	
		for (int i=0; i < 3; i++) {
			boxAnimationList.Add(boxAnimation);
			boxAnimationList[i].SetActive(false);
		}
			for (int i=0; i < 3; i++) {
				worldList.Add ((GameObject)Instantiate (world));
			worldList[i].gameObject.SetActive(false);
		
		}
		for (int i =0; i < poolNumber; i++) {
			bombEffectsList.Add((GameObject)Instantiate(bombEffect));
			tntList.Add((GameObject)Instantiate(tnt));
			boxList.Add ((GameObject)Instantiate(box));
			fuelBoxList.Add((GameObject)Instantiate(fuelBox));
			trapList.Add((GameObject)Instantiate(trap));
			enemyList.Add((GameObject)Instantiate(enemy));
			rampList.Add((GameObject)Instantiate(ramp));
			bombSoundList.Add((GameObject)Instantiate(bombSound));


			bombEffectsList[i].SetActive(false);
			tntList[i].SetActive(false);
			boxList[i].SetActive(false);
			fuelBoxList[i].SetActive(false);
			trapList[i].SetActive(false);
			enemyList[i].SetActive(false);
			rampList[i].SetActive(false);
			bombSoundList[i].SetActive(false);
			
		}

		around = GameObject.FindWithTag ("Player");

		checkflag = false;
		flag2 = false;
	}
	void Awake(){
		car = GameObject.FindWithTag ("Player");


	}
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag ("Player") != null) {
		car = GameObject.FindWithTag ("Player");
			utils = (CarUtils)car.GetComponent ("CarUtils");
		}
		speed.text = utils.currentSpeed.ToString ("f1");
		fuel.text = utils.fuel.capacity.ToString("f1");
		if (!paused) {
			if (!flag3) {
				flag3 = true;
				around = GameObject.FindWithTag ("Player");
			}
			sec -= Time.deltaTime;
		    
			if (sec < 0) {
				if (GameObject.FindWithTag ("Player") != null && checkflag == false) {

					car = GameObject.FindWithTag ("Player");
					utils = (CarUtils)car.GetComponent ("CarUtils");
					popup = utils.popup;
					destinationText = utils.destinationText;
					checkflag = true;

				}
				if (gameOver && ((utils != null && !(utils.isAlive ()) && flag2 == false) || PlayerPrefs.GetInt ("gameOver", 0) == 1)) {
					if(PlayerPrefs.GetInt(Application.loadedLevelName+"meters",0)<GameUtils.destination){
						PlayerPrefs.SetInt(Application.loadedLevelName+"meters",GameUtils.destination);

					}
					PlayerPrefs.SetInt("gameOver",0);
					PlayerPrefs.Save();


					int randomVariable = Random.Range(0,4);
					if(randomVariable != 0){
						interstitial.Show();
					}
					scoreType.gameObject.SetActive (false);
					speed.gameObject.SetActive(false);
					speedText.gameObject.SetActive(false);
					destinationType.gameObject.SetActive (false);
					score.gameObject.SetActive (false);
					destination.gameObject.SetActive (false);
					gaz.gameObject.SetActive (false);
					fren.gameObject.SetActive (false);
					skill.gameObject.SetActive (false);
					fuel.gameObject.SetActive(false);
					fuelText.gameObject.SetActive(false);
					popup.FindChild ("score").GetComponent<Text> ().text = GameUtils.score + "";
					StartCoroutine ("myMethod");
					flag2 = true;
			
				}
				if (around && traprandomness !=0) {
					float maxZ = around.transform.position.z - 100;
					float minZ = around.transform.position.z - 250;
					generate (minZ, maxZ);

					minZ = around.transform.position.z + 10;
					maxZ = around.transform.position.z + 250;
					destroy(minZ,maxZ);

					traprandomness = 1;
					enemyrandomness = (float)(GameUtils.destination/2) / 100000;
				}

			}
		}
		 
	}

	IEnumerator myMethod() {
	
		yield return new WaitForSeconds(2);
		popup.FindChild ("destination").GetComponent<Text>().enabled = true;
		popup.FindChild ("destinationText").GetComponent<Text> ().enabled = true;
		popup.FindChild ("destinationText").GetComponent<Text> ().text = GameUtils.destination+"";

		popup.FindChild ("Arrow").GetComponent<Image>().enabled = true;
		popup.FindChild ("money1").GetComponent<Text>().enabled = true;
		popup.FindChild ("MoneyImage").GetComponent<Image>().enabled = true;
		popup.FindChild ("money1").GetComponent<Text> ().text = GameUtils.destination / 10+"";
		yield return new WaitForSeconds(1);
		popup.FindChild ("Bonus").GetComponent<Text>().enabled = true;
		popup.FindChild ("bonusText").GetComponent<Text> ().enabled = true;
		popup.FindChild ("Arrow2").GetComponent<Image>().enabled = true;
		popup.FindChild ("money2").GetComponent<Text>().enabled = true;
		popup.FindChild ("MoneyImage1").GetComponent<Image>().enabled = true;

		popup.FindChild ("bonusText").GetComponent<Text> ().text = GameUtils.score+"";
		popup.FindChild ("money2").GetComponent<Text> ().text = GameUtils.score / 100 + "";
		int money = GameUtils.score / 100 + GameUtils.destination / 10;
		PlayerPrefs.SetInt("MoneyAmount",PlayerPrefs.GetInt("MoneyAmount",0)+money);
		PlayerPrefs.Save ();
		popup.FindChild ("Garage").GetComponent<Button> ().onClick.AddListener (delegate {
			GameUtils.score = 0;
			PlayerPrefs.SetString("whichScene","characterSelect");
			PlayerPrefs.Save();
			Application.LoadLevel ("loadingScene");
		});
		popup.FindChild("MainMenu").GetComponent<Button>().onClick.AddListener(delegate {
			GameUtils.score = 0;
			PlayerPrefs.SetString("whichScene","Traffic Madness");
			PlayerPrefs.Save();
			Application.LoadLevel("loadingScene");
		});
		popup.FindChild("PlayAgain").GetComponent<Button>().onClick.AddListener(delegate {
			//GameObject.Find("AdvertisementTop").GetComponent<AdvertisementTopBanner>().gameObject.SetActive(true);
			//GameObject.Find("AdvertisementTop").GetComponent<AdvertisementTopBanner>().bannerView.Destroy();
			//GameObject.Find("AdvertisementTop").SetActive(false);
			GameUtils.score = 0;
			PlayerPrefs.SetString("whichScene",Application.loadedLevelName);
			PlayerPrefs.Save();
			Application.LoadLevel(Application.loadedLevel);
		});
	}
	void destroy(float minz,float maxz)
	{
		foreach (GameObject trap in trapList) {
			if(trap.gameObject.transform.position.z > minz) //|| trap.gameObject.transform.position.z > maxz)
			{
				trap.SetActive(false);
			}	
		}

		foreach (GameObject tnt in tntList) {
			if(tnt.gameObject.transform.position.z > minz) //|| tnt.gameObject.transform.position.z > maxz)
			{
				tnt.SetActive(false);
			}	
		}
		foreach (GameObject truck in enemyList) {
			if(truck.gameObject.transform.position.z > minz) //|| truck.gameObject.transform.position.z > maxz)
			{
				truck.SetActive(false);
			}	
		}


	}


  void generate(float minZ,float maxZ)
	{
		float f = Random.Range (0f, 1f);

		if (f < traprandomness) {
			for(int i =0; i < poolNumber; i++)
			{
				if(trapList[i].activeInHierarchy == false)
				{
					Debug.Log("trap üret");
					float j = Random.Range(possibleXMin,possibleXmaX);
					float posX = j;
					float posY = trapyposition;
					float posZ = Random.Range(minZ,maxZ);
					trapList[i].gameObject.transform.position = new Vector3(posX,posY,posZ);
					trapList[i].gameObject.transform.rotation = Quaternion.identity; 
					trapList[i].gameObject.SetActive(true);
					trapList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					break;
				}
			}
		}
		f = Random.Range (0f, 1f);
		if (f < boxrandomness) {
			for(int i =0; i < poolNumber; i++)
			{
				if(boxList[i].activeInHierarchy == false)
				{
					Debug.Log("box üret");

					float j = Random.Range(possibleXMin,possibleXmaX);
					float posX = j;
					float posY = boxyposition;
					float posZ = Random.Range(minZ,maxZ);
					boxList[i].gameObject.transform.position = new Vector3(posX,posY,posZ);
					boxList[i].gameObject.transform.rotation = Quaternion.identity; 
					boxList[i].gameObject.SetActive(true);
					boxList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					break;
					
				}		
			}
		}
		f = Random.Range (0f, 1f);
		if (f < fuelrandomness) {
			for(int i =0; i < poolNumber; i++)
			{
				if(fuelBoxList[i].activeInHierarchy == false)
				{
					Debug.Log("fuel üret");

					float j = Random.Range(possibleXMin,possibleXmaX);
					float posX = j;
					float posY = fuelyposition;
					float posZ = Random.Range(minZ,maxZ);
					fuelBoxList[i].gameObject.transform.position = new Vector3(posX,posY,posZ);
					fuelBoxList[i].gameObject.transform.rotation = Quaternion.identity; 
					fuelBoxList[i].gameObject.SetActive(true);	
					fuelBoxList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					break;

				}
			}
		}	
		f = Random.Range (0f, 1f);
		if (f < enemyrandomness) {
			for(int i =0; i < poolNumber; i++)
			{
				if(enemyList[i].activeInHierarchy == false)
				{
					Debug.Log("enemy üret");

					float j = Random.Range(possibleXMin,possibleXmaX);
					float posX = j;
					float posY = enemyyposition;
					float posZ = Random.Range(minZ,maxZ);
					enemyList[i].gameObject.transform.position = new Vector3(posX,posY,posZ);
					enemyList[i].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
					enemyList[i].gameObject.SetActive(true);
					enemyList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					enemyList[i].gameObject.GetComponent<TruckUtils>().health = 100;
					break;
				}
			}
		}
		f = Random.Range (0f, 1f);
		if (f < ramprandomness) {
			for(int i =0; i < poolNumber; i++)
			{
		
				if(rampList[i].activeInHierarchy == false)
				{
					Debug.Log("ramp üret");

					float j = Random.Range(possibleXMin,possibleXmaX);
					float posX = j;
					float posY = rampyposition;
					float posZ = Random.Range(minZ,maxZ);
					rampList[i].gameObject.transform.position = new Vector3(posX,posY,posZ);
					rampList[i].gameObject.transform.rotation = Quaternion.Euler(new Vector3(-75f,0f,0f));
					rampList[i].gameObject.SetActive(true);
					rampList[i].gameObject.GetComponent<DestroyTimer>().lifeTime = 20f;
					break;
				}
			}
		}
				
		}
	public void pause()
	{
		if (Time.timeScale <= 0f) {
			Time.timeScale = 1f;
		} else {
			Time.timeScale = 0f;
		}
		paused = !paused;
		around.GetComponent<CarUtils> ().pause ();

		if (GameObject.Find ("At").transform.FindChild ("pausePanel").gameObject.activeInHierarchy) {
			GameObject.Find ("At").transform.FindChild ("pausePanel").gameObject.SetActive (false);
		} else {
			GameObject.Find ("At").transform.FindChild ("pausePanel").gameObject.SetActive (true);
		}
	}
}
