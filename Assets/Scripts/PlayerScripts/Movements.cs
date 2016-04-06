using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {
	public float Speed = 2.5f;
	private const float minBound = -4.85f;
	private const float maxBound = 4.85f;
	bool w = false;
	bool s = false;
	bool a = false;
	bool d = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float yAxis = transform.position.y;
		float xAxis = transform.position.x;

		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			Vector2 newposition = new Vector2(Mathf.Clamp( xAxis + Speed/2 * Time.deltaTime, minBound, maxBound) , Mathf.Clamp( yAxis - Speed/2 * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			Vector2 newposition = new Vector2(Mathf.Clamp( xAxis - Speed/2 * Time.deltaTime, minBound, maxBound) , Mathf.Clamp( yAxis - Speed/2 * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			Vector2 newposition = new Vector2(Mathf.Clamp( xAxis + Speed/2 * Time.deltaTime, minBound, maxBound) , Mathf.Clamp( yAxis + Speed/2 * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			Vector2 newposition = new Vector2(Mathf.Clamp( xAxis - Speed/2 * Time.deltaTime, minBound, maxBound) , Mathf.Clamp( yAxis + Speed/2 * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		} else if (Input.GetKey (KeyCode.W)) {
			Vector2 newposition = new Vector2(xAxis , Mathf.Clamp( yAxis + Speed * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		} else if (Input.GetKey (KeyCode.A)) {
			Vector2 newLeftTurn = new Vector2 (Mathf.Clamp( xAxis - Speed * Time.deltaTime, minBound, maxBound), yAxis);

			transform.position = newLeftTurn;
		} else if (Input.GetKey (KeyCode.D)) {
			Vector2 newRightTurn = new Vector2 (Mathf.Clamp( xAxis + Speed * Time.deltaTime, minBound, maxBound), yAxis);

			transform.position = newRightTurn;
		} else if (Input.GetKey (KeyCode.S)) {
			Vector2 newposition = new Vector2(xAxis, Mathf.Clamp( yAxis - Speed * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		}

	}
}