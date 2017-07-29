using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour {
	private bool isOn;
	// Use this for initialization
	void Start () {

	}

	public void ToggleSun() {
		isOn = !isOn;
		Debug.Log(isOn);
	}

	// Update is called once per frame
	void Update () {

	}
}
