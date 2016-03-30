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
	//public GameObject Playermove;
	private float distance;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		GameObject Playermove = GameObject.Find ("Player");		
		distance = Vector2.Distance (transform.position, Playermove.transform.position);
		if(distance < chaseDistance){
			Debug.Log ("im chasin you!!!");
			EnemyChaseMovement (Playermove , chaseDistance);
		}else{
			RandomEnemyMovement ();	
		}



 	}
	public void EnemyChaseMovement (GameObject PlayerPos, float chaseDist){
		// den kører kun dette en gang, dermed bliver dens retning låst hvergang den kører måske
		transform.position = Vector2.MoveTowards (transform.position, PlayerPos.transform.position, speed * Time.deltaTime);

	}

	public void RandomEnemyMovement(){
		int XYDestinc = Random.Range (XYmin, XYmax);
		int PlusMinusDestinc = Random.Range (PMMin, PMMax);

		if (XYDestinc == 1) {
			// bevægelse på Y Axen
			if (PlusMinusDestinc == 1) {
				// bevæg dig + på Y Axen
				Vector2 newYPPos = new Vector2  ( transform.position.x, Mathf.Clamp(transform.position.y + speed * Time.deltaTime, minBound, maxBound));

				transform.position = newYPPos;
			} else {
				// bevæg dig - på Y Axen
				Vector2 newYMPos = new Vector2 (transform.position.x, Mathf.Clamp(transform.position.y - speed * Time.deltaTime, minBound, maxBound));
				transform.position = newYMPos;
			}


		} else {
			// bevægelse på X Axen
			if (PlusMinusDestinc == 1) {
				// bevæg dig + på X Axen
				Vector2 newXPPos = new Vector2 (Mathf.Clamp(transform.position.x + speed * Time.deltaTime, minBound, maxBound), transform.position.y);
				transform.position = newXPPos;
			} else {
				// bevæg dig - på X Axen
				Vector2 newXMPos = new Vector2 (Mathf.Clamp(transform.position.x - speed * Time.deltaTime, minBound, maxBound), transform.position.y);
				transform.position = newXMPos;
			}

		}
	
	
	}

}