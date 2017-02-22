using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public float damageAmount;
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
}
