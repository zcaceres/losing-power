using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
	protected bool isOn;
	protected GameObject lightTrigger;
	protected GameObject lightSFX;

	void Awake () {
		// Get child components of Flashlight prefab
		lightTrigger = transform.Find("LightTrigger").gameObject;
		lightSFX = transform.Find("Light").gameObject;
	}

	/* We only expose this function to other classes to propagate
	 flashlight state down to the 'trigger' collider and light SFX
	 (helper functions below) */
	public virtual void ToggleLight () {
		isOn = !isOn;
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	protected void EnableLightTrigger (bool isOn) {
		lightTrigger.SetActive(isOn);
	}

	protected void EnableLight (bool isOn) {
		lightSFX.SetActive(isOn);
	}

	public bool IsLightOn () {
		return isOn;
	}

}
