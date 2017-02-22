using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
	public float score; 
	public float finalScore;
	Text numerals; 
	GameObject bossHealth;
	BossHealth bh;
	public float timer; 
	public GameObject endText;
	public GameObject endScore;
	Text finalWord;
	Text finalScoreDisplay;

	private const string PREF_BEST_TIME = "bestTimePref";

	private int bestTime = 30;

	public int BestTime 
	{
		get 
		{
			bestTime = PlayerPrefs.GetInt(PREF_BEST_TIME);
			return bestTime; 
		}
		set 
		{ 
			bestTime = value;
			PlayerPrefs.SetInt(PREF_BEST_TIME, bestTime);
		}
	}

	// Use this for initialization
	void Start () {

		numerals = GetComponent<Text> ();
		bossHealth = GameObject.Find ("BossHealth");
		bh = bossHealth.GetComponent<BossHealth> ();
		finalWord = endText.GetComponent<Text> (); 
		finalScoreDisplay = endScore.GetComponent<Text> ();
		
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
			finalScoreDisplay.text = finalScore.ToString ();
			if (finalScore <= BestTime) {
				finalWord.text = "You Win! NEW BEST TIME: ";
			} else {
					finalWord.text = "You Win! Your Time: ";
			}
		}
		
//		score = Time.time; 

		numerals.text = Mathf.Round(score).ToString ();


	}
}
