using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

	public Transform target;
	public float speed;
	public GameObject scrollObject;
	public GameObject theParticles;
	public GameObject theParticlesOVR;
	bool scrollPlayed = true;

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		if (transform.position == target.position && scrollPlayed) {
			scrollObject.animation.Play();
			if (theParticles !=null && theParticlesOVR !=null){
				theParticles.particleEmitter.emit = false;
				theParticlesOVR.particleEmitter.emit = false;
				scrollPlayed = false;
			}
				}
	}

}
