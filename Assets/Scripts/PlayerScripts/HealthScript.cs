﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float healthPoints;
	public float armorPoints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (healthPoints <= 0) {
			Destroy (gameObject);
		}
	}

	public float TakeDamge(float dmg){
		
		return healthPoints = healthPoints - dmg;

	}
}
