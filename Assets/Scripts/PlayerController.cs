using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed = 2.0f;
	public float tilt = 45.0f;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	public Boundary boundary;


	public GameObject shot;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody> ();
	}


	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		this.rb.velocity = this.speed * movement;

		this.rb.position = this.boundary.Constrain (this.rb.position);

		this.rb.rotation = Quaternion.Euler(0, 0, -moveHorizontal * this.tilt);
	}

	void Update() {
		float t = Time.time;
		if(t > this.nextFire && Input.GetButton("Fire1")) {
			this.nextFire = t + this.fireRate;
			Instantiate<GameObject> (this.shot, this.shotSpawn.position, this.shotSpawn.rotation);
		}

	}
}
