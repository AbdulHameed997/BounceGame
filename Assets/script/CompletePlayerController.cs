using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;


public class CompletePlayerController : MonoBehaviour {
	bool isjumping=false;
	public float speed;  
	public float upspeed;
	//Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.

		float moveHorizontal =	CrossPlatformInputManager.GetAxis ("Horizontal");

		//float moveHorizontal = Input.GetAxis ("Horizontal");

	//	Debug.Log (moveHorizontal);

		//Store the current vertical input in the float moveVertical.
		float moveVertical =	CrossPlatformInputManager.GetAxis ("Vertical");
		//Debug.Log ("moveVertical "+moveVertical);
		//float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.

	//	gameObject.GetComponent<Rigidbody2D> ().isKinematic =false;




		if (Input.GetKey(KeyCode.T))
		{
			ballMove();
		}
		if (Input.GetKey (KeyCode.D)) {
			moveHorizontal=1f;
		}

		if (Input.GetKey (KeyCode.A)) {
			moveHorizontal=-1f;
		}
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);

	}
	public	void ballMove()
	{
		if (!isjumping) {
			isjumping = true;
			Debug.Log ("clicked");
			rb2d.AddForce (new Vector2 (0, upspeed), ForceMode2D.Impulse);

		}

		//rb2d.AddForce(new Vector2(0f, upspeed), ForceMode2D.Force);
	}

	public void stopmotion(){
		Debug.Log ("Button Released");

		Vector2 vel = Vector2.zero;
		rb2d.velocity = vel;

		gameObject.GetComponent<Rigidbody2D> ().isKinematic =true;
	}


	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.CompareTag ("ground")) {


			rb2d.velocity = Vector2.zero;
			isjumping = false;
		}
	}

	public void EnlargeBall(){

		transform.localScale = new Vector3 (2f,2f,2f);
	}


	public void Deflateball(){

		transform.localScale = new Vector3 (1f, 1f, 1f);
	}
		public void SetMOving(){

			gameObject.GetComponent<Rigidbody2D> ().isKinematic =false;
		}

}
