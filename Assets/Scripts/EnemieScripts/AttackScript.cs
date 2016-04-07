using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public double attackDamage;
	public int attackSpeed;


	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		GameObject thePlayer = GameObject.Find ("Player");
		HealthScript HPScript = thePlayer.GetComponent<HealthScript>();

		if (Time.fixedTime % attackSpeed == 0) {
			Debug.Log (HPScript.healthPoints - 10D);
		}
	}
	// Update is called once per frame
	void Update () {
		


	}
}
