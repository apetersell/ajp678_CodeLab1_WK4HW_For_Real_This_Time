using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InfoSaver : MonoBehaviour {

	public int currentPlaySession;
	public float currentFinalTime;
	public static InfoSaver infosaver;
	public string newBestTime; 
	GameObject timer;
	Scoring s;
	StreamWriter sw;

	public string fileName = "recordedTimes.txt";

	// Use this for initialization
	void Start () {
		string finalFilePath = Application.dataPath + "/" + fileName;

		sw = new StreamWriter (finalFilePath, false); 


		if (infosaver == null){
			infosaver = this; 
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}

		timer = GameObject.Find ("Timer"); 
		s = timer.GetComponent<Scoring> (); 

	}
	
	// Update is called once per frame
	void Update () {

		currentPlaySession = s.PlaySession;
		currentFinalTime = s.FinalScore;

		if (s.FinalScore <= s.BestTime) {
			newBestTime = "NEW BEST TIME!";
		} else {
			newBestTime = "";
		}
		
	}

	public void record ()
	{
		sw.WriteLine ("Session: " + currentPlaySession + "  " + "Time: " + currentFinalTime + "  " + newBestTime);

		sw.Close ();
	}
}
