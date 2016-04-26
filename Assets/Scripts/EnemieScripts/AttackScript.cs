using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public float attackDamage;
	public int attackSpeed;
	private GameObject thePlayer;
	private HealthScript PlayerHPScript;




	// Use this for initialization
	void Start () {
		float StartTime = Time.time;
		thePlayer = GameObject.Find ("Player");
		PlayerHPScript = thePlayer.GetComponent<HealthScript>();
		//Rigidbody2D rigidMe = GetComponent<Rigidbody2D> ();

	}

	void OnCollisionEnter2D(Collision2D coll){
		Rigidbody2D rigidPlayer = thePlayer.GetComponent<Rigidbody2D> ();
		if (coll.gameObject.name == "Player") {
			//print ("onEnter");
			float TouchTime = Time.time;
			float force = 400;
			Vector2 dir = (thePlayer.transform.position - transform.position);

			rigidPlayer.AddForce (dir * force);


			if (PlayerHPScript.healthPoints > 0f) {
				
				PlayerHPScript.TakeDamge (attackDamage);
				

			} else if (PlayerHPScript.healthPoints <= 0f) {
				print ("Handle this better :D maybe a gameOver Screen");
				Destroy (thePlayer);

			}

		}
	}
	// Update is called once per frame
	void Update () {



	}
}
