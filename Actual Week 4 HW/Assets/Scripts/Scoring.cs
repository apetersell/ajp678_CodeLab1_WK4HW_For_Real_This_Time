using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
	public int score; 
	public static Scoring foreverManager;

	// Use this for initialization
	void Start () {
		if(foreverManager == null){
			foreverManager = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore (int scoreAmount) 
	{
		score = score + scoreAmount;
	}
}
