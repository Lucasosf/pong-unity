using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static bool robot;
	public static GameplayController instance;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private GameObject startButton;

	[SerializeField]
	private GameObject pauseButton;

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
		Time.timeScale = 0f;
		ScoreManager.Reset ();
	}

	public static void WaitForPlayer(){
		GameplayController.instance.startButton.SetActive (true);
		GameplayController.instance.pauseButton.SetActive (false);
		Time.timeScale = 0f;
	}

	public void StartGame() {
		pausePanel.SetActive (false);
		startButton.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1f;
	}

	public void PauseGame() {
		pausePanel.SetActive (true);
		startButton.SetActive (false);
		pauseButton.SetActive (false);
		Time.timeScale = 0f;
	}

	public void ExitGame () {
		Time.timeScale = 1f;
		Application.LoadLevel ("Menu");
	}

	public void RestartGame () {
		Time.timeScale = 1f;
		startButton.SetActive (false);
		pauseButton.SetActive (true);
		ScoreManager.Reset ();
		BallMovement.ResetSpeed ();
		PlayerControl.ResetSpeed ();
	}
}
