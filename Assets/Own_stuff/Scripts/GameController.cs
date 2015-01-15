using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public AudioClip Welcome;
	public AudioClip Explain;
	public AudioClip Ready;
	public AudioClip OkGo;
	int voiceCounter = 0;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire3")) {
			theSpeaker(voiceCounter);
			voiceCounter++;
			print(voiceCounter);
		}
		if (Input.GetButton("Fire1")) {
			loadLevel();
		}
	}

	void loadLevel() {
		Application.LoadLevel( Application.loadedLevel + 1 );
	}

	void theSpeaker(int number) {

		if (number == 0) {
			audio.PlayOneShot(Welcome);
		}
		if (number == 1) {
			audio.PlayOneShot(Explain);
		}
		if (number == 2) {
			audio.PlayOneShot(Ready);
		}
		if (number == 3) {
			audio.PlayOneShot(OkGo);
		}
	}
	
}
