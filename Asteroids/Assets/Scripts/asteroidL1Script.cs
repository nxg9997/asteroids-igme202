using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidL1Script : MonoBehaviour {

	public GameObject asteroidL2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name.Contains ("bullet")) {
			GameObject a21 = Instantiate (asteroidL2, transform.position, Quaternion.identity);
			GameObject a22 = Instantiate (asteroidL2, transform.position, Quaternion.identity);
		}
	}
}
