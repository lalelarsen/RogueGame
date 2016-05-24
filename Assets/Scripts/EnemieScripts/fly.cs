using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {

	// Use this for initialization
	GameObject target;
	public GameObject Shooter;
	Vector2 heading;
	float speed = 2000;
	Rigidbody2D rb;
	Rigidbody2D tRb;

	void Start () {
		
		target = GameObject.Find ("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
		tRb = target.GetComponent<Rigidbody2D> ();
		go ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			target.GetComponent<HealthScript> ().TakeDamge (10f);
			tRb.AddForce (heading * speed/6);
		} 
		if (other.gameObject != Shooter) {
			Deactivate ();
		}


	}

	public void go(){
		heading = target.transform.position - transform.position;
		float targetAngle = Mathf.Atan2 (heading.x, heading.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, -targetAngle);
		rb.AddForce (transform.up * speed);
	}

	void Update () {
		heading = target.transform.position - transform.position;
	}

	public void Activate(){
		transform.position = Shooter.transform.position;
		go ();
	}

	private void Deactivate(){
		gameObject.SetActiveRecursively (false);
	}


}
