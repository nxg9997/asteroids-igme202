using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour {

	public float speed;
	Vector3 direction;
	Vector3 Position;

	public bool canCollide = true;

	// Use this for initialization
	void Start () {
		float randDir = Random.Range (0, 361);
		float randDirRad = Mathf.Deg2Rad * randDir;
		float dirX = Mathf.Cos (randDirRad);
		float dirY = Mathf.Sin (randDirRad);
		direction = new Vector3 (dirX, dirY);
		direction.Normalize ();
		Position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Position += speed * direction;
		gameObject.transform.position = Position;

		//screen wrapping
		if (Position.x > 16.59f) {
			Position = new Vector3(-16.59f, Position.y);
		}
		if (Position.x < -16.59f) {
			Position = new Vector3(16.59f, Position.y);
		}

		if (Position.y > 9f) {
			Position = new Vector3(Position.x, -9f);
		}
		if (Position.y < -9f) {
			Position = new Vector3(Position.x, 9f);
		}
	}
}
