using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ReplaceLamps : MonoBehaviour {
	public GameObject streetlight;

	void OnEnable () {
		Transform[] childTransforms = transform.GetComponentsInChildren<Transform>();
		foreach (Transform ct in childTransforms) {
			Vector3 vec3 = ct.position;
			Quaternion quat = ct.rotation;
			var obj = Object.Instantiate(streetlight, vec3, quat);
		}
		// get all children
		// for each child
		// world position and rotation
		// Object.Instantiate(Streetlamp)
	}

}
