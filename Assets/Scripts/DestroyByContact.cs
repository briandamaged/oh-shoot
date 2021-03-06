﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameController gameController;

	public int score = 1;

	public GameObject explosion;

	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") {
			return;
		}

		Instantiate (this.explosion, this.transform.position, this.transform.rotation);

		Destroy (other.gameObject);
		Destroy (this.gameObject);

		if(other.tag == "Player") {
			Instantiate (this.playerExplosion, other.transform.position, other.transform.rotation);
			this.gameController.LoseGame ();
		} else {
			this.gameController.AddScore (this.score);
		}

	}
}
