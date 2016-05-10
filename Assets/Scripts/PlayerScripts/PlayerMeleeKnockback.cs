using UnityEngine;
using System.Collections;

public class PlayerMeleeKnockback : MonoBehaviour {

	GameObject player;

	void Start () {
		player = gameObject.transform.parent.transform.parent.gameObject;

	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.name);
		GameObject target = other.gameObject;
		Rigidbody2D targetRB = target.GetComponent<Rigidbody2D> ();
		Vector2 dir = (target.transform.position - player.transform.position);			

		targetRB.AddForce (dir * 100);
	}

}
