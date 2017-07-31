using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			var gm = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameManager>();
			gm.Lose();
		}
	}
}
