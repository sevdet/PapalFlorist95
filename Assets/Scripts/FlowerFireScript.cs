using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowerFireScript : MonoBehaviour
{
    public float resetTimer;
    public float flowerTimer;
    float flowerTimerCap;
    float flowerTimerMin;
    float deathTimer;
    public float deathTimerCap;
    public float score;
    bool onFireState; 
    bool notOnFireState;
    bool resetRun;
    bool resetFire;
    public GameObject flower;


    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameRunning();
        score = score + 10 * Time.deltaTime;

    }

    public void GameRunning()
    {
        if (notOnFireState == true)
        {
            deathTimer = 0;
            resetRun = true;
            if (resetRun == true)
            {
                flowerTimer = Random.Range(3, 10);
                resetRun = false;
            }
            else if (resetRun == false)
                {
                flowerTimer = flowerTimer - 1 * Time.deltaTime;
            }
        }
        if (flowerTimer <= 0)
        {
            notOnFireState = false;
            onFireState = true;
        }
        if (onFireState == true)
        {
            resetFire = true;
            if (resetFire == true)
            {
                deathTimer = 0;
                resetFire = false;
            }
            else if (resetFire == false)
            {
                deathTimer = deathTimer - 1 * Time.deltaTime;
            }
            if (deathTimer >= deathTimerCap)
            {
                SceneManager.LoadScene("End");
            }
        }


    }

    public void difficultyCurve()
    {
        

    }
} 

