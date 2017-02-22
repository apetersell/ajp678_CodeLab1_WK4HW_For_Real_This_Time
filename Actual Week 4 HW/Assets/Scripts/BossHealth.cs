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
	public bool itsOver = false; 
	public KeyCode reset; 
	GameObject dwayne;
	GameObject canvas;



	// Use this for initialization
	void Start () {
		dwayne = GameObject.Find ("Dwayne");
		canvas = GameObject.Find ("Canvas");


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
			itsOver = true; 
		}

		if (itsOver == true) 
		{
			if (Input.GetKeyDown (reset)) 
			{
				Destroy (dwayne);
				Destroy (canvas);
				PlayerMovement.player = null;
				UISaver.gameUI = null;
				EditorSceneManager.LoadScene (0);
			}
		}
	}
}
