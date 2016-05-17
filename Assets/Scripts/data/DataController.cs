using UnityEngine;
using System.Collections;

public class DataController : MonoBehaviour {

	public static DataController data;


	public bool inputType;
	public string name;

	// Use this for initialization
	void Awake () {
		if (data == null) {

			DontDestroyOnLoad (gameObject);
			data = this;
		} else if (data != this){
			Destroy (gameObject);

		}
	}
}