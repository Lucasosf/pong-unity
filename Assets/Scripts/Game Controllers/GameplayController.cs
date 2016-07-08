using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	void Awake () {
		Time.timeScale = 0f;
	}

	public void StartGame() {
		Time.timeScale = 1f;
	}

	public static void PauseGame() {
		Time.timeScale = 0f;
	}
}
