using UnityEngine;
using System.Collections;

public class ShowShield : MonoBehaviour {

	// Use this for initialization
	public Texture2D shieldTexture;
	public Texture2D killNearIcon;
	public bool shieldFlag;
	public bool killNearFlag;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		if (shieldFlag) {
						GUI.DrawTexture (new Rect (128, 400, 64, 64), shieldTexture);
				}
		if (killNearFlag) {
						GUI.DrawTexture (new Rect (193, 400, 64, 64), killNearIcon);
				}
	}
}
