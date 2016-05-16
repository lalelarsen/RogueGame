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
	float lastStunned;

	Vector3 charginDirection;

	void Start () {
		target = GameObject.Find ("Player");
		float temp = Random.Range (0f, 1f);
		if(temp < 0.5){ compass = true; } else { compass = false; }

	}

	void Update () {
		if (stunned) {
			if (Time.time > lastStunned + stunTime) {
				Debug.Log (stunned);
				stunned = false;
			}
		} else {
			if (charging) {
				EnemyCharging ();
			} else {
				//EnemyMovement ();

				if (target.transform.position.x > transform.position.x - 0.4f && target.transform.position.x < transform.position.x + 0.4f) {
					if (target.transform.position.x - transform.position.x > 0) {
						charginDirection = new Vector2 (0, 1);
					} else {
						charginDirection = new Vector2 (0, -1);
					}
					charging = true;
				} else if (target.transform.position.y > transform.position.y - 0.4f && target.transform.position.y < transform.position.y + 0.4f) {
					if (target.transform.position.y - transform.position.y > 0) {
						charginDirection = new Vector2 (1, 0);
					} else {
						charginDirection = new Vector2 (-1, 0);
					}
					charging = true;
				}
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.name);
		if (true) {
			if (charging) {
				stunned = true;
				lastStunned = Time.time;
			} else {
				CDirection = !CDirection;
			}
		}
	}

	public void EnemyCharging(){
		transform.position = transform.position + charginDirection * speed * 2 * Time.deltaTime;
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
