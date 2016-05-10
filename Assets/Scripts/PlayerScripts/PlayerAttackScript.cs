using UnityEngine;
using System.Collections;

public class PlayerAttackScript : MonoBehaviour {

	float dmg = 5;
	float force = 5;
	float activeTime = 0.5f;
	bool attackOn = false;
	float attackTime;
	bool nB = false;
	bool sB = false;
	bool eB = false;
	bool wB = false;

	GameObject NGO;
	GameObject SGO;
	GameObject EGO;
	GameObject WGO;
	GameObject NEGO;
	GameObject SEGO;
	GameObject NWGO;
	GameObject SWGO;

	Movements pMov;

	void Start () {
		pMov = gameObject.GetComponentInParent<Movements> ();
		NGO = gameObject.transform.Find ("N").gameObject;
		SGO = gameObject.transform.Find ("S").gameObject;
		EGO = gameObject.transform.Find ("E").gameObject;
		WGO = gameObject.transform.Find ("W").gameObject;
		NEGO = gameObject.transform.Find ("NE").gameObject;
		SEGO = gameObject.transform.Find ("SE").gameObject;
		NWGO = gameObject.transform.Find ("NW").gameObject;
		SWGO = gameObject.transform.Find ("SW").gameObject;

		attackTime = Time.time;
	}
		
	void Update (){
			
		if (attackTime < Time.time) {
			nB = false;
			sB = false;
			eB = false;
			wB = false;
			setInactive ();
			if (Input.GetKey (KeyCode.Space)) {
				attackTime = Time.time + activeTime;
				nB = pMov.w;
				sB = pMov.s;
				eB = pMov.d;
				wB = pMov.a;
			}
		} else {
			if (nB && !sB && !eB && !wB) {
				NGO.SetActiveRecursively (true);
			}
			if (!nB && sB && !eB && !wB) {
				SGO.SetActiveRecursively (true);
			}
			if (!nB && !sB && eB && !wB) {
				EGO.SetActiveRecursively (true);
			}
			if (!nB && !sB && !eB && wB) {
				WGO.SetActiveRecursively (true);
			}
			if (nB && !sB && !eB && wB) {
				NWGO.SetActiveRecursively (true);
			}
			if (!nB && sB && !eB && wB) {
				SWGO.SetActiveRecursively (true);
			}
			if (nB && !sB && eB && !wB) {
				NEGO.SetActiveRecursively (true);
			}
			if (!nB && sB && eB && !wB) {
				SEGO.SetActiveRecursively (true);
			}
		}

	}

	public void setInactive(){
		NGO.SetActiveRecursively (false);
		SGO.SetActiveRecursively (false);
		EGO.SetActiveRecursively (false);
		WGO.SetActiveRecursively (false);
		NEGO.SetActiveRecursively (false);
		SEGO.SetActiveRecursively (false);
		NWGO.SetActiveRecursively (false);
		SWGO.SetActiveRecursively (false);
	}

}
