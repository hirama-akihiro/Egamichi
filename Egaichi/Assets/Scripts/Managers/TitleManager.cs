﻿using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!Application.isShowingSplashScreen && CrossInput.I.IsDown())
		{
			Application.LoadLevel("Menu");
			//FadeManager.Instance.LoadLevel("Menu", 0.5f);
		}
	}
}