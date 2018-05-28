using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;

	public float minX;
	public float maxX;
	public float initialZ;

	public int hazardCount;

	public float minGenWait = 0.3f;
	public float maxGenWait = 0.7f;

	public float waveWait = 2.0f;


	void Start() {
		this.SpawnWaves ();
		StartCoroutine (this.SpawnWaves ());
	}

	IEnumerator SpawnWaves() {

		while(true) {

			for(int i = 0; i < this.hazardCount; ++i) {
				Vector3 spawnPosition = new Vector3 (Random.Range(minX, maxX), 0.0f, initialZ);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (this.hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (Random.Range (this.minGenWait, this.maxGenWait));
			}

			yield return new WaitForSeconds (this.waveWait);
		}



	}
}
