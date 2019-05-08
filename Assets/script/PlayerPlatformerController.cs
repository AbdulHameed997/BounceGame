using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerPlatformerController : PhysicsObject
{
    public bool canjump;
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    //	private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = CrossPlatformInputManager.GetAxis("Horizontal");

        //move.x = Input.GetAxis ("Horizontal");

        if (canjump && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (!canjump)
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool ("grounded", grounded);
        //animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
    public void EnlargeBall()
    {

        transform.localScale = new Vector3(2f, 2f, 2f);
    }


    public void Deflateball()
    {

        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void SetMOving()
    {

        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }


    public void setcan()
    {

        canjump = true;

    }
    public void setcanneg()
    {
        //Debug.Log ("false");
        canjump = false;

    }
}