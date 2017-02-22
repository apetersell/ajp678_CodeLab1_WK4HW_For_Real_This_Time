using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
	public float score; 
	public float finalScore;
	public static Scoring foreverManager;
	Text numerals; 
	GameObject bossHealth;
	BossHealth bh;
	public float timer; 


	// Use this for initialization
	void Start () {
		if(foreverManager == null){
			foreverManager = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}

		numerals = GetComponent<Text> ();
		bossHealth = GameObject.Find ("BossHealth");
		bh = bossHealth.GetComponent<BossHealth> ();
		
	} 
	
	// Update is called once per frame
	void Update () {



		if (bh.itsOver == false) 
		timer++; 
		{
			if (timer >= 30) {
				timer = 0;
				score++;
			}
		}

		if (bh.itsOver) 
		{
			finalScore = score; 
		}
		
//		score = Time.time; 

		numerals.text = Mathf.Round(score).ToString ();


	}
}
