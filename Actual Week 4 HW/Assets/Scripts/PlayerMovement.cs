using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public float moveSpeed;
	GameObject meter;
	PowerMeter pm;
	public static PlayerMovement player;
	private Vector2 fireLocation;
	public KeyCode fire;
	public GameObject beam; 

	// Use this for initialization
	void Start () {

		if (player == null){
			player = this; 
			DontDestroyOnLoad (this);
		}
		else
		{
			Destroy (gameObject);
		}

		meter = GameObject.Find ("Meter");
		pm = meter.GetComponent<PowerMeter> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		fireLocation = new Vector2 (transform.position.x, transform.position.y);
		moveBabyMove (up, Vector2.up);
		moveBabyMove (down, Vector2.down);
		moveBabyMove (right, Vector2.right);
		moveBabyMove (left, Vector2.left); 
		bladeBeamFire ();
		
	}

	void moveBabyMove (KeyCode key, Vector2 direction)
	{
		if (Input.GetKey(key)) 
		{
			transform.Translate( direction * moveSpeed * Time.deltaTime);
		}
				
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "DangerBird") 
		{
			pm.increaseMeter (); 
			Destroy (coll.gameObject); 
		}

		if (coll.gameObject.tag == "ScoringBird") 
		{
			Destroy (coll.gameObject);
		}
	}

	void bladeBeamFire ()
	{
		if (Input.GetKeyDown (fire)) {
			Instantiate (beam, fireLocation, Quaternion.identity);
		}
	}


}
