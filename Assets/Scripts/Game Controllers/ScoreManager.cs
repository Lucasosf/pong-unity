using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public int enemy;
	public int player;

	public Text enemyScoreboard;
	public Text playerScoreboard;

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

		Debug.LogFormat ("enemy: {0}, player: {1}", ScoreManager.instance.enemy, ScoreManager.instance.player);
	}

	public static void PointToEnemy() {
		ScoreManager.instance.enemy += 1;
		ScoreManager.FillScoreboards ();

		Debug.LogFormat ("enemy: {0}, player: {1}", ScoreManager.instance.enemy, ScoreManager.instance.player);
	}

	public static void FillScoreboards() {
		ScoreManager.instance.enemyScoreboard.text = ScoreManager.instance.enemy.ToString ();
		ScoreManager.instance.playerScoreboard.text = ScoreManager.instance.player.ToString ();
	}

	public static void Reset() {
		ScoreManager.instance.enemy = 0;
		ScoreManager.instance.player = 0;
		ScoreManager.FillScoreboards ();
	}
}
