using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

using UnityEngine.EventSystems;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		public Button gasPedal;
		public Button brakePedal;
		public bool gasPressing;
		public bool braking;
		public float brakeLevel;
		public float brakeMultiplier;

		EventTrigger gasButtonEventTrigger;
		EventTrigger brakePedalEventTrigger;
        private void Awake()
		{	GameObject canvas = GameObject.Find ("At");

			brakeLevel = PlayerPrefs.GetInt (PlayerPrefs.GetString("SelectedCarName","null") + "BrakeLevel",1);
			brakeMultiplier = Mathf.Pow (2, brakeLevel);
			gasPedal = canvas.transform.FindChild ("Gaz").GetComponent<Button>();
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

            // get the car controller
            m_Car = GetComponent<CarController>();
			gasPedal.onClick.AddListener (delegate {
				gasPressing = false;
			});
			brakePedal.onClick.AddListener (delegate {
				braking = false;
			});
        }


        private void FixedUpdate()
        {
			float h = CrossPlatformInputManager.GetAxis ("Horizontal");
			float v = CrossPlatformInputManager.GetAxis ("Vertical");
			if (PlayerPrefs.GetInt ("outoffuel", 0) != 1) {


			
				// pass the input to the car!

				//	float v = 0f;

				for (int i = 0; i < Input.touchCount; i++) {

					if (Input.GetTouch (i).phase != TouchPhase.Ended && gasPressing) {
						v = 5f;
					}
					if (Input.GetTouch (i).phase != TouchPhase.Ended && braking) {
			
						v = -50f * brakeLevel;
					}
				}
				if (this.GetComponent<Rigidbody> ().velocity.magnitude < 10f) {
					v = 5f;

				}
#if !MOBILE_INPUT
				float handbrake = CrossPlatformInputManager.GetAxis ("Jump");
				if (v < 0) {
					m_Car.m_Downforce = 1000;

				
				}
				if (v > 0) {
					m_Car.m_Downforce = 100;

				}

				m_Car.Move (h, v, v, handbrake);
#else
			if ( v<0) {
				m_Car.m_Downforce = 1000;
				
				
			}
			if(v>0){
				m_Car.m_Downforce = 100;
				
			}
            m_Car.Move(h, v, v, 0f);
#endif
			} else {

				if(this.GetComponent<Rigidbody>().velocity.z<0){
					Debug.Log(this.GetComponent<Rigidbody>().velocity.z);

					v = -5f;
					m_Car.Move (h, v, v, 0);

				}
				else{
					m_Car.Move(0,0,0,0);

				}

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
    }
}
