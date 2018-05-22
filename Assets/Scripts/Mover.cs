using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;

	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody> ();

		this.rb.velocity = this.speed * this.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
