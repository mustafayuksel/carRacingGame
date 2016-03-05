using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RollingPlatform : MonoBehaviour {

	// Use this for initialization
	float xStart;
	float xEnd;
	float yStart;
	float yEnd;
	int index;
	public Text text;
	public Button [] buttons;
	public Button right;
	public Button left;
	public bool galleryState;
	public bool tamirState;
	public bool ammoState;
	public List<Car> carList;
	public List<GameObject> allmodels;
	public GameObject car;
	public GameObject oldCar;
	public RectTransform garagePanel;
	public Slider speedProgress;
	public Slider fuelProgress;
	public Slider brakeProgress;
	public Slider engineProgress;
	public Slider fuelTankProgress;
	public Slider brakeLevelProgress;
	public Text motorLevelText;
	public Text brakeLevelText;
	public Text fuelLevelText;
	public Text moneyAmountText;
	public int skillMax;
	public RectTransform skillPanel;
	public Slider shieldSkillSlider;
	public Slider killAllSkillSlider;
	public RectTransform progressBarPanel;
	public RectTransform lockPanel;
	public Text moneyText;
	public Text priceText;
	public Button garageButton;
	public Button startButton;
	private int moneyAmount;
	public GameObject[] carList1;
	bool flag = false;
	public RectTransform popup;
	Animator popupAnimator1;
	public Button ok;
	void Awake()
	{
		//PlayerPrefs.DeleteAll ();
		popupAnimator1 = popup.GetComponent<Animator> ();
		galleryState = false;
		tamirState = false;
		ammoState = false;
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+"";
	//	PreferencesManager pm = new PreferencesManager ();
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 0);
	//	pm.reset ();
//		pm.init ();
		//PlayerPrefs.DeleteAll ();
		index = 0;
		skillMax = 5;
		allmodels = new List<GameObject> ();

		allmodels.Add (Resources.Load<GameObject> ("Models/Model_Misc_Buggy"));
		allmodels.Add (Resources.Load<GameObject> ("Models/crazybusmodel"));
		allmodels [1].gameObject.transform.position = new Vector3 (539.25f, 159.63f, -220.65f);
		allmodels.Add (Resources.Load<GameObject> ("Models/Model_Cars_SUV"));
		allmodels.Add (Resources.Load <GameObject>("Models/crazyvanmodel"));
	
		car = GameObject.Find ("Model_Misc_Buggy");
		oldCar = car;
		speedProgress.value = (float)PlayerPrefs.GetInt ("buggyMinSpeed", 1) / (float)PlayerPrefs.GetInt ("maxSpeed", 1);
		fuelProgress.value = (float)PlayerPrefs.GetInt ("buggyMinFuel", 1) / (float)PlayerPrefs.GetInt ("maxFuel");
		brakeProgress.value = (float)PlayerPrefs.GetInt ("buggyMinBrake", 1) / (float)PlayerPrefs.GetInt ("maxBrake", 1);
		carList1 [0].SetActive (true);

	}
	void Start () {
	}

	public void pushButton(Button buton){
		if (buton.colors.normalColor != buton.colors.pressedColor) {
			ColorBlock cb = buton.colors;
			Color temp = buton.colors.normalColor;
			Color temp2 = buton.colors.pressedColor;
			cb.normalColor = temp2;
			buton.colors = cb;
			for (int i = 0; i<buttons.Length; i++) {
				if (buttons [i] != buton) {
					cb = buttons [i].colors;
					cb.normalColor = temp;
					buttons [i].colors = cb;
				}

			}
		}

	}

	// Update is called once per frame
	void Update () {
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 0);
		if (carList [index].isLocked && skillPanel.gameObject.activeInHierarchy == false) {
						lockPanel.gameObject.SetActive (true);
			garageButton.gameObject.SetActive(false);
			startButton.gameObject.SetActive(false);
				} else {
			lockPanel.gameObject.SetActive(false);
			garageButton.gameObject.SetActive(true);
			startButton.gameObject.SetActive(true);
				}
		/*foreach (Touch touch in Input.touches) {

			if(touch.deltaPosition.x > 0.01)
			{
				this.transform.Rotate(new Vector3(0f,
				                                  -10f,0f),Space.World);
				carList1[index].transform.Rotate(new Vector3(0f,
				                                 -10f,0f),Space.World);
			}
		
				if(touch.deltaPosition.x < -0.01)
				{
				this.transform.Rotate(new Vector3(0f,
				                                 10f,0f),Space.World);
				carList1[index].transform.Rotate(new Vector3(0f,
				                                 10f,0f),Space.World);

			}


	
	}*/
}
	public void goRight()
	{
		if (index < carList1.Length - 1) {

			index++;
			carList1[index - 1].SetActive(false);
			carList1[index].SetActive(true);
			//car = Instantiate(allmodels[index],oldCar.transform.position,oldCar.transform.rotation) as GameObject;
			speedProgress.value = (float) (PlayerPrefs.GetInt (carList [index].name + "MinSpeed", 1))/ (float)PlayerPrefs.GetInt ("maxSpeed", 1);
			fuelProgress.value = (float) (PlayerPrefs.GetInt (carList [index].name + "MinFuel", 1))/ (float)PlayerPrefs.GetInt ("maxFuel",1);
			brakeProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinBrake", 1))/ (float)PlayerPrefs.GetInt ("maxBrake", 1);
		
			priceText.text = carList[index].price + "";
			//Destroy(oldCar);
			//oldCar = car;
			}
		if (!carList [index].isLocked) {
			engineProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "MotorLevel", 1)) / 5;
			fuelTankProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "FuelLevel", 1)) / 5;
			brakeLevelProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "BrakeLevel", 1)) / 5;
		}
		if (carList [index].isLocked) {
			garagePanel.gameObject.SetActive(false);
		}
		if (flag == true && !(carList [index].isLocked)) {
			garagePanel.gameObject.SetActive(true);

		}
				}

	public void goLeft()
	{
		if (index > 0) {
			
			index--;
			carList1[index + 1].SetActive(false);
			carList1[index].SetActive(true);
		//	car = Instantiate(allmodels[index],oldCar.transform.position,oldCar.transform.rotation) as GameObject;
			speedProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinSpeed", 1))/ (float)PlayerPrefs.GetInt ("maxSpeed", 1);
			fuelProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinFuel", 1))/ (float)PlayerPrefs.GetInt ("maxFuel");
			brakeProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinBrake", 1))/ (float)PlayerPrefs.GetInt ("maxBrake", 1);
			priceText.text = carList[index].price + "";
			Destroy(oldCar);
			oldCar = car;
			if (carList [index].isLocked) {
				garagePanel.gameObject.SetActive(false);
			}
		}
		if (!carList [index].isLocked) {
			engineProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "MotorLevel", 1)) / 5;
			fuelTankProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "FuelLevel", 1)) / 5;
			brakeLevelProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "BrakeLevel", 1)) / 5;
		}
		if (flag == true && !(carList [index].isLocked)) {
			garagePanel.gameObject.SetActive(true);
			
		}
	}
	public void deactiveGaragePanel()
	{
		flag = false;
		left.gameObject.SetActive (true);
		right.gameObject.SetActive (true);
		garagePanel.gameObject.SetActive (false);
		skillPanel.gameObject.SetActive (false);
		progressBarPanel.gameObject.SetActive (true);
		}
	public void activeGaragePanel()
	{
		flag = true;
		//lockPanel.gameObject.SetActive (true);
		left.gameObject.SetActive (true);
		right.gameObject.SetActive (true);
		skillPanel.gameObject.SetActive (false);
		progressBarPanel.gameObject.SetActive (false);
		garagePanel.gameObject.SetActive (true);
		carList[index].engine = new Engine(PlayerPrefs.GetInt(carList[index].name + "MotorLevel",1));
		//carList [index].fuelTank = new Fuel (PlayerPrefs.GetInt (carList [index].name + "MinFuel", 1000), PlayerPrefs.GetInt (carList [index].name + "FuelLevel", 1));
		carList [index].brake = PlayerPrefs.GetInt (carList [index].name + "BrakeLevel", 1);
//		motorLevelText.text = carList[index].engine._level+"";
//		brakeLevelText.text = carList [index].brake + "";
//		fuelLevelText.text = carList [index].fuelTank.level + "";
		//moneyAmountText.text = PlayerPrefs.GetInt ("MoneyAmount", 1)+"";
		if (!carList [index].isLocked) {
			engineProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "MotorLevel", 1)) / 5;
			fuelTankProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "FuelLevel", 1)) / 5;
			brakeLevelProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "BrakeLevel", 1)) / 5;
		}
		}
	public void increaseEngine()
	{
		if (moneyAmount < 10000) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		carList [index].increaseEngineLevel ();
		speedProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinSpeed", 1)) / (float)PlayerPrefs.GetInt ("maxSpeed", 1);
		Debug.Log("asd"+(PlayerPrefs.GetInt (carList [index].name + "MinSpeed", 1)));
		activeGaragePanel ();
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0) + "";
	}
	public void increaseFuel()
	{
		if (moneyAmount < 10000) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		carList [index].increaseFuelLevel ();
		fuelProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinFuel", 1)) / (float)PlayerPrefs.GetInt ("maxFuel", 1);

		activeGaragePanel ();
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+ "";

		}
	public void increaseBrake()
	{
		if (moneyAmount < 10000) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		carList [index].increaseBrakeLevel ();
		brakeProgress.value =  (float)(PlayerPrefs.GetInt (carList [index].name + "MinBrake", 1)) / (float)PlayerPrefs.GetInt ("maxBrake", 1);

		activeGaragePanel ();
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+ "";
	}
	public void activeSkillPanel()
	{
		flag = false;
		deactiveGaragePanel ();
		lockPanel.gameObject.SetActive (false);
		left.gameObject.SetActive (false);
		right.gameObject.SetActive (false);

		progressBarPanel.gameObject.SetActive (false);

		skillPanel.gameObject.SetActive (true);
	    shieldSkillSlider.value = 	(float)PlayerPrefs.GetInt("shieldSkillLevel",1) / (float)skillMax;
		killAllSkillSlider.value = (float)PlayerPrefs.GetInt ("killAllSkillLevel", 1) / (float)skillMax;
		}
	public void increaseShieldSkill()
	{
		if (moneyAmount < 10000) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		int shieldSkillLevel = PlayerPrefs.GetInt ("shieldSkillLevel", 1);
		if (shieldSkillLevel < 5 && moneyAmount>10000) {
			shieldSkillLevel++;
			moneyAmount-=10000;
			PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
			PlayerPrefs.SetInt("shieldSkillLevel",shieldSkillLevel);
			PlayerPrefs.Save();
			activeSkillPanel();
				}
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+ "";
	}

	public void increasekillAllSkill()
	{
		if (moneyAmount < 10000) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		int shieldSkillLevel = PlayerPrefs.GetInt ("killAllSkillLevel", 1);
		if (shieldSkillLevel < 5 && moneyAmount>10000) {
			shieldSkillLevel++;
			moneyAmount-=10000;
			PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
			PlayerPrefs.SetInt("killAllSkillLevel",shieldSkillLevel);
			PlayerPrefs.Save();
			activeSkillPanel();
		}
		moneyText.text = PlayerPrefs.GetInt ("MoneyAmount", 0)+ "";
	}
	public void startGame()
	{
		GameObject.Find("Advertisement").GetComponent<BannerAdvertisement>().bannerView.Destroy();
		PlayerPrefs.SetString ("SelectedCarName", carList [index].name);
		Application.LoadLevel ("imagesliding");

	}
	public void unlockCar()
	{
		moneyAmount = PlayerPrefs.GetInt ("MoneyAmount", 0);
		if (moneyAmount < carList [index].price) {
			popup.gameObject.SetActive (true);
			popupAnimator1.SetInteger ("state", 2);
			right.gameObject.SetActive (false);
			left.gameObject.SetActive (false);
			popupAnimator1.SetInteger ("state", 1);
			
			ok.onClick.AddListener (delegate {
				popup.gameObject.SetActive (false);
				right.gameObject.SetActive (true);
				left.gameObject.SetActive (true);
			});
		}
		if (moneyAmount - carList [index].price > 0) {
						carList [index].isLocked = false;
			moneyAmount -= carList[index].price;
			Debug.Log(carList[index].name);
			PlayerPrefs.SetInt(carList[index].name + "Locked",0);
			PlayerPrefs.SetInt("MoneyAmount",moneyAmount);
			PlayerPrefs.Save();
			moneyText.text = moneyAmount + "";
				}
		if (flag == true) {
			garagePanel.gameObject.SetActive(true);
			engineProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "MotorLevel", 1)) / 5;
			fuelTankProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "FuelLevel", 1)) / 5;
			brakeLevelProgress.value = (float)(PlayerPrefs.GetInt (carList [index].name + "BrakeLevel", 1)) / 5;

		}

		}

}
