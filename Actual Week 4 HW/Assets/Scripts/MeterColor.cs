using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterColor : MonoBehaviour {

	public Color bright;
	public Color dark;
	public float lerpSpeed;
	private Color lerpingColor;
	GameObject meter;
	PowerMeter pm;
	Image i; 

	// Use this for initialization
	void Start () {
		meter = GameObject.Find ("Meter");
		pm = meter.GetComponent<PowerMeter> ();
		i = GetComponent<Image> (); 
	}
	
	// Update is called once per frame
	void Update () {
		lerpingColor = Color.Lerp(bright, dark, Mathf.PingPong(Time.time*lerpSpeed, 1));
		colorChange ();
		
	}

	void colorChange ()
	{
		if (pm.currentPower == pm.maxPower) 
		{
			i.color = lerpingColor;
		} else 
		{
			i.color = dark; 
		}
	}
}
