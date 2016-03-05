using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Tutorial : MonoBehaviour {
	public Button right, left;
	public Image[] tutorialList; 
	
	
	
	// Use this for initialization
	void Start () {
		right.onClick.AddListener (()=>{
			for(int i = 0; i < tutorialList.Length; i++){
				if(tutorialList[i].gameObject.activeSelf && (i != tutorialList.Length-1)){
					tutorialList[i].gameObject.SetActive(false);
					tutorialList[i+1].gameObject.SetActive(true);
					break;

				}
			

			}
		
			
		});
		left.onClick.AddListener (()=>{
			for(int i = 0; i < tutorialList.Length; i++){
				if(tutorialList[i].gameObject.activeSelf && (i != 0)){
					tutorialList[i].gameObject.SetActive(false);
					tutorialList[i-1].gameObject.SetActive(true);
					break;
					
				}

				
			}
		
			
		});
		
	}


	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Traffic Madness");
		}
		
	}
}
