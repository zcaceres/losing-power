using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			var controller = other.transform.Find("Flashlight").GetComponent<FlashlightController>();
			Debug.Log("Refilled battery");
			controller.RefillBattery();
			Destroy(gameObject);
		}
	}
}
