using UnityEngine;
using System.Collections;

public class ChargerScript : MonoBehaviour {

	GameObject target;
	float stunTime = 3;
	float speed = 3;
	bool charging = false;
	bool CDirection = true;
	bool compass;
	bool stunned = false;
	bool lowStunned = false;
	float lastStunned;
	public bool spotted;

	Vector3 charginDirection;

	void Start () {
		target = GameObject.Find ("Player");
		float temp = Random.Range (0f, 1f);
		if(temp < 0.5){ compass = true; } else { compass = false; }

	}

	void Update () {
		spotted = !Physics2D.Linecast (transform.position, target.transform.position, 1 << LayerMask.NameToLayer ("ObstacleLayer"));
		//Debug.Log ("stun " + stunned);
		//Debug.Log ("charg " + charging);
		if (stunned || lowStunned) {
			if (Time.time > lastStunned + stunTime) {				
				stunned = false;
				lowStunned = false;
			}
		} else {
			if (charging) {
				EnemyCharging ();
			} else {
				EnemyMovement ();
				if (spotted) {
					if (target.transform.position.x > transform.position.x - 0.4f && target.transform.position.x < transform.position.x + 0.4f) {
						if ((target.transform.position.y - transform.position.y) > 0) {
							charginDirection = new Vector2 (0, 1);
						} else {
							charginDirection = new Vector2 (0, -1);
						}
						charging = true;
					} else if (target.transform.position.y > transform.position.y - 0.4f && target.transform.position.y < transform.position.y + 0.4f) {
						if ((target.transform.position.x - transform.position.x) > 0) {
							charginDirection = new Vector2 (1, 0);
						} else {
							charginDirection = new Vector2 (-1, 0);
						}
						charging = true;
					}
				}
			}
		}
		//Debug.Log (charginDirection);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (charging) {
			if (other.tag == "Obstacle") {
				transform.position = transform.position - charginDirection * 2;
				stunned = true;
				lastStunned = Time.time;
				charging = false;
				float temp = Random.Range (0f, 1f);
				if (temp < 0.5) {
					compass = true;
				} else {
					compass = false;
				}
			} else {
				transform.position = transform.position - charginDirection * 2;
				lowStunned = true;
				lastStunned = Time.time - stunTime / 2;
				charging = false;
				Rigidbody2D tempBody = other.attachedRigidbody;
				tempBody.AddForce (charginDirection * 5000);
				float temp = Random.Range (0f, 1f);
				if(temp < 0.5){ compass = true; } else { compass = false; }
			}

		} else {
			CDirection = !CDirection;
		}
	}

	public void EnemyCharging(){
		transform.position = transform.position + charginDirection * speed * 9 * Time.deltaTime;
	}

	public void EnemyMovement(){
		Vector2 newPos;
		if (compass) {
			if (CDirection) {
				newPos = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
			} else {
				newPos = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
			}
		} else {
			if (CDirection) {
				newPos = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
			} else {
				newPos = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
			}
		}
		transform.position = newPos;
	}
}
