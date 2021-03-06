﻿using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Player") {
			BallMovement.ChangeDirection ();
			BallMovement.MoveToRandomAngle ();
		}

		if (target.tag == "Bound") {
			BallMovement.InvertAngle ();
		}

		if (target.tag == "Goal") {
			if (transform.position.y > 0) {
				ScoreManager.PointToPlayer ();
			} else {
				ScoreManager.PointToEnemy ();
			}

			transform.position = new Vector3 (0, 0, 0);

			BallMovement.SpeedUp ();
			PlayerControl.SpeedUp ();
			GameplayController.WaitForPlayer ();
		}
	}
}