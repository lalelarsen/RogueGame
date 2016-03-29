using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {
	public float Speed = 5f;
	private const float minBound = -4.85f;
	private const float maxBound = 4.85f;
	public bool NBlocked = false;
	public bool SBlocked = false;
	public bool EBlocked = false;
	public bool WBlocked = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float yAxis = transform.position.y;
		float xAxis = transform.position.x;

		if (Input.GetKey (KeyCode.W) && !NBlocked) {
			Vector2 newposition = new Vector2(xAxis , Mathf.Clamp( yAxis + Speed * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		}

		if (Input.GetKey (KeyCode.S) && !SBlocked) {
			Vector2 newposition = new Vector2(xAxis, Mathf.Clamp( yAxis - Speed * Time.deltaTime, minBound, maxBound));

			transform.position = newposition;
		}

		if (Input.GetKey (KeyCode.A) && !WBlocked) {
			Vector2 newLeftTurn = new Vector2 (Mathf.Clamp( xAxis - Speed * Time.deltaTime, minBound, maxBound), yAxis);

			transform.position = newLeftTurn;
		}

		if (Input.GetKey (KeyCode.D) && !EBlocked) {
			Vector2 newRightTurn = new Vector2 (Mathf.Clamp( xAxis + Speed * Time.deltaTime, minBound, maxBound), yAxis);

			transform.position = newRightTurn;
		}
			
	}
}