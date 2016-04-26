using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour {

	// Use this for initialization
	public GameObject arrow;
	GameObject arroww;
	float i;
	float fireRate = 3;

	void Start () {
		i = Time.time;

	}

	// Update is called once per frame
	void Update () {
		if (Time.time > i + fireRate) {
			i = Time.time;
			arroww = Instantiate (arrow, transform.position, Quaternion.identity) as GameObject;

		}
	
	}
}
