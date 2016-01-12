using UnityEngine;
using System.Collections;

public class CloudMove : MonoBehaviour {

	public float cloudSpeed;

	void Update() {
		float step = cloudSpeed * Time.deltaTime;
		transform.position += Vector3.back * step;
	}
}
