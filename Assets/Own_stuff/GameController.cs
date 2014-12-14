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
		preload ();
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
		if (Application.loadedLevel == 0) {
			Application.LoadLevel ("Wald");
			} else if (Application.loadedLevel == 1) {
				Application.LoadLevel ("Room_Wal");
			}
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

	IEnumerator preload() {
		AsyncOperation async = Application.LoadLevelAsync("Wald");
		yield return async;
		Debug.Log("Loading complete");
	}
}
