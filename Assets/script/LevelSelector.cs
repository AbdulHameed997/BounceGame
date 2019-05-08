using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {
	public int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void loadlevel(int level){


		Application.LoadLevel(level);


	}


	public class Levels{

		public string levelname;
		public int levelnumber;
	
	}

}
