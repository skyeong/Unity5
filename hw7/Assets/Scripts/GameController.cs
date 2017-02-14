using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spwanWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameoverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start() 
	{
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameoverText.text = "";
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	void Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spwanWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart!";
				restart = true;
				break;
			}
		}
	}


	public void GameOver() 
	{
		gameoverText.text = "Game Over!";
		gameOver = true;
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
