using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {
	protected virtual void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(true);
		}
	}

	protected virtual void OnTriggerExit (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(false);
		}
	}
}
