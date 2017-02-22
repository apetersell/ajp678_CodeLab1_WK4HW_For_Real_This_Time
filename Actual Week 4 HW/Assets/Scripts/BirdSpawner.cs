using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour {

	public float timerLimit;
	public float timer;
	public GameObject bird;
	private Vector2 randomLocation; 
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		randomLocation = new Vector2 (Random.Range (minX, maxX), Random.Range (minY, maxY));  
		
		timer++; 
		if (timer >=timerLimit)
		{
			timer = 0;
			Instantiate (bird, randomLocation, Quaternion.identity);
		}
		
	}
}
