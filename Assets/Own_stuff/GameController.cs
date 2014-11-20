using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			loadLevel();
		}
	}

	void loadLevel() {
		if (Application.loadedLevel == 0) {
			Application.LoadLevel ("Wald");
			} else {
			Application.LoadLevel ("Room");
				}
	}
}
