using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionHop : MonoBehaviour {
	public KeyCode warp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(warp)){
			SceneManager.LoadScene("Level 2");
		}
	}
}
