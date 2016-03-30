using UnityEngine;
using System.Collections;

public class BlockingScriptS : MonoBehaviour {

	GameObject parent;
	GameObject player;
	Movements Script = Movements();
	//RandMovement Script2 = RandMovement();

	void Start () {
		parent = gameObject.transform.parent.gameObject;
		player = parent.transform.parent.gameObject;
		Script = GetComponent<Movements>();
		//Script2 = GetComponent<RandMovement> ();

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);
		if (other.tag == "Obstacle") {
			Script.SBlocked = true;
			//Script2.XYmin = 0;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Obstacle") {
			Script.SBlocked = false;
			Script2.XYmin = -1;
		}
	}


}
