using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(true);
			Debug.Log("Deactivating " + other);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyController>().GotLit(false);
			Debug.Log("Activating " + other);
		}
	}

}
