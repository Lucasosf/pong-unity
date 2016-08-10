using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public int enemy;
	public int player;

	public Text enemyScoreboard;
	public Text playerScoreboard;

	public GameObject gameOverPanel;
	public Text enemyWinnerText;
	public Text playerWinnerText;

	void MakeSingleton () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void Start () {
		MakeSingleton ();
		ScoreManager.Reset ();
	}

	public static void PointToPlayer() {
		ScoreManager.instance.player += 1;
		ScoreManager.FillScoreboards ();
		ScoreManager.CheckForGameOver ();
	}

	public static void PointToEnemy() {
		ScoreManager.instance.enemy += 1;
		ScoreManager.FillScoreboards ();
		ScoreManager.CheckForGameOver ();
	}

	public static void FillScoreboards() {
		ScoreManager.instance.enemyScoreboard.text = ScoreManager.instance.enemy.ToString ();
		ScoreManager.instance.playerScoreboard.text = ScoreManager.instance.player.ToString ();
	}

	public static void Reset() {
		ScoreManager.instance.enemy = 0;
		ScoreManager.instance.player = 0;
		ScoreManager.instance.gameOverPanel.SetActive (false);
		ScoreManager.FillScoreboards ();
	}

	public static void CheckForGameOver () {
		if (ScoreManager.instance.enemy > 2 || ScoreManager.instance.player > 2) {
			Time.timeScale = 0f;
			ScoreManager.instance.gameOverPanel.SetActive (true);

			if (ScoreManager.instance.enemy > 2) {
				ScoreManager.instance.enemyWinnerText.text = "Winner";
				ScoreManager.instance.playerWinnerText.text = "Loser";
			} else {
				ScoreManager.instance.enemyWinnerText.text = "Loser";
				ScoreManager.instance.playerWinnerText.text = "Winner";
			}
		}
	}
}
