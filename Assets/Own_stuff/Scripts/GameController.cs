using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public AudioClip[] speakers;
	public GameObject theCanvas;
	int voiceCounter = 0;
	int levelCounter;
	bool wasPlayed = false;
	// Use this for initialization

	void Start () {
		levelCounter = Application.loadedLevel +1;
		print("Level is "+levelCounter);
		Screen.showCursor = false;
		wasPlayed = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			loadLevel();
		}
		print (Time.timeSinceLevelLoad);

		///THIS IS FOR LEVEL 1
		if (Application.loadedLevel == 0)
		{
			if (!theCanvas.animation.isPlaying && !wasPlayed && Time.timeSinceLevelLoad >= 8){
				theSpeaker(0);
				wasPlayed = true;
			}
		}
		if (levelCounter == 1 && Time.timeSinceLevelLoad >= 30) {
			loadLevel();
				}
		/////////
		/// 
		///THIS IS FOR LEVEL 2
		if (Application.loadedLevel == 1)
		{
			if (!wasPlayed && Time.timeSinceLevelLoad >= 8 && Time.timeSinceLevelLoad <= 9){
				theSpeaker(0);
				wasPlayed = true;
				print("Erster");
			}
			if (Time.timeSinceLevelLoad >= 20 && Time.timeSinceLevelLoad <= 22){
				wasPlayed = false;
				print("Mitte");
			}
			if (!wasPlayed && Time.timeSinceLevelLoad >= 100){
				theSpeaker(1);
				wasPlayed = true;
				print("Zweiter");
			}
		}
		/*if (levelCounter == 2 && Time.timeSinceLevelLoad >= 30) {
			loadLevel();
		}*/
		/////////
		
		if (Input.GetButtonDown("Fire3")) {
			theSpeaker(voiceCounter);
			voiceCounter++;
			print(voiceCounter);
		}
	}
	
	void theSpeaker(int number) {
		audio.PlayOneShot(speakers[number]);
	}

	void loadLevel() {
		if (Application.loadedLevel != 2){
			int nextlevel = Application.loadedLevel + 1;
			FadeOutMusic();
			Autofade.LoadLevel(nextlevel ,3,3,Color.white);
		}
	}

	public void FadeOutMusic()
	{
		StartCoroutine(FadeMusic());
	}
	IEnumerator FadeMusic()
	{
		AudioSource[] sounds = FindObjectsOfType (typeof(AudioSource))as AudioSource[];

		foreach (AudioSource audio in sounds) {
			if (audio != null) {
						while (audio.volume > .1F) {
								audio.volume = Mathf.Lerp (audio.volume, 0F, 0.3f*Time.deltaTime);
								yield return 0;
						}
						audio.volume = 0;
			if (audio.volume == 0){
				audio.Stop();
			}
			}
						//perfect opportunity to insert an on complete hook here before the coroutine exits.
				}
	}
	
}
