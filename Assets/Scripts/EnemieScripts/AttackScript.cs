using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public float attackDamage;
	public int attackSpeed;
	private GameObject thePlayer;
	private HealthScript HPScript;
	// Use this for initialization
	void Start () {

		thePlayer = GameObject.Find ("Player");
		HPScript = thePlayer.GetComponent<HealthScript>();

	}


	void OnCollisionEnter2D(Collision2D coll){
		// attack speed kan ikke være komma tal, fordi modulus ikke virker på komma tal, dette kan undgås hvis vi laver det nedestående om
		float TouchTime = Time.time;

		if (HPScript.healthPoints > 0f) {
			if (TouchTime % attackSpeed == 0) { 
				Debug.Log (HPScript.TakeDamge (attackDamage));

			} else if (HPScript.healthPoints <= 0f) {
				Debug.Log ("Handle this better :D maybe a gameOver Screen");
				Destroy (thePlayer);

			}
		}
	}
	// Update is called once per frame
	void Update () {



	}
}
