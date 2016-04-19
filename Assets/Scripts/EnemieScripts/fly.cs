using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {

	// Use this for initialization
	GameObject target;
	Vector2 heading;
	float speed = 350;
	Rigidbody2D rb;

	void Start () {
		
		target = GameObject.Find ("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
		heading = target.transform.position - transform.position;
		float targetAngle = Mathf.Atan2 (heading.x, heading.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, -targetAngle);
		rb.AddForce (transform.up * speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			gameObject.SetActive (false);
		}
	}


	void Update () {
		
	}


}
