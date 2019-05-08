using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelCompleted : MonoBehaviour {
	GameLoop gl;
	// Use this for initialization
	void Start () {

		gl=	GameObject.Find ("GameLoop").GetComponent<GameLoop>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			gl.levelcompleted ();

		}
	}

}
