using UnityEngine;
using System.Collections;

public class BlockingScriptN : MonoBehaviour {

	GameObject parent;
	GameObject player;
	Movements Script = Movements();
	RandMovement Script2 = RandMovement();

	void Start () {
		parent = gameObject.transform.parent.gameObject;
		player = parent.transform.parent.gameObject;
		Script = GetComponent<Movements>();
		Script2 = GetComponent<RandMovement> ();

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (other.tag == "Obstacle") {
			Script.NBlocked = true;
			Script2.XYmax = 1;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Obstacle") {
			Script.NBlocked = false;
			Script2.XYmax = 2;
		}
	}


}
