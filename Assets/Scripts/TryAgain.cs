using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour {
	public Text scoreText; //text variable
	public float score = 0; //score holder
	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + (PlayerPrefs.GetFloat ("Score")).ToString(); //changing text of the score text
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayGame() {
		SceneManager.LoadScene (1); //if the button is pressed, go to the game
	}
}
