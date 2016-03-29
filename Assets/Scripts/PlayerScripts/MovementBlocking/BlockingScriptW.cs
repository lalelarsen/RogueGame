using UnityEngine;
using System.Collections;

public class BlockingScriptW : MonoBehaviour {

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
			playerScript.WBlocked = true;
			Debug.Log ("Enter W");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Obstacle") {
			playerScript.WBlocked = false;
			Debug.Log ("Left W");
		}
	}


}
