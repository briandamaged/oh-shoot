using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, this.lifetime);
	}
}
