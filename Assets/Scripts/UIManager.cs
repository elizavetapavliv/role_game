﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static UIManager instance;
	public static UIManager MyInstance{
		get {
			if (instance == null) {
				instance = FindObjectOfType<UIManager> ();
			}
			return instance;
		}
	}

	public void UpdateStackSize(IClickable clickable){
		if (clickable.MyCount == 0) {
			clickable.MyIcon.color = new Color (0, 0, 0, 0);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
