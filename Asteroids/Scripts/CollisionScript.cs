using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class CollisionScript : MonoBehaviour {

	public List<GameObject> asteroidList = new List<GameObject>();
	//public List<GameObject> asteroidL2List = new List<GameObject>();
	public GameObject bullet = null;
	public GameObject ship;

	public GameObject asteroidL2;

	public AudioClip smallExplosion;
	public AudioClip bigExplosion;
	public AudioClip damageSnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckCollision ();
	}

	void CheckCollision(){
		//GameObject[] goArr = GameObject.FindGameObjectsWithTag ("asteroid");
		//foreach (GameObject go in asteroidList) {
		for (int i = 0; i < GetComponent<spawnerScript> ().asteroidnum; i++) {
			string currAsteroid = "asteroid" + i;
			GameObject currAsteroidObj = GameObject.Find (currAsteroid);
			if (currAsteroidObj != null) {
				if (CircleCollision (GameObject.FindGameObjectWithTag ("ship"), currAsteroidObj) && currAsteroidObj.GetComponent<asteroidScript> ().canCollide) {
					Debug.Log ("hit ship");
					if (GameObject.Find ("ship").GetComponent<lifeScript> ().canDamage) {
						AudioSource.PlayClipAtPoint (damageSnd, currAsteroidObj.transform.position);
						GameObject.Find ("ship").GetComponent<lifeScript> ().canDamage = false;
						Destroy (GameObject.Find ("ship").GetComponent<lifeScript> ().lives [GameObject.Find ("ship").GetComponent<lifeScript> ().livesIndex]);
						GameObject.Find ("ship").GetComponent<lifeScript> ().livesIndex--;
						if (GameObject.Find ("ship").GetComponent<lifeScript> ().livesIndex < 0) {
							UpdateScore ();
							SceneManager.LoadScene (2);
						}
						StartCoroutine (flash ());
					}
				} 
				else if (bullet != null) {
					if (CircleCollision (bullet, currAsteroidObj) && currAsteroidObj.GetComponent<asteroidScript> ().canCollide) {
						if (GameObject.Find (currAsteroid).tag == "asteroidL1") {
							AudioSource.PlayClipAtPoint (bigExplosion, currAsteroidObj.transform.position);
							ship.GetComponent<vehicleScript> ().canShoot = true;
							//increase score
							GameObject score = GameObject.Find ("scoreText");
							string scoreText = score.GetComponent<TextMesh> ().text;
							int scoreVal = 0;
							int.TryParse (scoreText, out scoreVal);
							scoreVal += 20;
							score.GetComponent<TextMesh> ().text = "" + scoreVal;
							Destroy (bullet);
							bullet = null;
							GameObject a21 = Instantiate (asteroidL2, GameObject.Find (currAsteroid).transform.position, Quaternion.identity);
							GetComponent<spawnerScript> ().asteroidnum++;
							a21.name = "asteroid" + GetComponent<spawnerScript> ().asteroidnum;
							//asteroidList.Add (a21);
							GameObject a22 = Instantiate (asteroidL2, GameObject.Find (currAsteroid).transform.position, Quaternion.identity);
							GetComponent<spawnerScript> ().asteroidnum++;
							a22.name = "asteroid" + GetComponent<spawnerScript> ().asteroidnum;
							currAsteroidObj.GetComponent<asteroidScript> ().canCollide = false;
							currAsteroidObj.GetComponent<SpriteRenderer> ().enabled = false;
							//asteroidList.Add (a21);
							//asteroidList.Remove (go);
							//Destroy (GameObject.Find (currAsteroid));
						}
						else if (GameObject.Find (currAsteroid).tag == "asteroidL2" && currAsteroidObj.GetComponent<asteroidScript> ().canCollide) {
							AudioSource.PlayClipAtPoint (smallExplosion, currAsteroidObj.transform.position);
							ship.GetComponent<vehicleScript> ().canShoot = true;
							//increase score
							GameObject score = GameObject.Find ("scoreText");
							string scoreText = score.GetComponent<TextMesh> ().text;
							int scoreVal = 0;
							int.TryParse (scoreText, out scoreVal);
							scoreVal += 50;
							score.GetComponent<TextMesh> ().text = "" + scoreVal;
							//GameObject go2del = go;
							//asteroidList.Remove (go);
							//Destroy (GameObject.Find (currAsteroid));
							currAsteroidObj.GetComponent<asteroidScript> ().canCollide = false;
							currAsteroidObj.GetComponent<SpriteRenderer> ().enabled = false;
							Destroy (bullet);
							bullet = null;
						}
					} 
				}

			}
		}
	}

		


	IEnumerator flash(){
		ship.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSecondsRealtime (0.2f);
		ship.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSecondsRealtime (0.2f);
		ship.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSecondsRealtime (0.2f);
		ship.GetComponent<SpriteRenderer> ().enabled = true;
		ship.GetComponent<lifeScript>().canDamage = true;
	}

	void UpdateScore(){
		BinaryWriter bw = new BinaryWriter (File.Open("data", FileMode.OpenOrCreate));
		int scoreVal = -1;
		int.TryParse (GameObject.Find ("scoreText").GetComponent<TextMesh> ().text, out scoreVal);
		Debug.Log (scoreVal);
		bw.Write (scoreVal);
		bw.Close ();
	}

	/// <summary>
	/// Uses the circle collision type
	/// </summary>
	/// <returns><c>true</c>, if collision is detected, <c>false</c> otherwise.</returns>
	/// <param name="a">The first GameObject that is colliding</param>
	/// <param name="b">The second GameObject that is colliding</param>
	bool CircleCollision(GameObject a, GameObject b){
		SpriteRenderer aSR = a.GetComponent<SpriteRenderer> ();
		Vector3 centerA = aSR.bounds.center;
		float radiusA = (aSR.bounds.max.x - aSR.bounds.min.x) / 2f;

		SpriteRenderer bSR = b.GetComponent<SpriteRenderer> ();
		Vector3 centerB = bSR.bounds.center;
		float radiusB = (bSR.bounds.max.x - bSR.bounds.min.x) / 2f;

		Vector3 distance = centerA - centerB;

		if (distance.sqrMagnitude < (Mathf.Pow (radiusA, 2) + Mathf.Pow (radiusB, 2))) {
			return true;
		}

		return false;
	}

	/// <summary>
	/// Uses AABB (rectangle) collision type
	/// </summary>
	/// <returns><c>true</c>, if collision is detected, <c>false</c> otherwise.</returns>
	/// <param name="a">The first GameObject that is colliding</param>
	/// <param name="b">The second gameobject that is colliding</param>
	bool AABBCollision(GameObject a, GameObject b){
		SpriteRenderer aSR = a.GetComponent<SpriteRenderer> ();
		float minAx = aSR.bounds.min.x;
		float maxAx = aSR.bounds.max.x;
		float minAy = aSR.bounds.min.y;
		float maxAy = aSR.bounds.max.y;

		SpriteRenderer bSR = b.GetComponent<SpriteRenderer> ();
		float minBx = bSR.bounds.min.x;
		float maxBx = bSR.bounds.max.x;
		float minBy = bSR.bounds.min.y;
		float maxBy = bSR.bounds.max.y;

		if (minBx < maxAx && minAx < maxBx && minBy < maxAy && minAy < maxBy) {
			return true;
		}

		return false;
	}
}
