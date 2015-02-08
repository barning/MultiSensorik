using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {

	private RealSpace3D.RealSpace3D_AudioSource theAudioSource = null;

	public GameObject licht;
	public GameObject wolken;
	public GameObject regen;
	public GameObject theCamera;
	public GameObject theCameraLeft;
	public GameObject theCameraRight;
	public AudioClip thunderOne;
	public AudioClip thunderTwo;
	public AudioClip glitchSound;
	//Monsters
	public GameObject[] monsters;
	int monsterSoundCounter = 0;

	
	public AudioSource niceDay;
	public AudioSource stormDay;
	public AudioSource thunderAudio;
	public AudioSource theGlitch;


	public float smooth;
	public float cameraFade;

	float lastTimer;
	float lastRainTimer;
	float lastMonsterTimer;
	public float randLight = 6f;
	bool unwetter = false;
	bool glitchEffect = false;

	public float skySmooth;
	float skyboxFader;

	Color startFogCol;
	Color cameraColor;
	public Color endFogCol;
	public Color endCameraCol;

	// Use this for initialization
	void Start () {
		theCamera.GetComponent<GlitchEffect>().enabled = false;
		blendSkybox (0);
		niceDay.Play();
		stormDay.volume = 0f;
		stormDay.Play ();

		RenderSettings.fogColor = startFogCol;
		startFogCol = RenderSettings.fogColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "LowPolyWald") {
			if (Time.timeSinceLevelLoad >= 60 && Time.timeSinceLevelLoad <= 61) {
								if (unwetter == false) {
										niceDay.volume = 0f;
										stormDay.volume = 1f;
										licht.animation.Play ("Light");
										RenderSettings.fogColor = Color.Lerp (startFogCol, endFogCol, smooth * Time.deltaTime);
										theCamera.camera.backgroundColor = endCameraCol;
										theCameraLeft.camera.backgroundColor = endCameraCol;
										theCameraRight.camera.backgroundColor = endCameraCol;
								}
								theGlitch.clip = glitchSound;
								theGlitch.Play ();
								theCamera.GetComponent<GlitchEffect> ().enabled = true;
								theCameraLeft.GetComponent<GlitchEffect> ().enabled = true;
								theCameraRight.GetComponent<GlitchEffect> ().enabled = true;
								glitchEffect = true;
								unwetter = true;
						}

						if (theGlitch.isPlaying == false && glitchEffect) {
								theCamera.GetComponent<GlitchEffect> ().enabled = false;
								theCameraLeft.GetComponent<GlitchEffect> ().enabled = false;
								theCameraRight.GetComponent<GlitchEffect> ().enabled = false;
								glitchEffect = false;
						}

						if (unwetter == true) {
				if (skyboxFader <= 1.5) {
					skyboxFader += skySmooth;
				}
				blendSkybox (skyboxFader);
								if (Time.timeSinceLevelLoad - lastRainTimer > 5) {
										niceDay.Stop ();
										regen.particleSystem.Play ();
										lastRainTimer = Time.timeSinceLevelLoad;
								}

								if (Time.timeSinceLevelLoad - lastTimer > randLight + 5 && thunderAudio.isPlaying == false) {
										int range = Random.Range (0, 10);
										if (range <= 5) {
												thunderAudio.clip = thunderOne;
										}
										if (range >= 5) {
												thunderAudio.clip = thunderTwo;
										}
										thunderAudio.Play ();
										licht.light.intensity = 3f;
										licht.light.color = Color.white;
										lastTimer = Time.realtimeSinceStartup;
										randLight = Random.Range (1f, 8f);
								} else {
										licht.light.intensity = 0f;
								}

				if (Time.timeSinceLevelLoad - lastMonsterTimer > 16) {
										monsterSounds (monsterSoundCounter);
										monsterSoundCounter++;
										lastMonsterTimer = Time.timeSinceLevelLoad;
								}
						}
				}
	}

	void monsterSounds(int theMonster){
		//monsters[theMonster].audio.Play();
		theAudioSource = monsters[theMonster].GetComponent("RealSpace3D_AudioSource") as RealSpace3D.RealSpace3D_AudioSource;
		theAudioSource.rs3d_PlaySound();
		print ("Monster");
		}
	void blendSkybox (float blend) {
		float temp = blend;
		RenderSettings.skybox.SetFloat ("_Blend", temp);
	}
	
}