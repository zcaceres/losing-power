using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGravity : MonoBehaviour {

	void OnCollisionStay(Collision other) {
		Debug.Log(other);
		Debug.Log(other.relativeVelocity);

	}

	// Update is called once per frame
	void Update () {

	}
}
