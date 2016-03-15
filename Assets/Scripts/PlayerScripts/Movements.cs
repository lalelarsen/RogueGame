using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {
	public float Speed = 5f;
	private float yAxis;
	private float xAxis;
	// Use this for initialization
	void Start () {
		yAxis = transform.position.y;
		xAxis = transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.W)) {
			Vector2 newposition = new Vector2(transform.position.x, Mathf.Clamp ((yAxis + Speed * Time.deltaTime), -10f, 10f));

			transform.position = newposition;
		}

		if (Input.GetKey (KeyCode.S)) {
			Vector2 newposition = new Vector2(transform.position.x, Mathf.Clamp ((yAxis - Speed * Time.deltaTime), -10f, 10f));

			transform.position = newposition;
		}

		if (Input.GetKey (KeyCode.A)) {
			Vector2 newLeftTurn = new Vector2 (Mathf.Clamp ((xAxis - Speed * Time.deltaTime), -10f, 10f), transform.position.y);

			transform.position = newLeftTurn;
		}

		if (Input.GetKey (KeyCode.D)) {
			Vector2 newRightTurn = new Vector2 (Mathf.Clamp ((xAxis + Speed * Time.deltaTime), -10f, 10f), transform.position.y);

			transform.position = newRightTurn;
		}
			
	}
}