using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour {
	private AudioSource batterySFX;

	void Awake () {
		batterySFX = GameObject.FindWithTag("Player").transform.Find("BatterySFX").GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			var controller = other.transform.Find("Flashlight").GetComponent<FlashlightController>();
			batterySFX.Play();
			controller.RefillBattery();
			Destroy(gameObject);
		}
	}
}
