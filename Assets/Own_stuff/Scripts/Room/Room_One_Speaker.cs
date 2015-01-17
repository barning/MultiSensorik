using UnityEngine;
using System.Collections;

public class Room_One_Speaker : MonoBehaviour {
	public AudioClip Welcome;
	public AudioClip Explain;
	public AudioClip Ready;
	public AudioClip OkGo;
	int voiceCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire3")) {
			theSpeaker(voiceCounter);
			voiceCounter++;
			print(voiceCounter);
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
}
