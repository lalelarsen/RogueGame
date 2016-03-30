using UnityEngine;
using System.Collections;

public class BlockingScriptW : MonoBehaviour {

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
			Script.WBlocked = true;
			//Script2.PMMin = 0;
			Debug.Log ("Enter W");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Obstacle") {
			Script.WBlocked = false;
			Script2.PMMin = -1;
			Debug.Log ("Left W");
		}
	}


}
