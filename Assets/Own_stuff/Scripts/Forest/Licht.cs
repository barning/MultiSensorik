using UnityEngine;
using System.Collections;

public class Licht : MonoBehaviour {
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

		if (Time.realtimeSinceStartup > 5) {
			licht.light.intensity = Mathf.Lerp(licht.light.intensity,0f,smooth * Time.deltaTime);
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
