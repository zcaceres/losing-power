using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
	private bool isOn;
	private GameObject lightTrigger;
	private GameObject lightSFX;

	void Awake () {
		// Get child components of Flashlight prefab
		lightTrigger = transform.Find("LightTrigger").gameObject;
		lightSFX = transform.Find("Light").gameObject;
	}

	/* We only expost this function to other classes to propagate
	 flashlight state down to the 'trigger' collider and light SFX
	 (helper functions below) */
	public void ToggleFlashlight () {
		isOn = !isOn;
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	void EnableLightTrigger (bool isOn) {
		lightTrigger.SetActive(isOn);
	}

	void EnableLight (bool isOn) {
		lightSFX.SetActive(isOn);
	}

}
