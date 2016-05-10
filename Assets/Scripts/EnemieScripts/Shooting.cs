using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour {

	// Use this for initialization
	public GameObject arrow;
	GameObject arroww;
	float i;
	float fireRate = 3f;
	GameObject player;
	float distance;

	GameObject[] projectiles = null;
	public int numberOfProjectiles = 2;



	void Start () {
		projectiles = new GameObject[numberOfProjectiles];
		player = GameObject.Find ("Player");
		InstantiateProjectiles();
		i = Time.time;

	}

	// Update is called once per frame
	void Update () {
		distance = Vector2.Distance (gameObject.transform.position, player.transform.position);
		if (distance < 48) {
			if (Time.time > i + fireRate) {
				i = Time.time;
				ActivateProjectile ();
			}
		}
	}

	private void InstantiateProjectiles(){
		for (int i = 0; i < numberOfProjectiles; i++) {
			projectiles [i] = Instantiate (arrow) as GameObject;
			projectiles [i].GetComponent<fly> ().Shooter = gameObject;
			projectiles [i].SetActiveRecursively (false);
		}
	}

	private void ActivateProjectile(){
		for (int i = 0; i < numberOfProjectiles; i++) {
			if (projectiles [i].active == false) {
				projectiles [i].SetActiveRecursively (true);
				projectiles [i].GetComponent<fly> ().Activate ();
				return;
			}
		}
	}
}
