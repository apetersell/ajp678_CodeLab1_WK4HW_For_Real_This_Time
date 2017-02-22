using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBeamBehavior : MonoBehaviour {

	public float beamSpeed;
	public float beamTimer; 
	public float beamLimit; 
	GameObject bossMeter; 
	BossHealth bh;  


	// Use this for initialization
	void Start () {

		bossMeter = GameObject.Find ("BossHealth");
		bh = bossMeter.GetComponent<BossHealth> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate( Vector2.right * beamSpeed * Time.deltaTime);
		beamTimer++;
		if (beamTimer >= beamLimit) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "BossBird")
		{
			bh.hurtBoss ();
		}

	}

}
