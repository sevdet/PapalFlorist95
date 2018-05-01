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
	public float deathTimerCap = 5;
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

		Debug.Log ("DT: " + deathTimer + ", FT: " + flowerTimer);

		scoreInGame.gameObject.GetComponent<Text>().text = ("Score: " + (int)score);
		PlayerPrefs.SetFloat("Score", score);

	}

	public void GameRunning ()
	{
		if (onFireState == false) {
			if (resetRun == true) {
				deathTimer = 0;
				flowerTimer = Random.Range (3, 10);
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

		if (Input.GetKeyDown (KeyCode.Space)) {
			onFireState = false;
			resetRun = true;
			}
	}

	public void difficultyCurve()
	{


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
		if (deathTimer > 2 && deathTimer <= 3) {
			fObject.GetComponent<SpriteRenderer> ().sprite = flowerburning2;
		}
		if (deathTimer > 3 && deathTimer <= 4) {
			fObject.GetComponent<SpriteRenderer>().sprite = flowerburning3;
		}
		if (deathTimer > 4)
		{
			fObject.GetComponent<SpriteRenderer>().sprite = flowerBurnt;
		}
	}
}

