using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreScript : MonoBehaviour {
	 SpriteRenderer sp;

	public Sprite spi,originalsp;
	public GameLoop gl;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		originalsp = sp.sprite;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		gl.setrestorepoint (transform);
		//Color coli=	new Color (255, 255, 255, 50);



		sp.sprite = spi;


	}

	public void reset(){
		sp.sprite =	originalsp;

		Debug.Log ("replace sp");

	}
}
