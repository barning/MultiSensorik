using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			loadLevel();
		}
	}

	void loadLevel() {
		if (Application.loadedLevel != 2){
			int nextlevel = Application.loadedLevel + 1;
			Autofade.LoadLevel(nextlevel ,3,1,Color.white);
		}
	}
	
}
