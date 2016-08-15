using UnityEngine;
using System.Collections;

public class MenuButtonController : MonoBehaviour {

	public void PlayerVsRobot() {
		GameplayController.robot = true;
		Application.LoadLevel("Gameplay");
	}

	public void PlayerVsPlayer() {
		GameplayController.robot = false;
		Application.LoadLevel("Gameplay");
	}
}
