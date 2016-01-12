using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public string SceneName;
	public AudioClip[] speakers;
	public GameObject theCanvas;
	public AudioSource speakerSource;
	//public Transform OVRCameraController;

	public GameObject fpsCamera;
	//public GameObject hmdCamera;

	int voiceCounter = 0;
	int levelCounter;
	bool wasPlayed = false;
	bool oculusPresent=false;
	// Use this for initialization

	void CheckOculusPresence() {
		//oculusPresent=Ovr.Hmd.Detect() > 0;
	}

	void Start () {
		CheckOculusPresence();
		//OVRManager.HMDAcquired+=CheckOculusPresence;
		//OVRManager.HMDLost+=CheckOculusPresence;
		levelCounter = Application.loadedLevel +1;
		print("Level is "+levelCounter);
		Cursor.visible = false;
		wasPlayed = false;

		if (!oculusPresent) {
						fpsCamera.SetActive (true);
						//hmdCamera.SetActive (false);
				} else {
					fpsCamera.SetActive (false);
					//hmdCamera.SetActive (true);
				}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			loadLevel();
		}

		///THIS IS FOR LEVEL 0
		if (Application.loadedLevel == 0) {

				}

		///THIS IS FOR LEVEL 1
		if (Application.loadedLevel == 0)
		{
			if (!wasPlayed && Time.timeSinceLevelLoad >= 8){
				if (speakers != null){
					theSpeaker(0);
					wasPlayed = true;
					print(wasPlayed);
				}
			}
			if (Time.timeSinceLevelLoad >= 30) {
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
			if (!wasPlayed && Time.timeSinceLevelLoad >= 55 && Time.timeSinceLevelLoad <= 56){
				if (speakers != null){
					theSpeaker(1);
					wasPlayed = true;
				}
			}

			if (Time.timeSinceLevelLoad >= 70 && Time.timeSinceLevelLoad <= 72){
				wasPlayed = false;
			}

			if (!wasPlayed && Time.timeSinceLevelLoad >= 110 && Time.timeSinceLevelLoad <= 111){
				theSpeaker(2);
				wasPlayed = true;
			}
			if (Time.timeSinceLevelLoad >= 115) {
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
			if (oculusPresent){
				//OVRCameraController.GetComponent<fadeInOut>().levelToLoad = nextlevel;
				//OVRCameraController.GetComponent<fadeInOut>().changeLevelFade = true;
			}
			else {
				//Autofade.LoadLevel(nextlevel ,3,3,Color.white);
				fading.Instance.StartFade(SceneName);
			}
			FadeOutMusic();
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
