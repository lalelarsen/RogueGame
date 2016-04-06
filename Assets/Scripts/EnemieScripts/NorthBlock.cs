using UnityEngine;
using System.Collections;

public class NorthBlock : MonoBehaviour {

	RandMovement rm;
	void Start () {
		rm = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<RandMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			rm.blockedN = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Obstacle") {
			rm.blockedN = false;
		}
	}
}
