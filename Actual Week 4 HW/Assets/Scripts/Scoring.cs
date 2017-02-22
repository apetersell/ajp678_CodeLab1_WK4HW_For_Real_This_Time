using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
	public float score; 
	public static Scoring foreverManager;
	Text numerals; 


	// Use this for initialization
	void Start () {
		if(foreverManager == null){
			foreverManager = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}

		numerals = GetComponent<Text> ();
		
	} 
	
	// Update is called once per frame
	void Update () {

		score = Time.time; 
		numerals.text = Mathf.Round(score).ToString ();
		score = Mathf.Round (score);
	}
}
