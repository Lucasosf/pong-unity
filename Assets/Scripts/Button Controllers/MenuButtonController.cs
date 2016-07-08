using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour {

	public void PlayerVsRobot() {
		GameManager.robot = true;
		Application.LoadLevel("Gameplay");
	}

	public void PlayerVsPlayer() {
		GameManager.robot = false;
		Application.LoadLevel("Gameplay");
	}
}
