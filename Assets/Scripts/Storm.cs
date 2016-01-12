using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {
	

	public GameObject licht;
	public GameObject regen;
	public GameObject theCamera;
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

	public Skybox sky;

	Color startFogCol;
	Color cameraColor;
	public Color endFogCol;
	public Color endCameraCol;

	// Use this for initialization
	void Start () {
		//sky = GetComponent<Skybox> ();
		theCamera.GetComponent<GlitchEffect>().enabled = false;
		niceDay.Play();
		stormDay.volume = 0f;
		stormDay.Play ();

		RenderSettings.fogColor = startFogCol;
		startFogCol = RenderSettings.fogColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "forest") {
			if (Time.timeSinceLevelLoad >= 60 && Time.timeSinceLevelLoad <= 61) {
								if (unwetter == false) {
										niceDay.volume = 0f;
										stormDay.volume = 1f;
										licht.GetComponent<Animation>().Play ("Light");
										RenderSettings.fogColor = Color.Lerp (startFogCol, endFogCol, smooth * Time.deltaTime);
										theCamera.GetComponent<Camera>().backgroundColor = endCameraCol;
								}
								theGlitch.clip = glitchSound;
								theGlitch.Play ();
								theCamera.GetComponent<GlitchEffect> ().enabled = true;
								//theCameraLeft.GetComponent<GlitchEffect> ().enabled = true;
								//theCameraRight.GetComponent<GlitchEffect> ().enabled = true;
								glitchEffect = true;
								unwetter = true;
						}

						if (theGlitch.isPlaying == false && glitchEffect) {
								theCamera.GetComponent<GlitchEffect> ().enabled = false;
								//theCameraLeft.GetComponent<GlitchEffect> ().enabled = false;
								//theCameraRight.GetComponent<GlitchEffect> ().enabled = false;
								glitchEffect = false;
						}

						if (unwetter == true) {
							blendSkybox ();
								if (Time.timeSinceLevelLoad - lastRainTimer > 5) {
										niceDay.Stop ();
										regen.GetComponent<ParticleSystem>().Play ();
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
										licht.GetComponent<Light>().intensity = 3f;
										licht.GetComponent<Light>().color = Color.white;
										lastTimer = Time.realtimeSinceStartup;
										randLight = Random.Range (1f, 8f);
								} else {
										licht.GetComponent<Light>().intensity = 0f;
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
		monsters [theMonster].GetComponent<AudioSource> ().Play ();
		print ("Monster");
		}
	void blendSkybox () {
		sky.material.SetFloat ("_Exposure", 0.15f);
	}
	
}