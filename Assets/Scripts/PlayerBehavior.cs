﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public float speed; // speed of player
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	public Rigidbody2D rb;
	public Animator animController;
	bool isRightFacing = true;

	// Use this for initialization
	void Start () {
		speed = 10;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		animController = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
		yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S/up/down key presses 

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);  // moves player

		if (xAxis == 1) {
			isRightFacing = true;
			animController.Play ("walk");
		} else if (xAxis == -1) {
			isRightFacing = false;
			animController.Play ("walkLeft");
		}
		else {
			if (isRightFacing) {
				if (Input.GetKey(KeyCode.Space)) {
					//animController.Play ("wateringRight");
					animController.SetTrigger("waterRight");
				} else {
					animController.Play ("idle");
				}
			} else {
				if (Input.GetKey(KeyCode.Space)) {
					//animController.Play ("wateringLeft");
					animController.SetTrigger("waterLeft");
				} else {
					animController.Play ("idleLeft");
				}
			}
		}
	}
}
