﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadselection()
    {
        Application.LoadLevel(
            Application.loadedLevel +1);
    }
}
