using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

	public Transform target;
	public float speed;
	public GameObject theParticles;
	public GameObject theParticlesOVR;
	bool scrollPlayed = true;

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		if (transform.position == target.position && scrollPlayed) {
			Application.Quit();
			if (theParticles !=null && theParticlesOVR !=null){
				theParticles.GetComponent<ParticleEmitter>().emit = false;
				theParticlesOVR.GetComponent<ParticleEmitter>().emit = false;
				scrollPlayed = false;
			}
				}
	}

}
