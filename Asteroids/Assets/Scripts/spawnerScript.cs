using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour {

	public GameObject asteroidL1;
	public GameObject asteroidL2;

	public float frequency;

	private bool canSpawn = false;
	public int asteroidnum = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpawn) {
			StartCoroutine (delay ());
		}
	}

	IEnumerator delay(){
		canSpawn = false;
		yield return new WaitForSecondsRealtime (frequency);
		Spawn ();
		canSpawn = true;
	}

	void Spawn(){
		GameObject spawner = GameObject.Find ("spawner");

		int randSide = Random.Range (0, 4);
		if (randSide == 0) {
			float randY = Random.Range (-5f, 5.1f);
			float X = -15f;
			GameObject newAsteroid = Instantiate (asteroidL1, new Vector3 (X, randY), Quaternion.identity);
			newAsteroid.name = "asteroid" + asteroidnum;
			asteroidnum++;
			spawner.GetComponent<CollisionScript> ().asteroidList.Add (newAsteroid);
		}
		else if (randSide == 1) {
			float randY = Random.Range (-5f, 5.1f);
			float X = 15f;
			GameObject newAsteroid = Instantiate (asteroidL1, new Vector3 (X, randY), Quaternion.identity);
			newAsteroid.name = "asteroid" + asteroidnum;
			asteroidnum++;
			spawner.GetComponent<CollisionScript> ().asteroidList.Add (newAsteroid);
		}
		else if (randSide == 2) {
			float randX = Random.Range (-9.25f, 9.26f);
			float Y = -9f;
			GameObject newAsteroid = Instantiate (asteroidL1, new Vector3 (randX, Y), Quaternion.identity);
			newAsteroid.name = "asteroid" + asteroidnum;
			asteroidnum++;
			spawner.GetComponent<CollisionScript> ().asteroidList.Add (newAsteroid);
		}
		else if (randSide == 3) {
			float randX = Random.Range (-9.25f, 9.26f);
			float Y = 9f;
			GameObject newAsteroid = Instantiate (asteroidL1, new Vector3 (randX, Y), Quaternion.identity);
			newAsteroid.name = "asteroid" + asteroidnum;
			asteroidnum++;
			spawner.GetComponent<CollisionScript> ().asteroidList.Add (newAsteroid);
		}



	}
}
