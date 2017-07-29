using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
	private SphereCollider gravitationalField;

	void Awake() {
		gravitationalField = GetComponent<SphereCollider>();
		Debug.Log(gravitationalField);
	}

	void Start () {

	}



	void Update () {

	}
}
