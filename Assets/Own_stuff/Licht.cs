using UnityEngine;
using System.Collections;

public class Licht : MonoBehaviour {
	public GameObject licht;
	float blender = 0f;
	//float timer = Time.realtimeSinceStartup;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("y")) {
			licht.light.intensity = 0f;
			RenderSettings.fogColor = Color.black;
				}
		if (Input.GetKeyDown ("j")) {
			blendSkybox(blender);
			blender+=0.1f;
				}
	
	}

	void blendSkybox(float blending){
		RenderSettings.skybox.SetFloat ("_Blend", blending);
	}
}
