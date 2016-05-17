using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {


	public Text highscore;
	// Use this for initialization
	void Start () {
		GetHighScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void LoadGame(){
	
		Application.LoadLevel ("scene1");
	
	
	}

	public void LoadSettings(){

		Application.LoadLevel ("Settings");


	}

	private void GetHighScore ()
	{


		string url = "http://perkkaproductions.com/unitytest/api.php?method=highscore";
		WWWForm form = new WWWForm ();

		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));

	}

	IEnumerator WaitForRequest (WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null) {


			highscore.text = "HIGHSCORE: " +www.text.ToString ();





		}  else {
			Debug.Log ("error");

		}     



	}
}

