using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerMeter : MonoBehaviour {

	public float currentPower;
	public float maxPower;
	public float birdWorth;
	public Image content;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		handleBar ();
		
	}

	void handleBar ()
	{
		content.fillAmount = map (currentPower, maxPower);
	}

	private float map (float current, float max)
	{
		return current / max; 
	}

	public void increaseMeter ()
	{
		if (currentPower < maxPower) 
		{
			currentPower = currentPower + birdWorth;
		}
	}
}
