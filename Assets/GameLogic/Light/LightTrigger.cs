using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {
	protected virtual void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(true);
			Debug.Log("Deactivating " + other);
		}
	}

	// protected virtual void OnTriggerStay (Collider other) {
	// 	if (other.tag == "") {
	//
	// 	}
	// }

	protected virtual void OnTriggerExit (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(false);
			Debug.Log("Activating " + other);
		}
	}
}
