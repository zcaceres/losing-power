using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	private FlashlightController flashlightController;

	void Awake () {
		flashlightController = transform.Find("Flashlight").gameObject.GetComponent<FlashlightController>();
	}

	void Start () {

	}

	void Update () {
		// Set state of Flashlight child object on left click
		if (Input.GetMouseButtonDown(0)) {
			flashlightController.ToggleFlashlight();
		}
	}
}
