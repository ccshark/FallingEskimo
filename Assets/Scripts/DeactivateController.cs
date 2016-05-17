using UnityEngine;
using System.Collections;

public class DeactivateController : MonoBehaviour {

	private GameObject generationPoint;


	void Start () {
		generationPoint = GameObject.Find ("DeactivatePoint");
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y > generationPoint.transform.position.y) {

			gameObject.SetActive (false);
		}

	}
}
