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
	public float speed;
	Rigidbody2D rb;
	GameObject[] projectiles = null;
	public int numberOfProjectiles = 2;



	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		projectiles = new GameObject[numberOfProjectiles];
		player = GameObject.Find ("Player");
		InstantiateProjectiles();
		i = Time.time;

	}

	// Update is called once per frame
	void Update () {
		if(rb.velocity.x != 0 || rb.velocity.y != 0){
			Vector2 n = rb.velocity * -1 * 3;
			rb.AddForce (n);
		}
		Vector2 movedir = transform.position - player.transform.position;
		distance = Vector2.Distance (gameObject.transform.position, player.transform.position);
		if (distance < 20) {
			GetAway (movedir);

		} else if (distance < 48) {
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
	private void GetAway(Vector2 runDir){
		
		transform.position = Vector2.MoveTowards (transform.position, runDir , speed * Time.deltaTime);

	}
}
