using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreText;
	private int score;


	public GameObject hazard;

	public float minX;
	public float maxX;
	public float initialZ;

	public int hazardCount;

	public float minGenWait = 0.3f;
	public float maxGenWait = 0.7f;

	public float waveWait = 2.0f;


	void Start() {
		this.score = 0;
		this.UpdateScore ();

		this.SpawnWaves ();
		StartCoroutine (this.SpawnWaves ());
	}

	IEnumerator SpawnWaves() {

		while(true) {

			for(int i = 0; i < this.hazardCount; ++i) {
				Vector3 spawnPosition = new Vector3 (Random.Range(minX, maxX), 0.0f, initialZ);
				Quaternion spawnRotation = Quaternion.identity;

				// FYI: In the tutorial, they had the DestroyByContact script obtain to reference
				//      to the GameController via the Start(...) method.  This meant that the
				//      DestroyByContact script relied upon a singleton object.  So, wiring things
				//      via the GameController itself just seemed a lot cleaner to me.
				GameObject h = Instantiate<GameObject> (this.hazard, spawnPosition, spawnRotation);
				DestroyByContact dbc = h.GetComponent<DestroyByContact> ();
				dbc.gameController = this;


				yield return new WaitForSeconds (Random.Range (this.minGenWait, this.maxGenWait));
			}

			yield return new WaitForSeconds (this.waveWait);
		}
	}


	void UpdateScore() {
		this.scoreText.text = "Score: " + this.score;
	}

	public void AddScore(int increment = 1) {
		this.score += increment;
		this.UpdateScore ();
	}
}
