using UnityEngine;
using System.Collections;

public class Unwetter : MonoBehaviour {
	public GameObject Wind1;
	public GameObject Wind2;
	public GameObject Wind3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Wind1.SetActive(false);
			Wind2.SetActive(false);
			Wind3.SetActive(false);
				}
		if (Input.GetKeyDown ("h")) {
			Wind1.SetActive(true);
			Wind2.SetActive(true);
			Wind3.SetActive(true);
				}
	}
}
