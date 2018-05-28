using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSizer : MonoBehaviour {

	public float minScale = 0.5f;
	public float maxScale = 2.0f;

	// Use this for initialization
	void Start () {
		float s = Random.Range (minScale, maxScale);

		this.transform.localScale = new Vector3 (s, s, s);
	}
}
