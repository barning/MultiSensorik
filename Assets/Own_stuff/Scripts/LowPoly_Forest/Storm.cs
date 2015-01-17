using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {

	public GameObject licht;
	public GameObject wolken;
	public GameObject regen;
	public GameObject theCamera;
	public GameObject theCameraLeft;
	public GameObject theCameraRight;
	public AudioClip thunderOne;
	public AudioClip thunderTwo;

	//Monsters
	public GameObject dantzMonster;
	public GameObject nilsMonster;
	public GameObject cliophateMonster;
	
	public AudioSource niceDay;
	public AudioSource stormDay;
	public AudioSource thunderAudio;

	public float smooth;
	public float cameraFade;

	float lastTimer;
	float lastRainTimer;
	public float randLight = 6f;
	bool unwetter = false;

	public float skySmooth;
	float skyboxFader;

	Color startFogCol;
	Color cameraColor;
	public Color endFogCol;
	public Color endCameraCol;

	// Use this for initialization
	void Start () {
		blendSkybox (0);
		niceDay.Play();
		stormDay.volume = 0f;
		stormDay.Play ();
		cameraColor = theCamera.camera.backgroundColor;

		RenderSettings.fogColor = startFogCol;
		startFogCol = RenderSettings.fogColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("h")) {
			if (unwetter == false){
				niceDay.volume = 0f;
				stormDay.volume = 1f;
				licht.animation.Play("Light");
				RenderSettings.fogColor = Color.Lerp(startFogCol,endFogCol,smooth * Time.deltaTime);
				theCamera.camera.backgroundColor= endCameraCol;
				theCameraLeft.camera.backgroundColor= endCameraCol;
				theCameraRight.camera.backgroundColor= endCameraCol;
			}
			unwetter = true;
		}

		if (unwetter == true) {

			if(!regen.particleSystem.isPlaying && Time.timeSinceLevelLoad - lastRainTimer > 5){
				regen.particleSystem.Play();
				lastRainTimer = Time.realtimeSinceStartup;
			}

			if (skyboxFader <=1.5){
				skyboxFader += skySmooth;
			}
			blendSkybox (skyboxFader);

			int monsterRandom = Random.Range(0,15);
			if (Time.timeSinceLevelLoad - lastTimer > randLight+5 && thunderAudio.isPlaying == false){
				int range = Random.Range(0,10);
				if (range <= 5){
					thunderAudio.clip = thunderOne;
				}
				if (range >= 5){
					thunderAudio.clip = thunderTwo;
				}
				thunderAudio.Play();
				licht.light.intensity = 3f;
				licht.light.color = Color.white;
				lastTimer = Time.realtimeSinceStartup;
				randLight = Random.Range(1f,8f);
			}
			else {
				licht.light.intensity = 0f;
			}

			if (Time.timeSinceLevelLoad - lastTimer > 5){
				if (monsterRandom >=0 && monsterRandom >=4 && dantzMonster.audio.isPlaying == false){
					dantzMonster.audio.Play();
					print("DANTZ");
				}
				if (monsterRandom >=5 && monsterRandom >=9 && nilsMonster.audio.isPlaying == false){
					nilsMonster.audio.Play();
					print("NILS");
				}
				if (monsterRandom >=10 && monsterRandom >=15 && cliophateMonster.audio.isPlaying == false){
					cliophateMonster.audio.Play();
					print("KEVIN");
				}
			}
		}
	
	}

	void blendSkybox (float blend) {
		float temp = blend;
		RenderSettings.skybox.SetFloat ("_Blend", temp);
	}
	
}
