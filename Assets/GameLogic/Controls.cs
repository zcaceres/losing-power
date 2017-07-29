using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	private bool flashlightOn;
	void Start () {
		flashlightOn = false;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			flashlightOn = !flashlightOn;
			Debug.Log("Flashlight is: " + flashlightOn);
		}
	}
}
