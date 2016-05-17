using UnityEngine;
using System.Collections;

public class RandMovement : MonoBehaviour {
	public float speed;
	public float chaseDistance;
	private const float minBound = -4.85f;
	private const float maxBound = 4.85f;
	public int XYmin = -1;
	public int XYmax = 2;
	public int PMMin = -1;
	public int PMMax = 2;

	bool chasing = false;
	bool CDirection = true;
	bool compass;

	Rigidbody2D rb;
	//public GameObject Playermove;
	private float distance;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		float temp = Random.Range (0f, 1f);
		if(temp < 0.5){ compass = true; } else { compass = false; }
	}

	// Update is called once per frame
	void Update () {
		GameObject Playermove = GameObject.Find ("Player");		
		distance = Vector2.Distance (transform.position, Playermove.transform.position);
		if(distance < chaseDistance){
			//Debug.Log ("im chasin you!!!");
			EnemyChaseMovement (Playermove , chaseDistance);
			chasing = true;
		}else{
			//RandomEnemyMovement ();	
			EnemyMovement();
			chasing = false;
		}
		if(rb.velocity.x != 0 || rb.velocity.y != 0){
			Vector2 n = rb.velocity * -1 * 3;
			rb.AddForce (n);
		}

 	}
	public void EnemyChaseMovement (GameObject PlayerPos, float chaseDist){
		

			transform.position = Vector2.MoveTowards (transform.position, PlayerPos.transform.position, speed * Time.deltaTime);

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

	void OnTriggerEnter2D(Collider2D other){
		CDirection = !CDirection;
	}

	public void RandomEnemyMovement(){
		int XYDestinc = Random.Range (XYmin, XYmax);
		int PlusMinusDestinc = Random.Range (PMMin, PMMax);

		if (XYDestinc == 1) {
			// bevægelse på Y Axen
			if (PlusMinusDestinc == 1) {
				// bevæg dig + på Y Axen
				Vector2 newYPPos = new Vector2  (transform.position.x, transform.position.y + speed * Time.deltaTime);

				transform.position = newYPPos;
			} else {
				// bevæg dig - på Y Axen
				Vector2 newYMPos = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
				transform.position = newYMPos;
			}


		} else {
			// bevægelse på X Axen
			if (PlusMinusDestinc == 1) {
				// bevæg dig + på X Axen
				Vector2 newXPPos = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);
				transform.position = newXPPos;
			} else {
				// bevæg dig - på X Axen
				Vector2 newXMPos = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);
				transform.position = newXMPos;
			}

		}
	
	
	}

}