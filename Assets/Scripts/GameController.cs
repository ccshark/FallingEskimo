using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private float gameDistance = 0f; 

	public GameObject target;

	//public Text PointText;

	// Use this for initialization
	void Start () {

		gameDistance = 0f;

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		gameDistance = target.transform.position.y;
		//PointText.text = "Points: " +  (int)gameDistance;

	}



	public float getDistance(){

		return gameDistance;

	}


	//Restart Game
	public void restart(){

		Application.LoadLevel ("Map1");
	}






}
