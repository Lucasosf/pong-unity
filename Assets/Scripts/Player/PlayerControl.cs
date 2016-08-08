using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Rigidbody2D body;
	private float minX, maxX;
	private static float speed;

	[SerializeField]
	private string sideOfScreen;

	[SerializeField]
	private GameObject ball;

	public bool robot;

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		body.gravityScale = 0f;
		PlayerControl.ResetSpeed ();
	}

	void Start() {
		SetBounds ();
	}

	void FixedUpdate () {
		if (Robot ()) {
			FollowBall ();
		} else {
			MoveByTouches ();
		}
	}

	public static void SpeedUp() {
		speed += 0.3f;
	}

	public static void ResetSpeed() {
		speed = 0.5f;
	}

	bool Robot() {
		return (this.robot && GameManager.robot);
	}

	void FollowBall() {
		Vector3 position = transform.position;

		if (ball.transform.position.x > (transform.position.x - (transform.localScale.x / 2))) {
			position.x += speed * Time.deltaTime;
		} else if (ball.transform.position.x < (transform.position.x - (transform.localScale.x / 2))) {
			position.x -= speed * Time.deltaTime;
		}

		transform.position = position;
	}

	void MoveByTouches() {
		if (Input.touchCount > 0) {
			
			foreach(Touch touch in Input.touches) {
				//Debug.LogFormat ("touch x:{0} y:{1}", touch.position.x, touch.position.y);

				Vector3 position = Camera.main.ScreenToWorldPoint (touch.position);

				if (sideOfScreen == "Top") {
					if (position.y > 0) {
						FollowTouch (touch);
					}
				} else {
					if (position.y < 0) {
						FollowTouch (touch);
					}
				}
			}
		}
	}

	void FollowTouch(Touch touch) {
		if (transform.position.x < minX) {
			transform.position = transform.position = new Vector3 (minX, transform.position.y, 0);
		} else if (transform.position.x > maxX) {
			transform.position = transform.position = new Vector3 (maxX, transform.position.y, 0);
		} else {
			Vector3 position = Camera.main.ScreenToWorldPoint (touch.position);
			transform.position = new Vector3 (position.x, transform.position.y, 0);
		}
	}

	void SetBounds() {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = bounds.x;
		minX = -bounds.x;
	}

}
