using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	private static float angle = 0f;
	private static bool IsMovingUp = true;
	private static float speed;
	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.gravityScale = 0f;
		BallMovement.ResetSpeed ();
	}

	void FixedUpdate () {
		if (IsMovingUp) {
			MoveUp ();
		} else {
			MoveDown ();
		}
	}

	public static void ChangeDirection() {
		IsMovingUp = !IsMovingUp;
	}

	public static void MoveToRandomAngle() {
		angle = Random.Range (0f, 5f);
	}

	public static void InvertAngle() {
		angle = angle * -1f;
	}

	public static void SpeedUp(){
		speed += 0.5f;
	}

	public static void ResetSpeed() {
		speed = 2.8f;
	} 

	void MoveUp () {
		Vector3 position = transform.position;
		position.y += speed * Time.deltaTime * Time.timeScale;
		position.x += angle * Time.deltaTime * Time.timeScale;
		transform.position = position;
	}

	void MoveDown() {
		Vector3 position = transform.position;
		position.y -= speed * Time.deltaTime * Time.timeScale;
		position.x -= angle * Time.deltaTime * Time.timeScale;
		transform.position = position;
	}
}
