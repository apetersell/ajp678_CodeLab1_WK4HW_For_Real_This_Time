using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement; 

public class BossHealth : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public float damageAmount;
	public Image content;
	public GameObject winText;
	public GameObject endScore;
	public GameObject extraText;
	public bool itsOver = false; 
	public KeyCode reset; 
	public KeyCode record;
	public bool canRecord = true;
	GameObject dwayne;
	GameObject canvas;
	GameObject infoSaver;
	InfoSaver infs;
	Text extraWords;



	// Use this for initialization
	void Start () {
		dwayne = GameObject.Find ("Dwayne");
		canvas = GameObject.Find ("Canvas");
		infoSaver = GameObject.Find ("Info Saver");
		infs = infoSaver.GetComponent<InfoSaver> ();
		extraWords = extraText.GetComponent<Text> ();


	}

	// Update is called once per frame
	void Update () {

		handleBar ();
		textDisplay ();

	}

	void handleBar ()
	{
		content.fillAmount = map (currentHealth, maxHealth);
	}

	private float map (float current, float max)
	{
		return current / max; 
	}

	public void hurtBoss ()
	{
		currentHealth = currentHealth - damageAmount;
	}

	public void textDisplay ()
	{
		if (currentHealth <= 0) 
		{
			winText.SetActive (true);
			endScore.SetActive (true);
			extraText.SetActive (true);
			itsOver = true; 
		}

		if (itsOver == true) 
		{
			if (Input.GetKeyDown (reset)) 
			{
				Destroy (dwayne);
				Destroy (canvas);
				Destroy (infoSaver);
				PlayerMovement.player = null;
				UISaver.gameUI = null;
				EditorSceneManager.LoadScene (0);
			}

			if (canRecord == true && itsOver == true) 
			{
				extraWords.text = "Press 'R' to restart.  Press 'C' to record your results.";
				if (Input.GetKeyDown (record)) 
				{
					infs.record ();
					canRecord = false;
				}
			}

			if (canRecord == false)
			{
				extraWords.text = "Recorded! Press 'R' to restart.";
			}
				
		}
	}

	public void recordFlipper ()
	{
		canRecord = true;
	}
}
