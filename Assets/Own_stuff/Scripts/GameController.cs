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
		//AudioSource[] sounds = FindObjectsOfType (typeof(AudioSource))as AudioSource[];
		//foreach (AudioSource audio in sounds) {
		//	audio.Stop();
		//		} 
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
