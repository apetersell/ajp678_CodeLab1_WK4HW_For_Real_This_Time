using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InfoSaver : MonoBehaviour {

	public int currentPlaySession;
	public float currentFinalTime;
	public static InfoSaver infosaver;
	GameObject timer;
	Scoring s;

	// Use this for initialization
	void Start () {
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
		
	}

	public void record ()
	{

	}
}
