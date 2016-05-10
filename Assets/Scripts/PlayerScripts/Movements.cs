using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {
	public float Speed = 2.5f;
	private const float minBound = -9999f;
	private const float maxBound = 9999f;
	public bool w = false;
	public bool s = false;
	public bool a = false;
	public bool d = false;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float yAxis = transform.position.y;
		float xAxis = transform.position.x;

		if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			Vector2 newposition = new Vector2 (Mathf.Clamp (xAxis + Speed / 2 * Time.deltaTime, minBound, maxBound), Mathf.Clamp (yAxis - Speed / 2 * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = false;
			s = true;
			a = false;
			d = true;

		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			Vector2 newposition = new Vector2 (Mathf.Clamp (xAxis - Speed / 2 * Time.deltaTime, minBound, maxBound), Mathf.Clamp (yAxis - Speed / 2 * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = false;
			s = true;
			a = true;
			d = false;

		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			Vector2 newposition = new Vector2 (Mathf.Clamp (xAxis + Speed / 2 * Time.deltaTime, minBound, maxBound), Mathf.Clamp (yAxis + Speed / 2 * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = true;
			s = false;
			a = false;
			d = true;

		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			Vector2 newposition = new Vector2 (Mathf.Clamp (xAxis - Speed / 2 * Time.deltaTime, minBound, maxBound), Mathf.Clamp (yAxis + Speed / 2 * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = true;
			s = false;
			a = true;
			d = false;

		} else if (Input.GetKey (KeyCode.W)) {
			Vector2 newposition = new Vector2 (xAxis, Mathf.Clamp (yAxis + Speed * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = true;
			s = false;
			a = false;
			d = false;

		} else if (Input.GetKey (KeyCode.A)) {
			w = false;
			s = false;
			a = true;
			d = false;
			Vector2 newLeftTurn = new Vector2 (Mathf.Clamp (xAxis - Speed * Time.deltaTime, minBound, maxBound), yAxis);
			transform.position = newLeftTurn;

		} else if (Input.GetKey (KeyCode.D)) {
			Vector2 newRightTurn = new Vector2 (Mathf.Clamp (xAxis + Speed * Time.deltaTime, minBound, maxBound), yAxis);
			transform.position = newRightTurn;
			w = false;
			s = false;
			a = false;
			d = true;

		} else if (Input.GetKey (KeyCode.S)) {
			Vector2 newposition = new Vector2 (xAxis, Mathf.Clamp (yAxis - Speed * Time.deltaTime, minBound, maxBound));
			transform.position = newposition;
			w = false;
			s = true;
			a = false;
			d = false;

		}

		if(rb.velocity.x != 0 || rb.velocity.y != 0){
			Vector2 n = rb.velocity * -1 * 3;
			rb.AddForce (n);
		}


	}
}