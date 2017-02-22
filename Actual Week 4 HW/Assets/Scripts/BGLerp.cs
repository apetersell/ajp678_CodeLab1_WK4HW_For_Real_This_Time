using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLerp : MonoBehaviour {

	Camera c;
	public Color bright;
	public Color dark; 
	private Color lerpingColor;
	public float lerpSpeed;

	// Use this for initialization
	void Start () {

		c = GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		lerpingColor = Color.Lerp(bright, dark, Mathf.PingPong(Time.time*lerpSpeed, 1));

		c.backgroundColor = lerpingColor;
	}
}
