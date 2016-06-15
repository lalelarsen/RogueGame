using UnityEngine;
using System.Collections;

public class PlayerStateScript : MonoBehaviour {

	public bool inBossRoom = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "BossRoom(Clone)") {
			inBossRoom = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "BossRoom(Clone)") {
			inBossRoom = false;
		}
	}
}
