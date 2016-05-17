using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingController : MonoBehaviour {

	public GameObject Wall;
	public GameObject Obstacle;

	public int numOfObjects;

	//public RaycastController raycast;

	List<GameObject> wallObjects = new List<GameObject>();
	List<GameObject> obstacleObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
		// Create Walls
		//raycast = GetComponent<RaycastController>();
		for (int i = 0; i < numOfObjects; i++) {
			Debug.Log (i);
			GameObject obj = (GameObject)Instantiate (Wall);
			obj.SetActive (false);
			wallObjects.Add (obj);
		}

		// Create Obstacles
		for (int i = 0; i < 2; i++) {
			
			GameObject spike = (GameObject)Instantiate (Obstacle);
			spike.SetActive (false);
			obstacleObjects.Add (spike);

		}
			
	}
	
	//platforms
	public GameObject GetWallObject(){
	
		// om inte aktvierad returnera objektet
		for (int i = 0; i < wallObjects.Count; i++) {
		
			if (!wallObjects [i].activeInHierarchy) {
				
				return wallObjects [i];
			}
		
		
		}

		// If none was inactive
		GameObject obj = (GameObject)Instantiate (Wall);
		obj.SetActive (false);
		wallObjects.Add (obj);
		return obj;
	
	}

	//Spikes
	public GameObject GetObstacleObject(){
	
	
		// om inte aktvierad returnera objektet
		for (int i = 0; i < 2; i++) {

			if (!obstacleObjects [i].activeInHierarchy) {

				return obstacleObjects [i];
			}


		}

		// If none was inactive
		GameObject obj = (GameObject)Instantiate (Obstacle);
		obj.SetActive (false);
		obstacleObjects.Add (obj);
		return obj;
	
	
	}

}
