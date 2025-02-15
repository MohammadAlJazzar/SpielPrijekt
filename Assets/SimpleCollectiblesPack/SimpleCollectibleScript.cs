﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Type1, Type2, Type3, Type4, Type5}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	private int coins = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type
		AddCoin();
		Destroy (gameObject);
	}

	public void AddCoin(){
		coins++;
		Debug.Log("Lives= "+ GameManager.Instance.lives);
		if(coins>=5 || GameManager.Instance.scoreManager.score >= 26 ){
			coins=0;
			GameManager.Instance.scoreManager.score=0;
			if(GameManager.Instance.lives<3){
				GameManager.Instance.lives++;
				GameManager.Instance.uiManager.LiveIncrease(GameManager.Instance.lives-1);
				
			}
		}
	}
}
