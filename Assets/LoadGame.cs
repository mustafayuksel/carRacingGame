﻿using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Application.LoadLevel (PlayerPrefs.GetString("whichScene","characterSelect"));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
