using UnityEngine;
using System.Collections;

public class BlockingScriptS : MonoBehaviour {

	GameObject parent;
	GameObject player;
	Movements playerScript;

	void Start () {
		parent = gameObject.transform.parent.gameObject;
		player = parent.transform.parent.gameObject;
		playerScript = GetComponent<Movements>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Obstacle") {
			playerScript.SBlocked = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Obstacle") {
			playerScript.SBlocked = false;
		}
	}


}
