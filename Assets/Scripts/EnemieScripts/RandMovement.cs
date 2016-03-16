using UnityEngine;
using System.Collections;

public class RandMovement : MonoBehaviour {
	public float speed;
	private int count = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float yAxis = transform.position.y;
		float xAxis = transform.position.x;
		float RanAxisFloat = Random.Range (-10f, 10f);


			if (count % 2 == 0) {

				Vector2 newYposition = new Vector2 (xAxis, yAxis + RanAxisFloat * Time.deltaTime);
				transform.position = newYposition;

				count++;
			} else {

				Vector2 newXposition = new Vector2 (xAxis + RanAxisFloat * Time.deltaTime, yAxis);
				transform.position = newXposition;

				count++;
			}

	}

	public ArrayList getNextMovement(){
		ArrayList returnList = new ArrayList ();
		for (var i = 0; i < 10; i++) {
			returnList.Add (Random.Range (-10f, 10f));
		
		}
		return returnList;
	}
}
