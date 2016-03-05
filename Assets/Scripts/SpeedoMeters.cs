using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedoMeters : MonoBehaviour {

	// Use this for initialization
	public RectTransform fuelShow;
	public RectTransform speedShow;
	public Text scoreText;
	public Text destText;
	public RectTransform popup;
	public Button gasPedal;
	public Button brakePedal;
	public bool isActive;
	CarUtils cu;
	public GameObject car;
	public float oldFuel;
	public Fuel fuel;
	public float consumption;
	public CarState state;
	Animator popupAnimator;

	void Start () {
		popupAnimator = popup.GetComponent<Animator> ();
		popup.gameObject.SetActive (false);
		//car = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
						car = GameObject.FindWithTag ("Player");
						cu = (CarUtils)GameObject.FindWithTag ("Player").GetComponent ("CarUtils");
			oldFuel  = cu.oldFuel;
			fuel = cu.fuel;
			consumption = cu.consumption;
			isActive = false;
				}
		fuel.capacity -= consumption * Time.deltaTime;
		float temp = Mathf.Abs (car.GetComponent<Rigidbody>().velocity.magnitude * 3f)/2;
//		Debug.Log (car.rigidbody.velocity.magnitude);
		speedShow.rotation = Quaternion.Euler (0f, 0f, -(-30f + temp) );
		float fuelderivative = (fuel.capacity - oldFuel) /(fuel.maxCapacity);
		fuelShow.Rotate (new Vector3 (0, 0, fuelderivative * 70));
		oldFuel = fuel.capacity;
	
	}
	public void makeActive()
	{
		isActive = true;
		}
	void showPopUp()
	{
		popup.gameObject.SetActive (true);
		popupAnimator.SetInteger("state",1);
		popup.FindChild("yes").GetComponent<Button>().onClick.AddListener(delegate{
			Application.LoadLevel("carRaceMain");});
	}
}
