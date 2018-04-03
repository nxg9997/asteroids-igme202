using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class lifeScript : MonoBehaviour {

	public GameObject[] lives;

	public int livesIndex = 2;

	public bool canDamage = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name.Contains("asteroid") && canDamage){
			canDamage = false;
			Destroy (lives [livesIndex]);
			livesIndex--;
			if (livesIndex < 0) {
				UpdateScore ();
				SceneManager.LoadScene (2);
			}
			StartCoroutine (flash ());
		}
	}*/

	IEnumerator flash(){
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSecondsRealtime (0.2f);
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSecondsRealtime (0.2f);
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSecondsRealtime (0.2f);
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		canDamage = true;
	}

	void UpdateScore(){
		BinaryWriter bw = new BinaryWriter (File.Open("data", FileMode.OpenOrCreate));
		int scoreVal = -1;
		int.TryParse (GameObject.Find ("scoreText").GetComponent<TextMesh> ().text, out scoreVal);
		Debug.Log (scoreVal);
		bw.Write (scoreVal);
		bw.Close ();
	}
}
