using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;

	public float speed = 2.0f;
	public float tilt = 45.0f;

	public Boundary boundary;


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
}
