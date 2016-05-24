using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	
	public float healthPoints;
	public float armorPoints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public float TakeDamge(float dmg){

		if (healthPoints <= 0) {
			Destroy (gameObject);
		}

		return healthPoints = healthPoints - dmg;

	}
}
