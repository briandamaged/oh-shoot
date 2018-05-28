using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text gameOverText;
	public Text restartText;
	private bool gameOver;

	public Text scoreText;
	private int score;

	public GameObject[] asteroids;

	public float minX;
	public float maxX;
	public float initialZ;

	public int hazardCount;

	public float minGenWait = 0.3f;
	public float maxGenWait = 0.7f;

	public float waveWait = 2.0f;


	void Start() {
		this.gameOver = false;
		this.score = 0;

		this.UpdateUI ();

		this.SpawnWaves ();
		StartCoroutine (this.SpawnWaves ());
	}

	void Update() {
		if(this.gameOver && Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
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
				GameObject prefab = this.asteroids[Random.Range(0, this.asteroids.Length)];
				GameObject h = Instantiate<GameObject> (prefab, spawnPosition, spawnRotation);
				DestroyByContact dbc = h.GetComponent<DestroyByContact> ();
				dbc.gameController = this;


				yield return new WaitForSeconds (Random.Range (this.minGenWait, this.maxGenWait));
			}

			yield return new WaitForSeconds (this.waveWait);
		}
	}

	void UpdateUI() {
		this.UpdateGameOver ();
		this.UpdateScore ();
	}

	void UpdateGameOver() {
		this.gameOverText.text = (this.gameOver ? "GAME OVER" : "");
		this.restartText.text = (this.gameOver ? "Press \"R\" to restart" : "");
	}

	public void LoseGame() {
		this.gameOver = true;
		this.UpdateGameOver ();
	}

	void UpdateScore() {
		this.scoreText.text = "Score: " + this.score;
	}

	public void AddScore(int increment = 1) {
		this.score += increment;
		this.UpdateScore ();
	}
}
