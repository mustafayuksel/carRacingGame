using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarUtils : VehicleUtils {

	// Use this for initialization

	private string carName;
	private bool braking;
	private int maxHealth;
	public bool mobileController;
	private float totalMeters;
	private bool flagflag;
	public float boostCoolDown;
	public float consumption;
	public Fuel fuel;
	private CarState oldState;
	public ISkill currentSkill;
	bool usingSkill;
	Texture2D shieldTex;
	Engine engine;
	public RectTransform fuelGauge;
	public RectTransform speedGauge;
	public float oldSpeed;
	public float oldFuel;
	public Text scoreText;
	public Text destinationText;
	public RectTransform popup;
	Slider healthBar;
	public Button gasPedal;
	public Button brakePedal;
	public Button skillButton;
	Animator popupAnimator;
//	CarControllerV2 carController;
	bool gasFlag;
	float score;
	float destination;
	GameObject flyingText;
	bool flyingFlag;
	GameObject flyingInstance;
	bool gasPressing;
	EventTrigger gasButtonEventTrigger;
	EventTrigger brakePedalEventTrigger;
	public GameObject respawn;
	private float y;
	private float lockedRotation;
	private bool flyingFlag1;
	public float reverseTime;
	public bool paused;
	public AudioSource music;
	public Camera mainCamera;
	bool ismyfuelover;
	void Awake()
	{
		ismyfuelover = true;
		music  =GameObject.Find ("Main Camera").GetComponent<AudioSource>();
		Application.targetFrameRate = 60;
		paused = false;
		reverseTime = 2f;
		y = this.transform.position.y;
		PlayerPrefs.SetInt ("gameOver", 0);
		PlayerPrefs.Save ();
		respawn = GameObject.Find ("RespawnCube");
		consumption = 2;
		carName =  PlayerPrefs.GetString ("SelectedCarName");
		Debug.Log (PlayerPrefs.GetInt (carName + "MinFuel", 1));
		maxHealth = 400;
		totalMeters = 0f;
		flagflag = true;
		boostCoolDown = 0f;
//		carController = (CarControllerV2)this.gameObject.GetComponent ("CarControllerV2");

		//consumption = 0f;
		GameUtils.initialize ();
		engine = new Engine (PlayerPrefs.GetInt(carName +"MotorLevel"));
	//	eski//fuel = new Fuel ( PlayerPrefs.GetInt(carName + "FuelCapacity"), PlayerPrefs.GetInt(carName + "FuelLevel"));
		fuel = new Fuel (PlayerPrefs.GetInt(carName + "MinFuel"), 1);
		//fuel.maxCapacity = 2200;
		oldSpeed = 0;
		oldFuel = fuel.Capacity;
		GameObject canvas = GameObject.Find ("At");
		healthBar = (Slider)canvas.transform.FindChild ("Slider").GetComponent<Slider>();
		healthBar.maxValue = maxHealth;
		healthBar.minValue = 0;
		healthBar.value = health;
		popup = (RectTransform)canvas.transform.FindChild ("popup");
		scoreText = (Text)canvas.transform.FindChild ("Score").GetComponent ("Text");
		destinationText = (Text)canvas.transform.FindChild ("Destination").GetComponent ("Text");
		gasPedal = canvas.transform.FindChild ("Gaz").GetComponent<Button>();
		skillButton = canvas.transform.FindChild ("skill").GetComponent<Button> ();
		brakePedal = canvas.transform.FindChild ("Button").GetComponent<Button> ();
		gasButtonEventTrigger = gasPedal.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback = new EventTrigger.TriggerEvent();
		UnityEngine.Events.UnityAction<BaseEventData> call = new UnityEngine.Events.UnityAction<BaseEventData>(gasEnable);
		entry.callback.AddListener(call);
		gasButtonEventTrigger.triggers.Add(entry);
		brakePedalEventTrigger = brakePedal.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry1 = new EventTrigger.Entry();
		entry1.eventID = EventTriggerType.PointerDown;
		entry1.callback = new EventTrigger.TriggerEvent();
		UnityEngine.Events.UnityAction<BaseEventData> call1 = new UnityEngine.Events.UnityAction<BaseEventData>(brakEnable);
		entry1.callback.AddListener(call1);
		brakePedalEventTrigger.triggers.Add (entry1);
		fuelGauge = (RectTransform)canvas.transform.FindChild ("fuelshow");
		speedGauge = (RectTransform)canvas.transform.FindChild ("Speedshow");
		popupAnimator = popup.GetComponent<Animator> ();
		popup.gameObject.SetActive (false);
		gasFlag = true;
		gasPedal.gameObject.SetActive (true);
		brakePedal.gameObject.SetActive (true);
		scoreText.gameObject.SetActive (true);
		destinationText.gameObject.SetActive (true);
		skillButton.gameObject.SetActive (true);

	
	   
	}
	void Start () {
		flyingFlag = false;
				boostCoolDown = 0f;
				usingSkill = false;
				this.currentSpeed = 0f;
				this.minSpeed = 2f;
				this.maxSpeed = 4f;
				this.state = CarState.Idle;
				this.health = 100;
				speedCoolDown = 0.5f;
				currentSkill = new EmptySkill ();
				currentSkill.skillName = "Empty";
		engine.calculate ();
	
	
		gasPedal.onClick.AddListener (delegate {
			gasPressing = false;
		});
		brakePedal.onClick.AddListener (delegate {
						braking = false;
				});
		skillButton.onClick.AddListener (useSkill);
		//gasPressing = true;
		
	
	
		}
	
	// Update is called once per frame
	void Update () {	
		if (!paused) {
			float currentRotation = this.transform.rotation.eulerAngles.y;
			if (currentRotation > 181f || currentRotation < 179f) {
				reverseTime -= Time.deltaTime;
			} else {
				reverseTime = 2f;
			}
			if (reverseTime < 0f) {
				this.transform.position = new Vector3 (this.transform.position.x, respawn.transform.position.y, this.transform.position.z);
				this.transform.rotation = Quaternion.Euler (new Vector3 (0f, 180f, 0f));
				reverseTime = 2f;
			}

			/*
		if (y < this.transform.position.y) {
			flyingFlag1 = true;
			//lockedRotation = this.transform.rotation.eulerAngles.x;
		}
		else {
			flyingFlag1 = false;
		}
		if (flyingFlag1) {
			//this.transform.rotation = Quaternion.Euler(new Vector3(lockedRotation,this.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z));
			this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX;
		} else {
			this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationY;
			this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationZ;
			this.transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
		}   */

			healthBar.value = health;
//		Debug.Log (carController.speed);
			if (usingSkill) {
				useSkill ();
			}
			buttons ();
			//carController.motorInput = 5f;
			if (health > maxHealth) {
				health = maxHealth;
			}
			GameObject [] allTrucks = GameObject.FindGameObjectsWithTag ("Truck");
			foreach (GameObject truck in allTrucks) {
				if (Vector3.Distance (this.gameObject.transform.position, truck.gameObject.transform.position) < 20f) {
					truck.GetComponent<Rigidbody> ().freezeRotation = false;
				}
			}
			if (isGrounded () && flyingFlag) {
				flyingFlag = false;
			}
			if (!isGrounded () && !flyingFlag) {
				//flyingText = (GameObject)Resources.Load("FlyingBonusText");
//		flyingInstance =	Instantiate(flyingText) as GameObject;
				flyingFlag = true;
			}
			//if (this.transform.position.x > 9f || this.transform.position.x < - 9f) {
			//this.transform.position = new Vector3(0f,this.transform.position.y,this.transform.position.z);
			//this.transform.rotation = Quaternion.Euler(0f,180f,0f);
		
			//}
			if (fuel.Capacity <= 0f && (ismyfuelover)) {
				ismyfuelover = false;
				gasPedal.interactable = false;
				PlayerPrefs.SetInt("outoffuel",1);
				PlayerPrefs.Save();
			//	this.health = 0;
				PlayerPrefs.SetInt ("gameOver", 1);
				PlayerPrefs.Save ();
			}
			if (!isAlive ()) {
				showPopUp ();
				//GameObject go =(GameObject)Resources.Load("GameOverButton");
				//Instantiate(go);
				GenerateTraffic gt = GameObject.Find ("worldLoader").GetComponent<GenerateTraffic> ();
				for (int i=0; i < gt.poolNumber; i++) {
					if (gt.bombEffectsList [i].activeInHierarchy == false) {
						gt.bombEffectsList [i].transform.position = this.transform.position;
						gt.bombEffectsList [i].SetActive (true);
						gt.bombEffectsList [i].GetComponent<DestroyTimer> ().lifeTime = 1f;
						break;
					}
				}
				Destroy (this.gameObject);
				//this.gameObject.explode();
			
			}
			if (fuel.Capacity > 0f) {
				PlayerPrefs.SetInt("outoffuel",0);
				PlayerPrefs.Save();
			}
			boostCar (boostCoolDown);
			totalMeters += this.GetComponent<Rigidbody> ().velocity.magnitude / 100;
			GameUtils.destination = (int)totalMeters;
			destinationText.text = (int)totalMeters + "";
			if (fuel.Capacity > 0f) {
				fuel.Capacity -= consumption * Time.deltaTime;
			}
			if (state == CarState.Stopped && gasFlag) {

				gasFlag = false;
				showPopUp ();

			}


			//float fuelderivative = (fuel.Capacity - oldFuel) / (fuel.maxCapacity);
//			fuelGauge.Rotate (new Vector3 (0, 0, fuelderivative * 70));
			scoreText.text = (int)GameUtils.score + "";
			//useSkill ();
			currentSpeed = this.GetComponent<Rigidbody> ().velocity.magnitude;
			GameUtils.score += (int)(currentSpeed * currentSpeed * currentSpeed) / 100000;
			GameUtils.addFlyingBonus (state);
			GameUtils.update (this.currentSpeed);
			if (fuel.Capacity <= 0f && state != CarState.Stopped) {
				oldState = state;
				state = CarState.Stopping;
			}  
			if (fuel.Capacity > 0f && state == CarState.Stopping) {
				state = oldState;

			}
			oldFuel = fuel.Capacity;
		}
	}
	
	bool isGrounded()
	{

		return this.transform.position.y < 6f;
	  /* float distToGround = collider.bounds.extents.y;
		return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.2f);  */
	}  
	void useSkill()
	{
		if (currentSkill.skillName != "Empty" && !usingSkill &&
		    currentSkill.skillName != "Selecting")
		{
			
			currentSkill.use(this.gameObject,this.tag);
			if(currentSkill.isConsumed)
			{
				
				currentSkill.skillName = "Empty";
				GameObject skillp = GameObject.FindWithTag("SkillProvider");
				if(skillp)
				{
					skillp.gameObject.SetActive(false);
				}
			}
			if(currentSkill.lifeTime > 0)
			{
				usingSkill = true;
			}
		}
		if (usingSkill) {
			currentSkill.use(this.gameObject,this.tag);

			if(currentSkill.lifeTime <= 0)
			{
				usingSkill = false;
				currentSkill.skillName = "Empty";
				GameObject skillp = GameObject.FindWithTag("SkillProvider");
				if(skillp)
				{
					skillp.gameObject.SetActive(false);
				}
			}
			if(currentSkill.lifeTime <= 2 && currentSkill.skillName != "Empty")
			{
				SkillProviderBehaviour skillp = (SkillProviderBehaviour)GameObject.FindWithTag("SkillProvider").GetComponent<SkillProviderBehaviour>();
				skillp.blinking = true;
			}
		}
	}
	bool hasShield()
	{
		return health > 100;
	}
	bool usingKillNear()
	{
		return usingSkill;
	}
	void showPopUp()
	{
		popup.gameObject.SetActive (true);
		popupAnimator.SetInteger("state",1);
/*		popup.FindChild("yes").GetComponent<Button>().onClick.AddListener(delegate{
			Application.LoadLevel("carRaceMain");});*/
	}
	void boostCar(float lifeTime)
	{

		if (lifeTime > 0f) {
		
				}
		boostCoolDown -= Time.deltaTime;
	}
	void FixedUpdate () {
		//this.rigidbody.AddForce (Vector3.up * 1000f);


		if (!paused) {
			if (mobileController) {
				if (this.GetComponent<Rigidbody> ().velocity.magnitude > 10f) {
					this.transform.Translate (Input.acceleration.x, 0f, 0f);
				} else {
					this.transform.Translate (this.GetComponent<Rigidbody> ().velocity.magnitude * Input.acceleration.x / 10, 0f, 0f);
				}
		
			} else {
				if (this.GetComponent<Rigidbody> ().velocity.magnitude < 10f) {
					if (Input.GetKey (KeyCode.A)) {
						this.transform.Translate (this.GetComponent<Rigidbody> ().velocity.magnitude * -0.3f / 100, 0f, 0f);
					}
					if (Input.GetKey (KeyCode.D)) {
						this.transform.Translate (this.GetComponent<Rigidbody> ().velocity.magnitude * 0.3f / 100, 0f, 0f);
					} 
				} else {
					if (Input.GetKey (KeyCode.A)) {
						this.transform.Translate (-0.3f, 0f, 0f);
					}
					if (Input.GetKey (KeyCode.D)) {
						this.transform.Translate (0.3f, 0f, 0f);
					} 
				}
			}

		
	
			if (this.transform.position.x > respawn.transform.position.x + 7.5f) {
				this.transform.position = new Vector3 (respawn.transform.position.x + 7.5f, this.transform.position.y, this.transform.position.z);
			}
			if (this.transform.position.x < respawn.transform.position.x - 7.5f) {
				this.transform.position = new Vector3 (respawn.transform.position.x - 7.5f, this.transform.position.y, this.transform.position.z);
			}
			if (fuel.Capacity <= 0f && this.GetComponent<Rigidbody> ().velocity.magnitude <= 1f && flagflag) {
				showPopUp ();
				GameObject.Find("At").transform.FindChild("outoffuel").gameObject.SetActive(true);
				if(Application.systemLanguage.ToString() == "Turkish"){
					GameObject.Find("At").transform.FindChild("outoffuel").GetComponent<Text>().text = "Yakıtınız tükendİ";
				}
				flagflag = false;
			}
	
			/*	if (this.transform.rotation.eulerAngles.y < 179 || this.transform.rotation.eulerAngles.y > 181){
			this.transform.rotation = Quaternion.Euler (this.transform.rotation.x, 180f, this.transform.rotation.z);
				}
		if (this.transform.position.y > 2.15f) {
			this.GetComponent<Rigidbody>().freezeRotation = true;  
				}
		else
		{
			this.GetComponent<Rigidbody>().freezeRotation = false;
		}  */


		
		}
	}
	void OnTriggerEnter(Collider c)
	{

						if ( this.gameObject && c.tag == "TrapBonus") 
						{
								score += 1000;
								GameUtils.addBombBonus (0, Color.red);

						}  
					if (this.gameObject && c.tag == "MineBonus") {
			score += 500;
			GameUtils.addBombBonus(0,Color.red);
				}
		}
	void buttons()
	{
		for(int i = 0; i < Input.touchCount; i++){
			if( Input.GetTouch(i).phase != TouchPhase.Ended && gasPressing ){
//				carController.motorInput = 5f;
			}
			if(Input.GetTouch(i).phase != TouchPhase.Ended && braking)
			{
	//			carController.motorInput = -1f;
			}
			/*
			else if(  Input.GetTouch(i).phase == TouchPhase.Ended && gasPedalGUI.HitTest(Input.GetTouch(i).position)){
				motorInput = 0;
				gasPedalGUI.color = new Color(.5f, .5f, .5f, .35f);
			}
			
			if( Input.GetTouch(i).phase != TouchPhase.Ended && brakePedalGUI.HitTest( Input.GetTouch(i).position )){
				motorInput = Mathf.Lerp(motorInput, -1, Time.deltaTime * 10);
				brakePedalGUI.color = new Color(.5f, .5f, .5f, 1f);
			}else if( Input.GetTouch(i).phase == TouchPhase.Ended && brakePedalGUI.HitTest(Input.GetTouch(i).position)){
				motorInput = 0;
				brakePedalGUI.color = new Color(.5f, .5f, .5f, .35f);
			}
			*/
		}
}
	public void gasEnable(UnityEngine.EventSystems.BaseEventData baseEvent)
	{
		gasPressing = true;
		}
	public void brakEnable(UnityEngine.EventSystems.BaseEventData baseEvent)
	{
	
		braking = true;
		}
	public void reverse()
	{

	}
	public void pause()
	{
		paused = !paused;
		this.GetComponent<AudioSource> ().enabled = !this.GetComponent<AudioSource> ().enabled;
		music.enabled = !music.enabled;
	
	}
}
