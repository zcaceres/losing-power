using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGravity : MonoBehaviour {

	void OnCollisionStay(Collision collisionInfo) {
		Debug.Log(collisionInfo);
	}

	// Update is called once per frame
	void Update () {

	}
}
