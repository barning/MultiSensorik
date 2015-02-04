using UnityEngine;
using System.Collections;

public class fadeInOut : MonoBehaviour {
	public Transform blackoutCubeL;
	public Transform blackoutCubeR;

	public bool fade;
	public bool changeLevelFade;

	public int levelToLoad;
	
	private float fadeToDarkTimer;
	private float fadeTolightTimer;

	private Color startColor;
	private Color endColor;
	
	private bool changingLevel;
	// Use this for initialization
	void Start () {
		startColor = new Color(0, 0, 0, 0);
		endColor = new Color(0, 0, 0, 1);
		
		fadeToDarkTimer = 0;
		fadeTolightTimer = 0;
		fade = false;
		changingLevel = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fade == true || changeLevelFade == true) {
			
			if (blackoutCubeL.renderer.material.color == startColor) {
				
				fadeTolightTimer = 0;
				
			}
			
			fadeToDarkTimer += Time.deltaTime;
			blackoutCubeL.renderer.material.color = Color.Lerp(startColor, endColor, fadeToDarkTimer);
			blackoutCubeR.renderer.material.color = Color.Lerp(startColor, endColor, fadeToDarkTimer);
			
			if (blackoutCubeL.renderer.material.color == endColor && changingLevel == false) {
				
				if (changeLevelFade == true) {
					changingLevel = true;
					Application.LoadLevel(levelToLoad);
					
				}
				
			}
			
			
		} else {
			
			if (blackoutCubeL.renderer.material.color == endColor) {
				
				fadeToDarkTimer = 0;
				
			}
			
			fadeTolightTimer += Time.deltaTime;
			blackoutCubeL.renderer.material.color = Color.Lerp(endColor, startColor, fadeTolightTimer);
			blackoutCubeR.renderer.material.color = Color.Lerp(endColor, startColor, fadeTolightTimer);
			
		}
	}
}
