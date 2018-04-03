using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollisionEnter2D(Collision2D col){
		/*if (col.gameObject.name.Contains ("ship")) {
			col.gameObject.GetComponent<vehicleScript> ().canShoot = true;
			//lose life, flash ship to show damage
		}//
		if (col.gameObject.name.Contains ("asteroidL1")) {
			GameObject.Find ("ship").GetComponent<vehicleScript> ().canShoot = true;
			//increase score
			GameObject score = GameObject.Find("scoreText");
			string scoreText = score.GetComponent<TextMesh> ().text;
			int scoreVal = 0;
			int.TryParse (scoreText, out scoreVal);
			scoreVal += 20;
			score.GetComponent<TextMesh> ().text = "" + scoreVal;
		}
		else if (col.gameObject.name.Contains ("asteroidL2")) {
			GameObject.Find ("ship").GetComponent<vehicleScript> ().canShoot = true;
			//increase score
			GameObject score = GameObject.Find("scoreText");
			string scoreText = score.GetComponent<TextMesh> ().text;
			int scoreVal = 0;
			int.TryParse (scoreText, out scoreVal);
			scoreVal += 50;
			score.GetComponent<TextMesh> ().text = "" + scoreVal;
		}

		if (!col.gameObject.name.Contains ("ship")) {
			Destroy (col.gameObject);
			Destroy (gameObject);
		}

	}*/

	IEnumerator delay(){
		yield return new WaitForSecondsRealtime(1);
		GameObject.Find ("ship").GetComponent<vehicleScript> ().canShoot = true;
		Destroy (gameObject);
	}
}
