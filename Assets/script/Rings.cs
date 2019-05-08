using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rings : MonoBehaviour {
	public SpriteRenderer sp;
	public Sprite spi;
	public GameLoop gl;
	public int score;

	public Sprite originaimage;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		originaimage = sp.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		gl.ringstouched (score);
		//Color coli=	new Color (255, 255, 255, 50);
	
		sp.sprite = spi;
		var box=	GetComponent<BoxCollider2D> ();
		box.enabled = false;


	}


	public void reset(){
		GetComponent<BoxCollider2D> ().enabled=true;
		sp.sprite = originaimage;
	}
}
