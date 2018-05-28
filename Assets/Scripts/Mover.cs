using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;

	public float speed = 10.0f;

	public float disturbance = 0.1f;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody> ();

		float d = Random.Range (-this.disturbance, this.disturbance);
		this.rb.velocity = (this.speed * this.transform.forward) + (d * this.transform.right);
	}

}
