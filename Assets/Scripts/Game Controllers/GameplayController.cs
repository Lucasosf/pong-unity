using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	[SerializeField]
	private GameObject pausePanel;

	void Awake () {
		Time.timeScale = 0f;
	}

	public static void WaitForPlayer(){
		Time.timeScale = 0f;
	}

	public void StartGame() {
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	public void PauseGame() {
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ExitGame () {
		Time.timeScale = 1f;
		Application.LoadLevel ("Menu");
	}
}
