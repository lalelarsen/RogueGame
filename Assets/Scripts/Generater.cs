using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generater : MonoBehaviour {

	public GameObject[] tiles;
	public GameObject wall;
	public GameObject[] enemies;
	public GameObject bossRoom;
	public List <Vector3> createdTiles;
	public Vector3[] bossTiles = {new Vector3(-16,0,0), new Vector3(-32,0,0), new Vector3(-48,0,0), new Vector3(-64,0,0), new Vector3(-144,32,0), new Vector3(-128,32,0), new Vector3(-112,32,0), new Vector3(-96,32,0), new Vector3(-80,32,0), new Vector3(-144,16,0), new Vector3(-128,16,0), new Vector3(-112,16,0), new Vector3(-96,16,0), new Vector3(-80,16,0), new Vector3(-144,0,0), new Vector3(-128,0,0), new Vector3(-112,0,0), new Vector3(-96,0,0), new Vector3(-80,0,0), new Vector3(-144,-32,0), new Vector3(-128,-32,0), new Vector3(-112,-32,0), new Vector3(-96,-32,0), new Vector3(-80,-32,0), new Vector3(-144,-16,0), new Vector3(-128,-16,0), new Vector3(-112,-16,0), new Vector3(-96,-16,0), new Vector3(-80,-16,0)};
	public int tileAmount;
	public int tileSize;
	public float waitTime;

	public float chanceUp;
	public float chanceRight;
	public float chanceLeft;

	public float minY = 9999999;
	public float maxY = 0;
	public float minX = 9999999;
	public float maxX = 0;
	public float xAmount;
	public float yAmount;
	public float extraWallX;
	public float extraWallY;

	void Start () {
		StartCoroutine (GenerateLevel ());
	}

	IEnumerator GenerateLevel(){

		for (int i = 0; i < tileAmount; i++) {
			float dir = Random.Range (0f, 1f);
			int tile = Random.Range (0, tiles.Length);
			createTile (tile);
			moveChance (dir);
			yield return new WaitForSeconds (waitTime);
		}
		Finish ();


		yield return null;
	}

	void moveChance(float i){
		if (i < chanceUp) {
			moveGen (0);
		} else if (i < chanceRight) {
			moveGen (2);
		} else if (i < chanceLeft) {
			moveGen (3);
		} else {
			moveGen (1);
		}
	}

	void moveGen(int dir){
		switch (dir) {
		case 0:
			transform.position = new Vector3 (transform.position.x, transform.position.y + tileSize, 0);
			break;
		case 1:
			transform.position = new Vector3 (transform.position.x, transform.position.y - tileSize, 0);
			break;
		case 2: 
			transform.position = new Vector3 (transform.position.x + tileSize, transform.position.y, 0);
			break;
		case 3:
			transform.position = new Vector3 (transform.position.x - tileSize, transform.position.y, 0);
			break;
		}
	}

	void createTile(int tilesIndex){
		if(createdTiles.Contains(transform.position)){
			tileAmount++;
		} else {
			GameObject tileObject = Instantiate (tiles [tilesIndex], transform.position, transform.rotation) as GameObject;
			createdTiles.Add (tileObject.transform.position);
		}
	}
	void Finish(){
		createEnemies ();
		initializeBossRoom ();
		createWallValues ();
		createWalls ();

	}

	void createWallValues(){
		for (int i = 0; i < createdTiles.Count; i++) {
			if (createdTiles [i].y < minY) {
				minY = createdTiles [i].y;
			}
			if (createdTiles [i].y > maxY) {
				maxY = createdTiles [i].y;
			}
			if (createdTiles [i].x < minX) {
				minX = createdTiles [i].x;
			}
			if (createdTiles [i].x > maxX) {
				maxX = createdTiles [i].x;
			}
			xAmount = (maxX - minX) / tileSize + extraWallX;
			yAmount = (maxY - minY) / tileSize + extraWallY;
		}
	}

	void createWalls(){
		for (int x = 0; x <= xAmount; x++) {
			for (int y = 0; y <= yAmount; y++) {
				if (!createdTiles.Contains (new Vector3 ((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize)))) {
					Instantiate (wall, new Vector3 ((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);
				}
			}	
		}
	}

	void createEnemies(){
		for (int i = 0; i < createdTiles.Count; i++) {
			float dir = Random.Range (0f, 1f);
			if (dir > 0.75f) {
				GameObject e;
				float chance = Random.Range (0f, 1f);
				if (chance < 0.50f) {
					e = enemies [0];
				} else if (chance < 0.75f) {
					e = enemies [1];
				} else {
					e = enemies [2];
				}
				Instantiate (e, createdTiles[i], transform.rotation);
			}
		}
	}

	void initializeBossRoom(){
		float dir = Random.Range (0f, 1f);
		Vector2 temp = new Vector2(0,0);
		List<Vector3> vList = new List<Vector3>();
		float maxX = 0;
		float maxY = 0;
		if (dir < 0.25f) {
			for (int i = 0; i < createdTiles.Count; i++) {
				if (createdTiles [i].x > maxX) {maxX = createdTiles [i].x;}
			}
			for(int j = 0; j < createdTiles.Count; j++){
				if (createdTiles [j].x == maxX) {
					vList.Add (createdTiles[j]);
				}
			}
			for (int k = 0; k < vList.Count; k++) {
				if(vList[k].y > maxY){maxY = vList [k].y;}
			}
			temp = new Vector2 (maxX, maxY);
		} else if (dir < 0.50f) {
			for (int i = 0; i < createdTiles.Count; i++) {
				if (createdTiles [i].x > maxX) {maxX = createdTiles [i].x;}
			}
			for(int j = 0; j < createdTiles.Count; j++){
				if (createdTiles [j].x == maxX) {
					vList.Add (createdTiles[j]);
				}
			}
			for (int k = 0; k < vList.Count; k++) {
				if(vList[k].y < maxY){maxY = vList [k].y;}
			}
			temp = new Vector2 (maxX, maxY);
		} else if (dir < 0.75f) {
			for (int i = 0; i < createdTiles.Count; i++) {
				if (createdTiles [i].x < maxX) {maxX = createdTiles [i].x;}
			}
			for(int j = 0; j < createdTiles.Count; j++){
				if (createdTiles [j].x == maxX) {
					vList.Add (createdTiles[j]);
				}
			}
			for (int k = 0; k < vList.Count; k++) {
				if(vList[k].y > maxY){maxY = vList [k].y;}
			}
			temp = new Vector2 (maxX, maxY);
		} else {
			for (int i = 0; i < createdTiles.Count; i++) {
				if (createdTiles [i].x < maxX) {maxX = createdTiles [i].x;}
			}
			for(int j = 0; j < createdTiles.Count; j++){
				if (createdTiles [j].x == maxX) {
					vList.Add (createdTiles[j]);
				}
			}
			for (int k = 0; k < vList.Count; k++) {
				if(vList[k].y < maxY){maxY = vList [k].y;}
			}
			temp = new Vector2 (maxX, maxY);

		}

		Debug.Log (temp);

		if (maxX < 0) {
			for (int i = 0; i < bossTiles.Length; i++) {
				createdTiles.Add (new Vector3 (temp.x + bossTiles [i].x, temp.y + bossTiles [i].y));
				Instantiate (bossRoom, temp, transform.rotation);
			}
		} else {
			for (int i = 0; i < bossTiles.Length; i++) {
				createdTiles.Add(new Vector3(temp.x + bossTiles[i].x * -1, temp.y + bossTiles[i].y));
				Instantiate (bossRoom, temp, Quaternion.Euler(0,180,0));
			}
		}

	}
}