using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class vehicleScript : MonoBehaviour {

	//[SerializeField]
	public Vector3 Position;
	public float speed;
	public float maxSpeed;

	public Vector3 direction = new Vector3(1, 0, 0);
	public Vector3 velocity;
	public Vector3 acceleration;
	public float accelRate;
	public float deccelRate;
	public Quaternion Rotation;

	public float totalRotation;
	public float anglePerFrame;

	public GameObject bullet;
	public float bulletSpeed;

	public bool canShoot = true;

	public AudioClip fireSnd;

	// Use this for initialization
	void Start () {
		Position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		direction.Normalize ();

		Quaternion angle;

		//controls the rotation of the tank
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//direction.x = -1;
			totalRotation += anglePerFrame;
			angle = Quaternion.Euler(0,0,anglePerFrame);
			direction = angle * direction;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//direction.x = 1;
			totalRotation -= anglePerFrame;
			angle = Quaternion.Euler(0,0,-anglePerFrame);
			direction = angle * direction;
		}

		//controls acceleration and decceleration of the tank
		if (Input.GetKey (KeyCode.UpArrow)) {
			acceleration = accelRate * direction;
			velocity += acceleration;
		} 
		else {
			acceleration = deccelRate * velocity;
			velocity += acceleration;
			if (Mathf.Abs (velocity.magnitude) < .05) {
				velocity = Vector3.zero;
				acceleration = Vector3.zero;
			}
		}

		//screen wrapping
		if (Position.x > 10.59f) {
			Position = new Vector3(-10.59f, Position.y);
		}
		if (Position.x < -10.59f) {
			Position = new Vector3(10.59f, Position.y);
		}

		if (Position.y > 5.79f) {
			Position = new Vector3(Position.x, -5.79f);
		}
		if (Position.y < -5.79f) {
			Position = new Vector3(Position.x, 5.79f);
		}

		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);

		//applies velocity to position
		Position = Position + velocity;
		gameObject.transform.position = Position;
		gameObject.transform.rotation = Quaternion.Euler(0,0,totalRotation);

		//shoot a bullet
		if (Input.GetKeyDown (KeyCode.Space) && canShoot) {
			AudioSource.PlayClipAtPoint (fireSnd, gameObject.transform.position);
			GameObject newBullet = Instantiate (bullet, transform.position, Quaternion.identity);
			Vector3 newForce = direction * bulletSpeed;
			newBullet.GetComponent<Rigidbody2D> ().AddForce (newForce);
			GameObject.Find ("spawner").GetComponent<CollisionScript> ().bullet = newBullet;
			canShoot = false;
		}
	}
}
