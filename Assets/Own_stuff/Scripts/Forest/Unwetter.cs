using UnityEngine;
using System.Collections;

public class Unwetter : MonoBehaviour {
	public GameObject Wind1;
	public GameObject Wind2;
	public GameObject Wind3;
	public GameObject Regen;

	public GameObject licht;
	public float smooth;
	float lastTimer;
	bool night = false;
	float randLight = 6f;
	// Use this for initialization
	void Start () {
		blendSkybox (0);
	}
	
	// Update is called once per frame
	void Update () {
		Screen.showCursor = false;

		if (Input.GetKeyDown ("h")) {
			Regen.animation.Play("Regen_Animation");
			Wind1.animation.Play("Wind_Animation");
			Wind2.animation.Play("Wind_Animation");
			Wind3.animation.Play("Wind_Animation");

			licht.light.intensity = Mathf.Lerp(licht.light.intensity,0f,smooth * Time.deltaTime);
			RenderSettings.fogColor= Color.black;
			blendSkybox (1);
			licht.animation.Play("Licht_Animation");
				}

		if (Time.realtimeSinceStartup > 15) {
			night=true;
		}
		if (night == true) {
			if (Time.realtimeSinceStartup - lastTimer > randLight){
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
	
	void blendSkybox (float blend) {
		float temp = blend;
		RenderSettings.skybox.SetFloat ("_Blend", temp);
	}
	
}