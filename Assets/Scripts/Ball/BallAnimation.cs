using UnityEngine;
using System.Collections;

public class BallAnimation : MonoBehaviour {

	private static float angle = 0f;
	private bool IsMovingUp = true;
	private float speed = 4f;
	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.gravityScale = 0f;
		transform.position = new Vector3 (0, 0, 0);
	}

	void FixedUpdate () {
		if (IsMovingUp) {
			MoveUp ();
		} else {
			MoveDown ();
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Goal") {
			ChangeDirection ();
			MoveToRandomAngle ();
		}

		if (target.tag == "Bound") {
			BallAnimation.InvertAngle ();
		}
	}

	public void ChangeDirection() {
		IsMovingUp = !IsMovingUp;
	}

	public void MoveToRandomAngle() {
		angle = Random.Range (0f, 5f);
	}

	public static void InvertAngle() {
		angle = angle * -1f;
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
