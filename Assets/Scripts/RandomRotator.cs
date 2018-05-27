using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble = 1.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody> ();

		this.rb.angularVelocity = Random.insideUnitSphere * this.tumble;
	}

}
