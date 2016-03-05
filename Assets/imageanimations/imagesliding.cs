using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public struct LevelInfo
{
	public int index;
	public string name;
    public	int locked;
	public int price;
}

public class imagesliding : MonoBehaviour {
	public Text L1;
	public Text L2;
	public Text L3;
	public Text L4;
	public Text L5;
	//Animator popupAnimator1;
	public RectTransform popup;
	public Text moneyText;
	public Text [] texts;
	public Image[] images;
	LevelInfo[] levels = new LevelInfo[5];
	public RectTransform canvas;
	//Animator [] popupAnimator;
	Vector2 oldposition;
	public Button right, left;
	public int index;
	public Button ok;
	public Text score;
	int moneyAmount;


	// Use this for initialization
	void Start () {
		index = 0;
		for (int i = 0; i < images.Length; i++) {
			images[i].gameObject.SetActive(false);

		}
		images [0].gameObject.SetActive (true);
		if (Application.systemLanguage.ToString () == "Turkish") {
			score.text = "Rekor:";


		}

		L4.text = PlayerPrefs.GetInt ("L4meters", 0)+"m";
		L5.text = PlayerPrefs.GetInt ("L5meters", 0)+"m";

		//PlayerPrefs.DeleteAll ();
		//PreferencesManager pm = new PreferencesManager ();
		//pm.init ();

		//popupAnimator1 = popup.GetComponent<Animator> ();

		levels [0] = new LevelInfo ();
		levels [0].index = 0;
		levels [0].locked = 0;
		levels [0].name = "L1";
		levels [0].price = 0;
		levels [1] = new LevelInfo ();
		levels [1].index = 1;

		levels [1].name = "L2";
	

		levels [2] = new LevelInfo ();
		levels [2].index = 2;
		levels [2].name = "L3";


		levels [3] = new LevelInfo ();
		levels [3].index = 3;
	
		levels [3].name = "L4";

		levels [4] = new LevelInfo ();
		levels [4].index = 4;

		levels [4].name = "L5";
		//popupAnimator = new Animator[5];


		right.onClick.AddListener (()=>{
			for(int i = 0; i < images.Length;i++){
				if((i!=images.Length-1) && images[i].gameObject.activeSelf){
					images[i].gameObject.SetActive(false);
					images[i+1].gameObject.SetActive(true);
					index++;
					break;

				}
				else if(i==images.Length-1 && images[i].gameObject.activeSelf){
					images[i].gameObject.SetActive(false);
					images[0].gameObject.SetActive(true);
					index = 0;
					break;

				}

			}

		});
		left.onClick.AddListener (()=>{
			for(int i = 0; i < images.Length;i++){
				if((i!=0) && images[i].gameObject.activeSelf){
					images[i].gameObject.SetActive(false);
					images[i-1].gameObject.SetActive(true);
					index--;
					break;
					
				}
				else if(i==0 && images[i].gameObject.activeSelf){
					images[i].gameObject.SetActive(false);
					images[images.Length-1].gameObject.SetActive(true);
					index = 4;
					break;
					
				}
			}
		
			
		});

	}

	public void unlockSelectedLevel(int loadingLevelInfo)
	{
	   
			GameObject.Find("Advertisement").GetComponent<BannerAdvertisement>().bannerView.Destroy();
			Application.LoadLevel("loadingScene");
		PlayerPrefs.SetString("SelectedLevelName",levels[loadingLevelInfo].name);
		PlayerPrefs.SetInt("selectedLevelIndex",loadingLevelInfo);
		PlayerPrefs.SetString("whichScene",levels[loadingLevelInfo].name);
			PlayerPrefs.Save();
		}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("characterSelect");
		}

	}
}
