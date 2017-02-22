using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	GameObject meter;
	PowerMeter pm;

	// Use this for initialization
	void Start () {

		meter = GameObject.Find ("Meter");
		pm = meter.GetComponent<PowerMeter> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		pm.currentPower--; 

		if(pm.currentPower == 0) { 
			SceneManager.LoadScene("Level 1");
		}
		
	}
}
