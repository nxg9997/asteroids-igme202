using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class gameOverScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BinaryReader br = new BinaryReader (File.Open ("data", FileMode.Open));
		int scoreVal = br.ReadInt32();
		br.Close ();
		gameObject.GetComponent<TextMesh> ().text = "Score: " + scoreVal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
