using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverlay : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player") {
			Debug.Log("Collision detected with player");

		} else {
			Debug.Log("Collision detected");
		}
	}

	void OnTriggerExit (Collider other) {

	}
}
