using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	private FlashlightController flashlightController;

	void Awake () {
		flashlightController = transform.Find("Flashlight").gameObject.GetComponent<FlashlightController>();
	}

	void Update () {
		// Set state of Flashlight child object on left click
		if (Input.GetMouseButtonDown(1)) {
			flashlightController.ToggleLight();
		}
	}
}
