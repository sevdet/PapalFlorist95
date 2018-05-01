using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class THESCRIPT : MonoBehaviour {
	
	public float resetTimer;
	public float flowerTimer;
	float flowerTimerCap;
	float flowerTimerMin;
	public float deathTimer;
	public float deathTimerCap = 8;
	public float score;
	public bool onFireState = false;
	bool resetRun = true;
	bool resetFire;
	public GameObject flower;
	SpriteRenderer fRenderer;
	public GameObject scoreInGame;
	public Sprite flowernormal;
	public Sprite flowerburning1;
	public Sprite flowerburning2;
	public Sprite flowerburning3;
	public Sprite flowerBurnt;
	public GameObject fObject;
	bool colidingflower = false;
	public float bottomCap;
	public float topCap;
	public float difficultySlider;
	public float difficultySlider2;

	bool scoring = true;


	// Use this for initialization
	void Start()
	{

	}
	void FixedUpdate()
	{

		/* if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }

        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y); //What's going on here?
        }

        if (Input.GetKeyDown(jump))
        {
            theRB.velocity = new Vector2(moveSpeed, jumpForce);
        }


    }*/
		if (scoring) {
			score = score + 10 + Time.deltaTime;
		}
	}

	void Update()
	{
		Animation();
		GameRunning();
		difficultyCurve ();

		//Debug.Log ("DT: " + deathTimer + ", FT: " + flowerTimer);

		scoreInGame.gameObject.GetComponent<Text>().text = ("Score: " + (int)score);
		PlayerPrefs.SetFloat("Score", score);

	}

	public void GameRunning ()
	{
		if (onFireState == false) {
			if (resetRun == true) {
				deathTimer = 0;
				flowerTimer = Random.Range (bottomCap, topCap);
				resetRun = false;
			} else if (resetRun == false) {
				flowerTimer = flowerTimer - 1 * Time.deltaTime;
			}

		}
		if (flowerTimer <= 0) {
			onFireState = true;
			onFireState = true;
			resetFire = true;
		}

		if (onFireState == true) {


				deathTimer = deathTimer + 1 * Time.deltaTime;
			if (deathTimer >= deathTimerCap) { //right now the game ends when any flower dies. I can try to change this to when ALL the flowers die but it will be significantly more difficult
				scoring = false;
				SceneManager.LoadScene ("GameOver");
			}
		}

	/*	if (Input.GetKeyDown (KeyCode.Space)) {
			
			onFireState = false;
			resetRun = true;
			}*/
	}

	public void difficultyCurve()
	{
		if (score < 7000) {
			topCap = 10;
			bottomCap = 5;
		}
		if (score >= 7000 && score < 10000) {
			topCap = 9;
			bottomCap = 4;
		}
		if (score >= 10000 && score < 15000) {
			topCap = 8;
			bottomCap = 3;
		}
		if (score >= 15000 && score < 20000) {
			topCap = 7;
			bottomCap = 2;
		}
		if (score >= 20000 && score < 25000) {
			topCap = 6;
		}
		if (score >= 25000 && score < 30000) {
			topCap = 5;
		}
		if (score >= 30000) {
			topCap = 4;
		}



	}


	void Animation() //This is how all the expressions work and how the objects within the house should function.
	{
		if (deathTimer == 0)
		{
			fObject.GetComponent<SpriteRenderer>().sprite = flowernormal;
		}
		if (deathTimer > 0 && deathTimer <= 2)
		{
			fObject.GetComponent<SpriteRenderer>().sprite = flowerburning1;
		}
		if (deathTimer > 2 && deathTimer <= 4) {
			fObject.GetComponent<SpriteRenderer> ().sprite = flowerburning2;
		}
		if (deathTimer > 4 && deathTimer <= 6) {
			fObject.GetComponent<SpriteRenderer>().sprite = flowerburning3;
		}
		if (deathTimer > 6)
		{
			fObject.GetComponent<SpriteRenderer>().sprite = flowerBurnt;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(Input.GetKey(KeyCode.Space)){
			onFireState = false;
			resetRun = true;
		//colidingflower = true;
	
		
		
}
		Debug.Log ("colliding");
	}
}
