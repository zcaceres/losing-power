using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
	static GameObject[] lights;
	static GameManager gameManager;


	GameObject[] GetAllLights () {
		return GameObject.FindGameObjectsWithTag("Light");
	}

	void Awake () {
		lights = GetAllLights();
	}

	public void ChangeLights() {
		for (var i = 0; i < lights.Length; i++) {
			var probability = Random.Range(0f, 1.0f);
			if (probability > 0.5f) {
				lights[i].GetComponent<FlashlightController>().ToggleLight();
			}
		}
	}

}
