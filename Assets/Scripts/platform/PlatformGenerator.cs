using UnityEngine;
using System.Collections;


public class PlatformGenerator : MonoBehaviour {

	public Transform activatePoint;

	public GameController gameController;


	public PoolingController theOjectPool;
	private float LeftWallPos;
	private float RightWallPos;
	private float ObstaclePos;

	// Use this for initialization
	void Start () {

		LeftWallPos = transform.position.x - 15f;
		RightWallPos = transform.position.x + 5f;
		ObstaclePos = transform.position.x - 14;


	}
	
	// Update is called once per frame
	void FixedUpdate () {



		if (activatePoint.position.y < transform.position.y) {
			
					GameObject LeftWall;
					LeftWall = theOjectPool.GetWallObject ();
					transform.position = new Vector3 (LeftWallPos ,transform.position.y - 15f, 0f);
					LeftWall.transform.position = transform.position;
							//newWall.transform.rotation = transform.rotation;
					LeftWall.gameObject.layer = 8;
					LeftWall.tag = "wall";
					LeftWall.SetActive (true);

					
					GameObject RightWall;
					RightWall = theOjectPool.GetWallObject ();
					transform.position = new Vector3 (RightWallPos ,transform.position.y, 0f);
			 		RightWall.transform.position = transform.position;
					RightWall.layer = 8;
					RightWall.tag = "wall";
					RightWall.SetActive (true);


			if (ObstacleSpawn()) {

					GameObject obstacle = theOjectPool.GetObstacleObject ();

					transform.position = new Vector3 (ObstaclePos, transform.position.y, 0f);

					obstacle.transform.position = transform.position;
					obstacle.transform.rotation = transform.rotation;
					obstacle.SetActive (true);

					}
				}

	
	}

	// Random when spawning obstacle :) 
	private bool ObstacleSpawn(){
	
		int ranNum = Random.Range (0, 6);

		if (ranNum == 1) {
		
			return true;
		}
	
		return false;
	}





}
