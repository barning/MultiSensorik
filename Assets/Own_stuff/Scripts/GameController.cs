using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public AudioClip[] speakers;
	public GameObject theCanvas;
	public AudioSource speakerSource;
	public Transform OVRCameraController;
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

		///THIS IS FOR LEVEL 1
		if (Application.loadedLevel == 0)
		{
			if (!theCanvas.animation.isPlaying && !wasPlayed && Time.timeSinceLevelLoad >= 8){
				if (speakers != null){
					theSpeaker(0);
					wasPlayed = true;
				}
			}
			if (Time.timeSinceLevelLoad >= 30) {
				loadLevel();
				loadLevel();
			}
		}
		/////////
		/// 
		///THIS IS FOR LEVEL 2
		if (Application.loadedLevel == 1)
		{
			if (!wasPlayed && Time.timeSinceLevelLoad >= 8 && Time.timeSinceLevelLoad <= 9){
				if (speakers != null){
					theSpeaker(0);
					wasPlayed = true;
				}
			}
			if (Time.timeSinceLevelLoad >= 20 && Time.timeSinceLevelLoad <= 22){
				wasPlayed = false;
			}
			if (!wasPlayed && Time.timeSinceLevelLoad >= 85 && Time.timeSinceLevelLoad <= 86){
				if (speakers != null){
					theSpeaker(1);
					wasPlayed = true;
				}
			}

			if (Time.timeSinceLevelLoad >= 100 && Time.timeSinceLevelLoad <= 102){
				wasPlayed = false;
			}

			if (!wasPlayed && Time.timeSinceLevelLoad >= 160 && Time.timeSinceLevelLoad <= 161){
				theSpeaker(2);
				wasPlayed = true;
			}
			if (Time.timeSinceLevelLoad >= 167) {
				loadLevel();
			}
		}
		/////////
		/// 
		/// ///THIS IS FOR LEVEL 2
		if (Application.loadedLevel == 2) {
			if (!wasPlayed && Time.timeSinceLevelLoad >= 0 && Time.timeSinceLevelLoad <= 1){
				theSpeaker(0);
				wasPlayed = true;
				print("Erster");
			}
		}
		/// 

	}
	
	void theSpeaker(int number) {
		speakerSource.PlayOneShot(speakers[number]);
	}

	void loadLevel() {
		if (Application.loadedLevel != 2){
			int nextlevel = Application.loadedLevel + 1;
			OVRCameraController.GetComponent<fadeInOut>().levelToLoad = nextlevel;
			OVRCameraController.GetComponent<fadeInOut>().changeLevelFade = true;
			FadeOutMusic();
			//Autofade.LoadLevel(nextlevel ,3,3,Color.white);
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
