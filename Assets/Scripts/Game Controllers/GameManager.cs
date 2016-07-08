using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool robot;
	public static GameManager instance;

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
	}
}
