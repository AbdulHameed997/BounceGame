using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLives : MonoBehaviour {
	public int score;
	public GameLoop gl;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter2D(Collider2D col)
	{
		gl.addmorelives (score);
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;

	}

	public void reset(){
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<CircleCollider2D> ().enabled = true;

	}

}
