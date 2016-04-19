using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public float attackDamage;
	public int attackSpeed;
	private GameObject thePlayer;
	private HealthScript HPScript;
	// Use this for initialization
	void Start () {
		float StartTime = Time.time;
		thePlayer = GameObject.Find ("Player");
		HPScript = thePlayer.GetComponent<HealthScript>();

	}
	void OnCollisionStay2D(){
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		print ("hey hey med dig");
		// attack speed kan ikke være komma tal, fordi modulus ikke virker på komma tal, dette kan undgås hvis vi laver det nedestående om
		float TouchTime = Time.time;

		Rigidbody2D rigidPlayer = thePlayer.GetComponent<Rigidbody2D> ();
		Rigidbody2D rigidMe = GetComponent<Rigidbody2D> ();

		thePlayer.transform.Translate (Vector2.up + 10 * Time.deltaTime);

		if (HPScript.healthPoints > 0f) {
				
				HPScript.TakeDamge (attackDamage);
		

			} else if (HPScript.healthPoints <= 0f) {
				Debug.Log ("Handle this better :D maybe a gameOver Screen");
				Destroy (thePlayer);

			}

	}
	// Update is called once per frame
	void Update () {



	}
}
