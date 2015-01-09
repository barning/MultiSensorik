using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {

	public GameObject licht;
	public GameObject wolken;
	public GameObject regen;
	public GameObject theCamera;

	public float smooth;
	public float cameraFade;

	float lastTimer;
	float randLight = 6f;
	bool unwetter = false;

	public Color startFogCol;
	public Color endFogCol;
	public Color cameraColor;

	// Use this for initialization
	void Start () {
		RenderSettings.fogColor = startFogCol;
		theCamera.camera.clearFlags = CameraClearFlags.SolidColor;
		theCamera.camera.backgroundColor = cameraColor;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("h")) {
			if (unwetter == false){
				licht.animation.Play("Light");
				RenderSettings.fogColor = Color.Lerp(startFogCol,endFogCol,smooth * Time.deltaTime);
				theCamera.camera.backgroundColor= Color.Lerp(cameraColor,endFogCol,cameraFade*Time.deltaTime);

				if(!regen.particleSystem.isPlaying){
					regen.particleSystem.Play();
				}
			}
			unwetter = true;
		}

		if (unwetter == true) {
			if (Time.timeSinceLevelLoad - lastTimer > randLight){
				licht.light.intensity = 3f;
				licht.light.color = Color.white;
				lastTimer = Time.realtimeSinceStartup;
				randLight = Random.Range(1f,8f);
			}
			else {
				licht.light.intensity = 0f;
			}
		}
	
	}
}
