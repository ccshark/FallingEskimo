using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller2D : RaycastController {
	//------------------------------------
	// Public properties
	//------------------------------------

	public CollisionInfo collisions;
	[HideInInspector]
	public Vector2 playerInput;

	public Vector3 spawnPoint;

	//------------------------------------
	// Constructor
	//------------------------------------
	public override void Start() {
		base.Start ();
		collisions.faceDir = 1;
	}
	
	public void Move(Vector3 velocity, bool standingOnPlatform) {
		Move (velocity, Vector2.zero, standingOnPlatform);
	}

	public void Move(Vector3 velocity, Vector2 input, bool standingOnPlatform = false) {
		UpdateRaycastOrigins ();
		collisions.Reset ();
		collisions.velocityOld = velocity;
		playerInput = input;

		if (velocity.x != 0) {
			collisions.faceDir = (int)Mathf.Sign(velocity.x);
		}

		HorizontalCollisions (ref velocity);
		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}

		transform.Translate (velocity);

		if (standingOnPlatform) {
			collisions.below = true;
		}
	}

	/**
	 *  Horizontal Collisions
	 */
	void HorizontalCollisions(ref Vector3 velocity) {
		float directionX = collisions.faceDir;
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;

		if (Mathf.Abs(velocity.x) < skinWidth) {
			rayLength = 2*skinWidth;
		}
		
		for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = (directionX == -1)?raycastOrigins.bottomLeft:raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength,Color.red);

			if (hit) {

				if (hit.distance == 0) {
					continue;
				}
			
				float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

				if (hit.collider.tag == "wall") {
					collisions.onWall = true;
				}	
			}
		}
	}


	/**
	 *  Vertical Collisions
	 */
	void VerticalCollisions(ref Vector3 velocity) {
	/*	float directionY = Mathf.Sign (velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth;

		for (int i = 0; i < verticalRayCount; i ++) {
			Vector2 rayOrigin = (directionY == -1)?raycastOrigins.bottomLeft:raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength,Color.red);

			if (hit) {
				velocity.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;
			}
		} */
	}

	//Player is dead
	/* public IEnumerator spawnWait()
	{
		collider.transform.position = spawnPoint;
		//collider. = -2;
		yield return new WaitForSeconds(1f);
		collisions.playerDead = false;
	}  */

	//Collision info struct.
	public struct CollisionInfo {
		public bool above, below;
		public bool left, right;

		public Vector3 velocityOld;
		public int faceDir;

		public bool onWall;
		public bool playerDead;


		//Reset struct data.
		public void Reset() {
			above = below = false;
			left = right = false;

			//onWall = false;
		}
	}

}
