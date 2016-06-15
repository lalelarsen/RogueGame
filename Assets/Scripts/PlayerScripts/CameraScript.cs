using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	GameObject player;
	GameObject gen;
	Generater genScript;
	PlayerStateScript PSS;
	bool status = true;
	void Start () {
		gen = GameObject.Find ("Generater");
		genScript = gen.GetComponent<Generater> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!genScript.isDone && status) {
			gameObject.transform.position = new Vector3 (gen.transform.position.x, gen.transform.position.y, -10);;
		} else {
			player = GameObject.Find ("Player");
			PSS = player.GetComponent<PlayerStateScript> ();
			status = false;
		}
		if(PSS.inBossRoom){
			gameObject.transform.position = new Vector3(genScript.bossSpawn.x, genScript.bossSpawn.y, -10);
		} else if (!status) {
			gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);;
		}

	}

}
