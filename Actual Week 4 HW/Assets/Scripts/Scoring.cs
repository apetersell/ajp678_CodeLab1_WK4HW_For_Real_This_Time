﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public float score; 
	Text numerals; 
	GameObject bossHealth;
	BossHealth bh;
	public float timer; 
	public GameObject endText;
	public GameObject endScore;
	Text finalWord;
	Text finalScoreDisplay;

	private const string PREF_BEST_TIME = "bestTimePref";
	private const string PREF_PLAY_SESSION = "playSessionPref";



	private float finalScore; 

	public float FinalScore 
	{
		get
		{
			return finalScore;	
		}

		set
		{
			finalScore = value; 
			if (finalScore <= BestTime) 
			{
				BestTime = FinalScore; 
			}
		}
	}

	private float bestTime;

	public float BestTime
	{
		get 
		{
			bestTime = PlayerPrefs.GetFloat(PREF_BEST_TIME);
			return bestTime; 
		}
		set 
		{ 
			bestTime = value;
			PlayerPrefs.SetFloat(PREF_BEST_TIME, bestTime);
		}
	}

	private int playSession;

	public int PlaySession
	{
		get 
		{
			playSession = PlayerPrefs.GetInt (PREF_PLAY_SESSION);
			return playSession;
		}

		set 
		{
			playSession = value;
			PlayerPrefs.SetInt (PREF_PLAY_SESSION, playSession);
		}

	}

	// Use this for initialization
	void Start () {

		numerals = GetComponent<Text> ();
		bossHealth = GameObject.Find ("BossHealth");
		bh = bossHealth.GetComponent<BossHealth> ();
		finalWord = endText.GetComponent<Text> (); 
		finalScoreDisplay = endScore.GetComponent<Text> ();
		if (BestTime == 0) 
		{
			BestTime = 99;
		}

		PlaySession++;
		
	} 
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Current Best Time: " + BestTime);
		Debug.Log ("Current Play Session: " + PlaySession);



		if (bh.itsOver == false) 
		timer++; 
		{
			if (timer >= 30) 
			{
				timer = 0;
				score++;
			}
		}

		if (bh.itsOver) 
		{
			FinalScore = score; 
			finalScoreDisplay.text = finalScore.ToString ();
			if (FinalScore <= BestTime) {
				finalWord.text = "You Win! NEW BEST TIME: ";
			} else {
					finalWord.text = "You Win! Your Time: ";
			}
		}
		
//		score = Time.time; 

		numerals.text = Mathf.Round(score).ToString ();


	}
}
