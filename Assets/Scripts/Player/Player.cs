using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
	public float maxSpeed = 5f;
	public float jumpForce = 5f;
	public float jumpPushForce = 40;
	bool facingRight = true;
	bool wallJumped = false;
	bool wallJumping = false;
	//bool onWall = false;

	bool grounded;
	bool touchingWall;
	public Transform groundCheck;
	public LayerMask wallCheck = 8;
	public LayerMask whatIsGround;
	public float distToWall;

	//Gravity
	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	public float maxJumpHeight = .1f;
	public float minJumpHeight = .2f;
	public float timeToJumpApex = .2f;

	Controller2D controller;

	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(1 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);

		velocity = new Vector2(jumpPushForce * (facingRight ? -1:1), jumpForce);
		wallJumping = true;
		wallJumped = false;
	}

	void FixedUpdate () {
		if(wallJumped) {
			velocity = new Vector2(jumpPushForce * (facingRight ? -1:1), jumpForce);
			wallJumping = true;
			wallJumped = false;
			controller.collisions.onWall = false;
		}

		if(velocity.y < 0) {
			Debug.Log("wiiii!");
			wallJumped = false;
		}
		if (velocity.x > 0 && !facingRight) {
			Flip();
		}
		else if (velocity.x < 0 && facingRight) {
			Flip();
		}

		if (controller.collisions.onWall) {
			velocity.x = 0;
			if (facingRight) {
				
			}
				
			wallJumping = true;
			wallJumped = false;
			Debug.Log ("lel");
		}
	}

	void Update() {
		bool jump = Input.GetKeyDown (KeyCode.Space);
		if (jump && controller.collisions.onWall) {
			Debug.Log("wäll jump!");
			wallJumped = true;
			wallJumping = false;

		} 

		//gravity
		if (velocity.y <= -20) {
			velocity.y = -20;
		} else {
			velocity.y += gravity * Time.deltaTime;

		}
		controller.Move (velocity * Time.deltaTime, jump);
	}

	void Flip() {      
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
